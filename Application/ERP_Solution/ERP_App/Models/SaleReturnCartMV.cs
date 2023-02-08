using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class SaleReturnCartMV
    {
        public int SaleCartDetailID { get; set; }
        public int ProductID { get; set; }
        public int SaleQuantity { get; set; }
        public double SaleUnitPrice { get; set; }
        public int CompanyID { get; set; }
        public int CustomerID { get; set; }
        public int BranchID { get; set; }
        public int UserID { get; set; }
        public double PreviousSaleUnitPrice { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ManufactureDate { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ExpiryDate { get; set; }
        public Nullable<int> ProductTypeID { get; set; }

        public SaleReturnOrderSummaryMV OrderSummary { get; set; }
        public List<SaleReturnItemMV> SaleItemList { get; set; }

    }
}