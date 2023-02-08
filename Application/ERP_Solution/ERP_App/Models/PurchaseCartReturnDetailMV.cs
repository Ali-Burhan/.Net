using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class PurchaseCartReturnDetailMV
    {
        public int PurchaseCartReturnDetailID { get; set; }
        public int ProductID { get; set; }
        public int PurchaseQuantity { get; set; }
        public double purchaseUnitPrice { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int UserID { get; set; }
        public double PreviousPurchaseUnitPrice { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ManufactureDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<double> SaleUnitPrice { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
    }
}