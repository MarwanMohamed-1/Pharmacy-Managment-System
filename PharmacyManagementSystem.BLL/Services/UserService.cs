// PharmacyManagementSystem.BLL.Services/UsersService.cs
using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PharmacyManagementSystem.BLL.Services
{
    public class UsersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddUser(string userName, string password, string role, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                return false;
            }
            var existingUser = _unitOfWork.userRepository.Get(c => c.UserName == userName);

            if (existingUser != null)
            {
                return false;
            }
            var user = new Users
            {
                UserName = userName,
                UserPassword = HashPassword(password),
                Role = role,
                IsActive = isActive
            };

            try
            {
                _unitOfWork.userRepository.Add(user);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public IEnumerable<Users> GetAllUsers()
        {
            try
            {
                return _unitOfWork.userRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                return Enumerable.Empty<Users>();
            }
        }

        public Users GetUserById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            try
            {
                return _unitOfWork.userRepository.Get(u => u.Id == id);
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }

        public bool UpdateUser(Users user)
        {
            if (user == null || user.Id <= 0)
            {
                return false;
            }

            try
            {
                var existingUser = _unitOfWork.userRepository.Get(u => u.Id == user.Id);
                if (existingUser == null)
                {
                    return false;
                }

                existingUser.UserName = user.UserName;
                existingUser.Role = user.Role;
                existingUser.IsActive = user.IsActive;

                // Only update the password if it has been changed
                if (!string.IsNullOrWhiteSpace(user.UserPassword))
                {
                    existingUser.UserPassword = HashPassword(user.UserPassword);
                }

                _unitOfWork.userRepository.Update(existingUser);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
                var user = _unitOfWork.userRepository.Get(u => u.Id == id);
                if (user == null)
                {
                    return false;
                }

                _unitOfWork.userRepository.Remove(user);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public Users AuthenticateUser(string userName, string password)
        {
            try
            {
                var hashedPassword = HashPassword(password);
                return _unitOfWork.userRepository.Get(u => u.UserName == userName && u.UserPassword == hashedPassword && u.IsActive);
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
