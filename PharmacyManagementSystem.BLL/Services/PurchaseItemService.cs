using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BLL.Services
{
    public class PurchaseItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddPurchaseItem(int purchaseId, PurchaseItem purchaseItem)
        {
            if (purchaseId <= 0 || purchaseItem == null)
            {
                return false;
            }

            var purchase = _unitOfWork.purchaseRepository.Get(p => p.Id == purchaseId);
            if (purchase == null)
            {
                return false;
            }

            purchaseItem.Purchase_ID = purchaseId;

            try
            {
                _unitOfWork.PurchaseItemRepository.Add(purchaseItem);
                purchase.PurchaseItems.Add(purchaseItem);
                _unitOfWork.purchaseRepository.Update(purchase);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public IEnumerable<PurchaseItem> GetPurchaseItemsByPurchaseId(int purchaseId)
        {
            if (purchaseId <= 0)
            {
                return Enumerable.Empty<PurchaseItem>();
            }

            try
            {
                return _unitOfWork.PurchaseItemRepository.GetAll(pi => pi.Purchase_ID == purchaseId).ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                return Enumerable.Empty<PurchaseItem>();
            }
        }

        public bool UpdatePurchaseItem(PurchaseItem purchaseItem)
        {
            if (purchaseItem == null || purchaseItem.Id <= 0)
            {
                return false;
            }

            try
            {
                var existingItem = _unitOfWork.PurchaseItemRepository.Get(pi => pi.Id == purchaseItem.Id);
                if (existingItem == null)
                {
                    return false;
                }

                existingItem.Product_ID = purchaseItem.Product_ID;
                existingItem.Quantity = purchaseItem.Quantity;
                existingItem.Purchase_Price = purchaseItem.Purchase_Price;

                _unitOfWork.PurchaseItemRepository.Update(existingItem);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool DeletePurchaseItem(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
                var purchaseItem = _unitOfWork.PurchaseItemRepository.Get(pi => pi.Id == id);
                if (purchaseItem == null)
                {
                    return false;
                }

                _unitOfWork.PurchaseItemRepository.Remove(purchaseItem);
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
