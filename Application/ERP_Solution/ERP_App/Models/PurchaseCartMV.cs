using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class PurchaseCartMV
    {
        public int PurchaseCartDetailID { get; set; }
        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Product")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Purchase Quantity")]
        public int PurchaseQuantity { get; set; }
        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Current Purchase Unit Price")]
        public double CurrentPurchaseUnitPrice { get; set; }
        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Sale Unit Price")]
        public double SaleUnitPrice { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int UserID { get; set; }
        public double PreviousPurchaseUnitPrice { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Manufacture Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ManufactureDate { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Expiry Date")]
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        [Required(ErrorMessage = "Required*")]
        public int SupplierID { get; set; }
        public bool IsPaymentIsPaid { get; set; }

        public PurchaseCartSummaryMV OrderSummary { get; set; }
        public List<PurchaseItemsMV> PurchaseItemList { get; set; }
    }
}