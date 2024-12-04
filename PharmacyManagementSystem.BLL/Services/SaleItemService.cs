using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BLL.Services
{
    public class SaleItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddSaleItem(int saleId, SaleItem saleItem)
        {
            if (saleId <= 0 || saleItem == null)
            {
                return false;
            }

            var sale = _unitOfWork.saleRepository.Get(s => s.Id == saleId);
            if (sale == null)
            {
                return false;
            }

            saleItem.Sale_ID = saleId;

            try
            {
                _unitOfWork.saleItemRepository.Add(saleItem);
                sale.SaleItems.Add(saleItem);
                _unitOfWork.saleRepository.Update(sale);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public IEnumerable<SaleItem> GetSaleItemsBySaleId(int saleId)
        {
            if (saleId <= 0)
            {
                return Enumerable.Empty<SaleItem>();
            }

            try
            {
                return _unitOfWork.saleItemRepository.GetAll(si => si.Sale_ID == saleId).ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                return Enumerable.Empty<SaleItem>();
            }
        }

        public bool UpdateSaleItem(SaleItem saleItem)
        {
            if (saleItem == null || saleItem.Id <= 0)
            {
                return false;
            }

            try
            {
                var existingItem = _unitOfWork.saleItemRepository.Get(si => si.Id == saleItem.Id);
                if (existingItem == null)
                {
                    return false;
                }

                existingItem.Product_ID = saleItem.Product_ID;
                existingItem.Quantity = saleItem.Quantity;
                existingItem.Sale_Price = saleItem.Sale_Price;

                _unitOfWork.saleItemRepository.Update(existingItem);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool DeleteSaleItem(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
                var saleItem = _unitOfWork.saleItemRepository.Get(si => si.Id == id);
                if (saleItem == null)
                {
                    return false;
                }

                _unitOfWork.saleItemRepository.Remove(saleItem);
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
