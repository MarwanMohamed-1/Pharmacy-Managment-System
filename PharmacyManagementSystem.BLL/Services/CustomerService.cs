using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BLL.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddCustomer(string name, string address, string phoneNum, string email)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNum))
            {
                return false;
            }

            // Check if a customer with the same name and phone number already exists
            var existingCustomer = _unitOfWork.customerRepository.Get(c => c.Phone_Num == phoneNum);

            // If the customer exists, do not add them again
            if (existingCustomer != null)
            {
                return false;
            }

            // Create a new customer
            Customer customer = new Customer
            {
                Name = name,
                Address = address,
                Phone_Num = phoneNum,
                Email = email
            };

            // Add the customer to the repository
            _unitOfWork.customerRepository.Add(customer);
            _unitOfWork.Save();

            return true;
        }


        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.customerRepository.GetAll(); // Assuming no navigation properties to include
        }

        public Customer GetCustomerById(int id)
        {
            return _unitOfWork.customerRepository.Get(cust => cust.Id == id);
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer == null || string.IsNullOrWhiteSpace(customer.Name))
            {
                return false;
            }

            _unitOfWork.customerRepository.Update(customer);
            _unitOfWork.Save();

            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = _unitOfWork.customerRepository.Get(cust => cust.Id == id);
            if (customer == null)
            {
                return false;
            }

            _unitOfWork.customerRepository.Remove(customer);
            _unitOfWork.Save();

            return true;
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            // Convert the search term to lowercase for case-insensitive matching
            string lowerSearchTerm = searchTerm.ToLower();

            // Perform a case-insensitive search for entries that start with the search term
            return _unitOfWork.customerRepository.GetAll()
                .Where(c => c.Name.ToLower().StartsWith(lowerSearchTerm) ||
                            c.Address.ToLower().StartsWith(lowerSearchTerm) ||
                            c.Phone_Num.ToLower().StartsWith(lowerSearchTerm))
                .ToList();
        }

    }
}
