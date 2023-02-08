using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class StockMV
    {
        public int ProductID { get; set; }
        public int ProductTypeID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Sale Unit Price")]
        public double SaleUnitPrice { get; set; }
        [Required(ErrorMessage = "Required")]
        public double CurrentPurchaseUnitPrice { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Expiry Date")]
        public System.DateTime ExpiryDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Manufacture Date")]
        public System.DateTime Manufacture { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Treshhold Quantity")]
        public int StockTreshHoldQuantity { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        [Display(Name = "Created By")]
        public string CreateBy{ get; set; }
        public bool IsActive { get; set; }
    }
}