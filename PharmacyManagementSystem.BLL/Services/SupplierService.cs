using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BLL.Services
{
    public class SupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddSupplier(string name, string address, string phoneNum, string email)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNum))
            {
                return false;
            }
            var existingSupplier = _unitOfWork.supplierRepository.Get(c => c.Phone_Num == phoneNum);

            if (existingSupplier != null)
            {
                return false;
            }
            var supplier = new Supplier
            {
                Name = name,
                Address = address,
                Phone_Num = phoneNum,
                Email = email
            };

            try
            {
                _unitOfWork.supplierRepository.Add(supplier);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            try
            {
                return _unitOfWork.supplierRepository.GetAll(includeProperties: "Purchases").ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                return Enumerable.Empty<Supplier>();
            }
        }

        public Supplier GetSupplierById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            try
            {
                return _unitOfWork.supplierRepository.Get(s => s.Id == id, includeProperties: "Purchases");
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            if (supplier == null || supplier.Id <= 0)
            {
                return false;
            }

            try
            {
                var existingSupplier = _unitOfWork.supplierRepository.Get(s => s.Id == supplier.Id);
                if (existingSupplier == null)
                {
                    return false;
                }

                existingSupplier.Name = supplier.Name;
                existingSupplier.Address = supplier.Address;
                existingSupplier.Phone_Num = supplier.Phone_Num;
                existingSupplier.Email = supplier.Email;

                _unitOfWork.supplierRepository.Update(existingSupplier);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool DeleteSupplier(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
                var supplier = _unitOfWork.supplierRepository.Get(s => s.Id == id);
                if (supplier == null)
                {
                    return false;
                }

                _unitOfWork.supplierRepository.Remove(supplier);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }
        public List<Supplier> SearchSupplier(string searchTerm)
        {
            // Convert the search term to lowercase for case-insensitive matching
            string lowerSearchTerm = searchTerm.ToLower();

            // Perform a case-insensitive search for entries that start with the search term
            return _unitOfWork.supplierRepository.GetAll()
                .Where(c => c.Name.ToLower().StartsWith(lowerSearchTerm) ||
                            c.Address.ToLower().StartsWith(lowerSearchTerm) ||
                            c.Phone_Num.ToLower().StartsWith(lowerSearchTerm) ||
                            c.Email.ToLower().StartsWith(lowerSearchTerm)).ToList();
        }
    }
}
