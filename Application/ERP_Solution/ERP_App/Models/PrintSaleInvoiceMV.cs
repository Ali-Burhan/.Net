﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class PrintSaleInvoiceMV
    {
        public BranchMV branch { get; set; }
        public CustomerMV customer { get; set; }
        public CustomerInvoiceMV InvoiceHeader { get; set; }
        public List<CustomerInvoiceDetail> InvoiceDetails { get; set; }
        public double PaidAmount { get; set; }
    }
}