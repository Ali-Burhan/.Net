using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class CustomerInvoiceDetail
    {
        public int CustomerInvoiceDetailID { get; set; }
        public int CustomerInvoiceID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SaleQuantity { get; set; }
        public double SaleUnitPrice { get; set; }
        public double previousunitunitprice { get; set; }
        public System.DateTime manufacturedate { get; set; }
        public System.DateTime expirydate { get; set; }
        public double ItemCost { get; set; }

    }
}