using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class SaleReturnItemMV
    {
        public int SaleCartReturnDetailID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
        public int SaleQuantity { get; set; }
        public double SaleUnitPrice { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public double PreviousSaleUnitPrice { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> ManufactureDate { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> ExpiryDate { get; set; }
    }
}