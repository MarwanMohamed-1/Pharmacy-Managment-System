using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PharmacyManagementSystem.DAL.DataContext;
using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;

namespace PharmacyManagementSystem.BLL.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            Category category = new Category
            {
                Name = name
            };

            _unitOfWork.categoryRepository.Add(category);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.categoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.categoryRepository.Get(cat => cat.Id == id);
        }

        public bool UpdateCategory(Category category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.Name))
            {
                return false;
            }

            _unitOfWork.categoryRepository.Update(category);
            _unitOfWork.Save();

            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = _unitOfWork.categoryRepository.Get(cat => cat.Id == id);
            if (category == null)
            {
                return false;
            }

            _unitOfWork.categoryRepository.Remove(category);
            _unitOfWork.Save();

            return true;
        }
    }
}
