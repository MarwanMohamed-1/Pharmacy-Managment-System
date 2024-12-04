using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Document = iTextSharp.text.Document;

namespace PharmacyManagementSystem.BLL.Services
{
    public class SaleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SaleService()
        {
        }

        public bool AddSale(int customerId, DateTime saleDate)
        {
            if (customerId <= 0 || saleDate == default)
            {
                return false;
            }

            var sale = new Sale
            {
                Customer_ID = customerId,
                Sale_Date = saleDate
            };

            try
            {
                _unitOfWork.saleRepository.Add(sale);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public IEnumerable<Sale> GetAllSales()
        {
            try
            {
                return _unitOfWork.saleRepository.GetAll(includeProperties: "Customer,SaleItems").ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                return Enumerable.Empty<Sale>();
            }
        }

        public Sale GetSaleById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            try
            {
                return _unitOfWork.saleRepository.Get(s => s.Id == id, includeProperties: "Customer,SaleItems");
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }

        public bool UpdateSale(Sale sale)
        {
            if (sale == null || sale.Id <= 0)
            {
                return false;
            }

            try
            {
                var existingSale = _unitOfWork.saleRepository.Get(s => s.Id == sale.Id, includeProperties: "SaleItems");
                if (existingSale == null)
                {
                    return false;
                }

                existingSale.Customer_ID = sale.Customer_ID;
                existingSale.Sale_Date = sale.Sale_Date;

                _unitOfWork.saleRepository.Update(existingSale);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool DeleteSale(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
                var sale = _unitOfWork.saleRepository.Get(s => s.Id == id, includeProperties: "SaleItems");
                if (sale == null)
                {
                    return false;
                }

                _unitOfWork.saleRepository.Remove(sale);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public List<Sale> GetSalesReportData(DateTime startDate, DateTime endDate)
        {
            return _unitOfWork.saleRepository.GetSalesBetweenDates(startDate, endDate).ToList();
        }



        public void GenerateSalesReportPdf(DateTime startDate, DateTime endDate, string filePath)
        {
            var sales = GetSalesReportData(startDate, endDate);

            if (sales == null || sales.Count == 0)
            {
                throw new InvalidOperationException("No sales data available for the selected date range.");
            }

            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Add title
            Paragraph title = new Paragraph("Sales Report")
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(title);
            doc.Add(new Paragraph($"Date Range: {startDate.ToShortDateString()} - {endDate.ToShortDateString()}"));
            doc.Add(new Paragraph("\n"));




            // Create table for sales data
            PdfPTable table = new PdfPTable(5); // Adjust the number of columns based on data
            table.WidthPercentage = 100;
            table.AddCell("Sale ID");
            table.AddCell("Customer Name");
            table.AddCell("Sale Date");
            table.AddCell("Total Items");
            table.AddCell("Total Amount");

            foreach (var sale in sales)
            {
                table.AddCell(sale.Id.ToString());
                table.AddCell(sale.Customer.Name);
                table.AddCell(sale.Sale_Date.ToShortDateString());
                table.AddCell(sale.SaleItems.Count.ToString());
                table.AddCell(sale.SaleItems.Sum(si => si.Total).ToString("C"));
            }

            doc.Add(table);
            doc.Close();
        }

        public void PrintPdf(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified PDF file does not exist.");
            }

            // Using the system's default PDF viewer to print the document
            Process process = new Process();
            process.StartInfo.FileName = filePath;
            process.StartInfo.Verb = "print";
            process.StartInfo.CreateNoWindow = true;
            process.Start();

        }
    }
}
        

      

