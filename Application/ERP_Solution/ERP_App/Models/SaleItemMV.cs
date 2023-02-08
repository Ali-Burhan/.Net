using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class SaleItemMV
    {
        public int SaleCartDetailID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CompanyID { get; set; }
        public int CustomerID { get; set; }
        public int BranchID { get; set; }
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Sale Unit Price")]
        public double SaleUnitPrice { get; set; }
        [Display(Name = "Previous Purchase Unit Price")]
        public double PreviousPurchaseUnitPrice { get; set; }
        [Display(Name = "Current Purchase Unit Price")]

        public double CurrentPurchaseUnitPrice { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Expiry Date")]
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Manufacture Date")]
        public Nullable<System.DateTime> Manufacture { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        [Display(Name = "Created By")]
        public string CreateBy { get; set; }
        public bool IsActive { get; set; }

        public SaleOrderSummaryMV OrderSummary { get; set; }
        public List<SaleItemMV> SaleItemList { get; set; }
    }
}