using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_App.Models
{
    public class AccountHeadMV
    {
        public int AccountHeadID { get; set; }
        public string AccountHeadName { get; set; }
        public int Code { get; set; }
        public int UserID { get; set; }
        public string CreatedBy { get; set; }
    }
}