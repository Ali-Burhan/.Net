using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class PurchaseReturnOrderSummaryMV
    {
        public double SubTotal { get; set; }
        public double ShippingFee { get; set; }
        public double EstimateTax { get; set; }
        public double OrderTotal { get; set; }
    }
}