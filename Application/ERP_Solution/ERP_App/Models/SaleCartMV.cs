using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class SaleCartMV
    {
        public int SaleCartDetailID { get; set; }
        public int ProductID { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductName { get; set; }
        public int SaleQuantity { get; set; }
        public double SaleUnitPrice { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public double PreviousSaleUnitPrice { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ManufactureDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public SaleOrderSummaryMV OrderSummary { get; set; }
        public List<SaleItemMV> SaleItemList { get; set; }
    }
}