using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BLL.Services
{
    public class PurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddPurchase(int supplierId, DateTime purchaseDate)
        {
            if (supplierId <= 0 || purchaseDate == default)
            {
                return false;
            }

            var purchase = new Purchase
            {
                Supplier_ID = supplierId,
                Purchase_Date = purchaseDate
            };

            try
            {
                _unitOfWork.purchaseRepository.Add(purchase);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            try
            {
                return _unitOfWork.purchaseRepository.GetAll(includeProperties: "Supplier,PurchaseItems").ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                return Enumerable.Empty<Purchase>();
            }
        }

        public Purchase GetPurchaseById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            try
            {
                return _unitOfWork.purchaseRepository.Get(p => p.Id == id, includeProperties: "Supplier,PurchaseItems");
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }

        public bool UpdatePurchase(Purchase purchase)
        {
            if (purchase == null || purchase.Id <= 0)
            {
                return false;
            }

            try
            {
                var existingPurchase = _unitOfWork.purchaseRepository.Get(p => p.Id == purchase.Id, includeProperties: "PurchaseItems");
                if (existingPurchase == null)
                {
                    return false;
                }

                existingPurchase.Supplier_ID = purchase.Supplier_ID;
                existingPurchase.Purchase_Date = purchase.Purchase_Date;

                _unitOfWork.purchaseRepository.Update(existingPurchase);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool DeletePurchase(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
                var purchase = _unitOfWork.purchaseRepository.Get(p => p.Id == id, includeProperties: "PurchaseItems");
                if (purchase == null)
                {
                    return false;
                }

                _unitOfWork.purchaseRepository.Remove(purchase);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

    }

}
