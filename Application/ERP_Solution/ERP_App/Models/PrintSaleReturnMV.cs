using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class PrintSaleReturnMV
    {
        public BranchMV branch { get; set; }
        public CustomerMV customer { get; set; }
        public CustomerReturnInvoiveMV InvoiceHeader { get; set; }
        public List<CustomerReturnInvoiceDetailMV> InvoiceDetails { get; set; }
        public double PaidAmount { get; set; }
    }
}