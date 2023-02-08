using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class PrintPurchaseReturnMV
    {
        public BranchMV branch { get; set; }
        public SupplierMV supplier { get; set; }
        public SupplierReturnInvoiceMV InvoiceHeader { get; set; }
        public List<SupplierReturnInvoiceDetailMV> InvoiceDetails { get; set; }
        public double PaidAmount { get; set; }
    }
}