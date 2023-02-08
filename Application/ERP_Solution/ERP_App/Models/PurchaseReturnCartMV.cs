using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class PurchaseReturnCartMV
    {
        public int PurchaseCartDetailID { get; set; }
        public int ProductID { get; set; }
        public int PurchaseQuantity { get; set; }
        public double purchaseUnitPrice { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public int SupplierID { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public double PreviousPurchaseUnitPrice { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ManufactureDate { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ExpiryDate { get; set; }
        public double SaleUnitPrice { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
        public int PurchaseCartReturnDetailID { get; set; }

        public PurchaseReturnOrderSummaryMV OrderSummary { get; set; }
        public List<PurchaseReturnItemMV> SaleItemList { get; set; }
    }
}