using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System.Collections.Generic;

namespace PharmacyManagementSystem.BLL.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddProduct(string name, string genericName, string type, int quantity, DateTime expireDate, string company, string packSize, decimal price, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name) || price <= 0)
            {
                return false;
            }

            Product product = new Product
            {
                Name = name,
                Generic_Name = genericName,
                Type = " ",
                Quantity = quantity,
                Expire_Date = expireDate,
                Company = company,
                Pack_Size = packSize,
                price = price,
                Category_ID = categoryId
            };

            _unitOfWork.productRepository.Add(product);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.productRepository.GetAll(includeProperties: "Category,SaleItems,PurchaseItems");
        }

        public Product GetProductById(int id)
        {
            return _unitOfWork.productRepository.Get(prod=> prod.Id == id);
        }

        public bool UpdateProduct(Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name) || product.price <= 0)
            {
                return false;
            }

            _unitOfWork.productRepository.Update(product);
            _unitOfWork.Save();

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = _unitOfWork.productRepository.Get(prod => prod.Id == id);
            if (product == null)
            {
                return false;
            }

            _unitOfWork.productRepository.Remove(product);
            _unitOfWork.Save();

            return true;
        }
    }
}
