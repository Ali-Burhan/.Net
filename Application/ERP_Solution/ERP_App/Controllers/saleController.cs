using DataBaseLayer;
using ERP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_App.Controllers
{
    public class saleController : Controller
    {
        // GET: sale
        private CloudERPEntities DB = new CloudERPEntities();
        // GET: Purchase
        public ActionResult SaleStockProducts()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);
            var stock = DB.tblSaleCartDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();
            var saleitems = new SaleCartMV();
            var list = new List<SaleItemMV>();
            double extax = 0;
            double subTotal = 0;
            foreach (var product in stock)
            {
                var item = new SaleItemMV();
                //  item.BranchID = product.BranchID;
                //  item.CategoryID = product.CategoryID;
                // item.CompanyID = product.CompanyID;
                item.CreateBy = product.tblUser.UserName;
                item.CurrentPurchaseUnitPrice = product.SaleUnitPrice;
                item.PreviousPurchaseUnitPrice = product.PreviousSaleUnitPrice;
                item.Description = product.Description;
                item.ExpiryDate = product.ExpiryDate;
                item.Manufacture = product.ManufactureDate;
                // item.IsActive = product.IsActive;
                item.ProductID = product.ProductID;
                item.ProductName = product.tblStock.ProductName;
                item.Quantity = product.SaleQuantity;
                item.SaleUnitPrice = (double)product.SaleUnitPrice;
                item.SaleCartDetailID = product.SaleCartDetailID;
                item.UserID = product.UserID;
                item.CategoryName = product.tblStock.tblCategory.categoryName;
                list.Add(item);
                subTotal = subTotal + ((double)product.SaleUnitPrice * product.SaleQuantity);
                extax = (subTotal * 17) / 100;
            }
            saleitems.SaleItemList = list;
            saleitems.OrderSummary = new SaleOrderSummaryMV() { SubTotal = subTotal, EstimateTax = extax };
            ViewBag.ProductID = new SelectList(DB.tblStocks.Where(s => s.BranchID == branchid && s.CompanyID == companyid && s.ProductTypeID == 2).ToList(), "ProductID", "ProductName", "0");
            ViewBag.CustomerID = new SelectList(DB.tblCustomers.Where(s => s.BranchID == branchid && s.CompanyID == companyid).ToList(), "CustomerID", "CustomerName", "0");

            return View(saleitems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaleStockProducts(SaleCartMV salecartMV)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);

            if (ModelState.IsValid)
            {
                var checkproductincart = DB.tblSaleCartDetails.Where(i => i.ProductID == salecartMV.ProductID && i.CompanyID == companyid && i.BranchID == branchid && i.UserID == userid && i.ProductTypeID == 2).FirstOrDefault();
                if (checkproductincart == null)
                {
                    var item = new tblSaleCartDetail();
                    item.BranchID = branchid;
                    item.CompanyID = companyid;
                    item.ProductID = salecartMV.ProductID;
                    item.SaleQuantity = salecartMV.SaleQuantity;
                    item.SaleUnitPrice = salecartMV.SaleUnitPrice;
                    item.PreviousSaleUnitPrice = salecartMV.PreviousSaleUnitPrice;
                    item.ManufactureDate = salecartMV.ManufactureDate;
                    item.ExpiryDate = salecartMV.ExpiryDate;
                    item.Description = salecartMV.Description;
                    item.UserID = userid;
                    DB.tblSaleCartDetails.Add(item);
                    DB.SaveChanges();
                    return RedirectToAction("SaleStockProducts");
                }
                else { ModelState.AddModelError("ProductID", "Already in the cart!"); }
            }
            var stock = DB.tblSaleCartDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();
            var purchaseitems = new SaleCartMV();
            var list = new List<SaleItemMV>();
            foreach (var product in stock)
            {
                var item = new SaleItemMV();
                //  item.BranchID = product.BranchID;
                //  item.CategoryID = product.CategoryID;
                // item.CompanyID = product.CompanyID;
                item.CreateBy = product.tblUser.UserName;
                item.CurrentPurchaseUnitPrice = product.SaleUnitPrice;
                item.PreviousPurchaseUnitPrice = product.PreviousSaleUnitPrice;
                item.Description = product.Description;
                item.ExpiryDate = product.ExpiryDate;
                item.Manufacture = product.ManufactureDate;
                // item.IsActive = product.IsActive;
                item.ProductID = product.ProductID;
                item.ProductName = product.tblStock.ProductName;
                item.Quantity = product.SaleQuantity;
                item.SaleUnitPrice = (double)product.SaleUnitPrice;
                item.SaleCartDetailID = product.SaleCartDetailID;
                item.UserID = product.UserID;
                item.CategoryName = product.tblStock.tblCategory.categoryName;
                list.Add(item);
            }
            salecartMV.SaleItemList = list;
            ViewBag.ProductID = new SelectList(DB.tblStocks.Where(s => s.BranchID == branchid && s.CompanyID == companyid && s.ProductTypeID == 2).ToList(), "ProductID", "ProductName", salecartMV.ProductID);
            ViewBag.CustomerID = new SelectList(DB.tblCustomers.Where(s => s.BranchID == branchid && s.CompanyID == companyid).ToList(), "CustomerID", "CustomerName", salecartMV.CustomerID);
            return View(salecartMV);
        }

        public ActionResult DeleteSaleCartItem(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var pitem = DB.tblSaleCartDetails.Find(id);
            DB.Entry(pitem).State = System.Data.Entity.EntityState.Deleted;
            DB.SaveChanges();
            return RedirectToAction("SaleStockProducts");
        }






        public ActionResult CheckoutPurchase(int? customerid, bool ispaymentispaid,
            float? estimatedtax,
            float? shippingfee,
            float? subtotal)
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);


            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    var datetime = DateTime.Now;
                    var customer = DB.tblCustomers.Find(customerid);
                    if (customer == null)
                    {
                        ModelState.AddModelError("CustomerID", "Please Select Customer");
                        transaction.Rollback();
                    }
                    float totalamount = (float)subtotal + (float)estimatedtax + (float)shippingfee;
                    string invoiceno = "SAL" + datetime.ToString("yyyymmddhhmmss") + userid;
                    var invoiceheader = new tblCustomerInvoice();
                    invoiceheader.CustomerID = (int)customerid;
                    invoiceheader.CompanyID = companyid;
                    invoiceheader.BranchID = branchid;
                    invoiceheader.InvoiceNo = invoiceno;
                    invoiceheader.TotalAmount = totalamount;
                    invoiceheader.InvoiceDate = datetime;
                    invoiceheader.Description = " ";
                    invoiceheader.UserID = userid;
                    invoiceheader.subtotalamount = (float)subtotal;
                    invoiceheader.estimatedtax = (float)estimatedtax;
                    invoiceheader.shippingfee = (float)shippingfee;
                    DB.tblCustomerInvoices.Add(invoiceheader);
                    DB.SaveChanges();
                    var purchasestock = DB.tblSaleCartDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();

                    foreach (var product in purchasestock)
                    {
                        var purchaseitem = new tblCustomerInvoiceDetail();




                        purchaseitem.CustomerInvoiceID = invoiceheader.CustomerInvoiceID;
                        purchaseitem.ProductID = product.ProductID;
                        purchaseitem.SaleQuantity = product.SaleQuantity;
                        purchaseitem.SaleUnitPrice = product.SaleUnitPrice;
                        purchaseitem.PreviousSaleunitprice = product.PreviousSaleUnitPrice;
                        purchaseitem.manufacturedate = (DateTime)product.ManufactureDate;
                        purchaseitem.expirydate = (DateTime)product.ExpiryDate;
                        DB.tblCustomerInvoiceDetails.Add(purchaseitem);
                        DB.SaveChanges();





                        var stockproduct = DB.tblStocks.Find(product.ProductID);
                        stockproduct.Manufacture = (DateTime)product.ManufactureDate;
                        stockproduct.ExpiryDate = (DateTime)product.ExpiryDate;
                        stockproduct.Quantity = stockproduct.Quantity + product.SaleQuantity;
                        stockproduct.CurrentPurchaseUnitPrice = product.SaleUnitPrice;
                        stockproduct.SaleUnitPrice = (double)product.SaleUnitPrice;
                        DB.Entry(stockproduct).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                    }
                    //purchase Product Debit transaction
                    int FinancialYearID = 0;
                    var financial = DB.tblFinancialYears.Where(s => s.IsActive == true).FirstOrDefault();
                    if (financial == null)
                    {
                        ModelState.AddModelError("ProductID", "Financial Year is not set!");
                        transaction.Rollback();
                    }
                    FinancialYearID = financial.FinancialYearID;
                    int AccountHeadID = 0;
                    int AccountControlID = 0;
                    int AccountSubControlID = 0;



                    //Debit Entry
                    var debitentry = DB.tblAccountSettings.Where(s => s.AccountActivityID == 4 && s.CompanyID == companyid && s.BranchID == branchid).FirstOrDefault();
                    if (debitentry == null)
                    {
                        ModelState.AddModelError("ProductID", "First Set Account Flow!");
                        transaction.Rollback();
                    }
                    AccountHeadID = debitentry.AccountHeadID;
                    AccountControlID = debitentry.AccountControlID;
                    AccountSubControlID = debitentry.AccountSubControlID;

                    var setdebitentry = new tblTransaction();

                    setdebitentry.FinancialYearID = FinancialYearID;
                    setdebitentry.AccountHeadID = AccountHeadID;
                    setdebitentry.AccountControlID = AccountControlID;
                    setdebitentry.AccountSubControlID = AccountSubControlID;
                    setdebitentry.InvoiceNo = invoiceno;
                    setdebitentry.CompanyID = companyid;
                    setdebitentry.BranchID = branchid;
                    setdebitentry.Credit = totalamount;
                    setdebitentry.Debit = 0;
                    setdebitentry.TransectionDate = datetime;
                    setdebitentry.TransectionTitle = "Sale Form" + customer.Customername;
                    setdebitentry.UserID = userid;
                    DB.tblTransactions.Add(setdebitentry);
                    DB.SaveChanges();



                    //Credit Entry
                    var creditentry = DB.tblAccountSettings.Where(s => s.AccountActivityID == 9 && s.CompanyID == companyid && s.BranchID == branchid).FirstOrDefault();
                    if (creditentry == null)
                    {
                        ModelState.AddModelError("ProductID", "First Set Account Flow!");
                        transaction.Rollback();
                    }
                    AccountHeadID = creditentry.AccountHeadID;
                    AccountControlID = creditentry.AccountControlID;
                    AccountSubControlID = creditentry.AccountSubControlID;

                    var setcreditentry = new tblTransaction();

                    setcreditentry.FinancialYearID = FinancialYearID;
                    setcreditentry.AccountHeadID = AccountHeadID;
                    setcreditentry.AccountControlID = AccountControlID;
                    setcreditentry.AccountSubControlID = AccountSubControlID;
                    setcreditentry.InvoiceNo = invoiceno;
                    setcreditentry.CompanyID = companyid;
                    setcreditentry.BranchID = branchid;
                    setcreditentry.Credit = 0;
                    setcreditentry.Debit = totalamount;
                    setcreditentry.TransectionDate = datetime;
                    setcreditentry.TransectionTitle = "Sale Payment is pending(" + customer.Customername + ")";
                    setcreditentry.UserID = userid;
                    DB.tblTransactions.Add(setcreditentry);
                    DB.SaveChanges();





                    if (ispaymentispaid == true)
                    {
                        invoiceno = "SPP" + DateTime.Now.ToString("yyyymmddhhmmss") + userid;
                        var incoicepayment = new tblCustomerPayment();




                        incoicepayment.CustomerID = (int)customerid;
                        incoicepayment.CustomerInvoiceID = invoiceheader.CustomerInvoiceID;
                        incoicepayment.CompanyID = companyid;
                        incoicepayment.BranchID = branchid;
                        incoicepayment.invoiceNo = invoiceno;
                        incoicepayment.TotalAmount = totalamount;
                        incoicepayment.PaidAmount = totalamount;
                        incoicepayment.RemainingBalance = 0;
                        incoicepayment.UserID = userid;
                        incoicepayment.InvoiceDate = DateTime.Now;
                        DB.tblCustomerPayments.Add(incoicepayment);
                        DB.SaveChanges();




                        //Payment Debit Transaction :Purchase Payment Pending
                        debitentry = DB.tblAccountSettings.Where(s => s.AccountActivityID == 8 && s.CompanyID == companyid && s.BranchID == branchid).FirstOrDefault();
                        if (debitentry == null)
                        {
                            ModelState.AddModelError("ProductID", "First Set Account Flow!");
                            transaction.Rollback();
                        }
                        AccountHeadID = debitentry.AccountHeadID;
                        AccountControlID = debitentry.AccountControlID;
                        AccountSubControlID = debitentry.AccountSubControlID;

                        setdebitentry = new tblTransaction();

                        setdebitentry.FinancialYearID = FinancialYearID;
                        setdebitentry.AccountHeadID = AccountHeadID;
                        setdebitentry.AccountControlID = AccountControlID;
                        setdebitentry.AccountSubControlID = AccountSubControlID;
                        setdebitentry.InvoiceNo = invoiceno;
                        setdebitentry.CompanyID = companyid;
                        setdebitentry.BranchID = branchid;
                        setdebitentry.Credit = totalamount;
                        setdebitentry.Debit = 0;
                        setdebitentry.TransectionDate = datetime;
                        setdebitentry.TransectionTitle = "Sale Payment is Transfer(" + customer.Customername + ")";
                        setdebitentry.UserID = userid;
                        DB.tblTransactions.Add(setdebitentry);
                        DB.SaveChanges();




                        //Payment Credit Entry : Purchse Payment Paid
                        creditentry = DB.tblAccountSettings.Where(s => s.AccountActivityID == 9 && s.CompanyID == companyid && s.BranchID == branchid).FirstOrDefault();
                        if (creditentry == null)
                        {
                            ModelState.AddModelError("ProductID", "First Set Account Flow!");
                            transaction.Rollback();
                        }
                        AccountHeadID = creditentry.AccountHeadID;
                        AccountControlID = creditentry.AccountControlID;
                        AccountSubControlID = creditentry.AccountSubControlID;

                        setcreditentry = new tblTransaction();

                        setcreditentry.FinancialYearID = FinancialYearID;
                        setcreditentry.AccountHeadID = AccountHeadID;
                        setcreditentry.AccountControlID = AccountControlID;
                        setcreditentry.AccountSubControlID = AccountSubControlID;
                        setcreditentry.InvoiceNo = invoiceno;
                        setcreditentry.CompanyID = companyid;
                        setcreditentry.BranchID = branchid;
                        setcreditentry.Credit = 0;
                        setcreditentry.Debit = totalamount;
                        setcreditentry.TransectionDate = datetime;
                        setcreditentry.TransectionTitle = "Sale Payment is Paid(" + customer.Customername + ")";
                        setcreditentry.UserID = userid;
                        DB.tblTransactions.Add(setcreditentry);
                        DB.SaveChanges();

                    }

                    DB.Database.ExecuteSqlCommand("TRUNCATE TABLE tblSaleCartDetail");
                    transaction.Commit();
                    return RedirectToAction("PrintSaleInvoice", new { supplierinvoiceid = invoiceheader.CustomerInvoiceID });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

            }


            return View();
        }

        public ActionResult PrintSaleInvoice(int? supplierinvoiceid)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);
            var supplierinvoice = DB.tblCustomerInvoices.Find(supplierinvoiceid);

            var purchaseinvoice = new PrintSaleInvoiceMV();

            // Set Purchase Invoice Header Detail
            var invoiceheader = new CustomerInvoiceMV();

            invoiceheader.CustomerInvoiceID = supplierinvoice.CustomerInvoiceID;
            invoiceheader.CustomerID = supplierinvoice.CustomerID;
            invoiceheader.CompanyID = supplierinvoice.CompanyID;
            invoiceheader.BranchID = supplierinvoice.BranchID;
            invoiceheader.InvoiceNo = supplierinvoice.InvoiceNo;
            invoiceheader.TotalAmount = supplierinvoice.TotalAmount;
            invoiceheader.InvoiceDate = supplierinvoice.InvoiceDate;
            invoiceheader.Description = supplierinvoice.Description;
            invoiceheader.subtotalamount = supplierinvoice.subtotalamount;
            invoiceheader.estimatedtax = supplierinvoice.estimatedtax;
            invoiceheader.shippingfee = supplierinvoice.shippingfee;
            purchaseinvoice.InvoiceHeader = invoiceheader;




            // Set Purchase Branch Invoice 
            var branch = new BranchMV();
            branch.BranchName = supplierinvoice.tblBranch.BranchName;
            branch.BranchContact = supplierinvoice.tblBranch.BranchContact;
            branch.BranchAddress = supplierinvoice.tblBranch.BranchAddress;
            purchaseinvoice.branch = branch;



            // set Purchase Invoice Supplier 
            var supplier = new CustomerMV();
            supplier.Customername = supplierinvoice.tblCustomer.Customername;
            supplier.CustomerContact = supplierinvoice.tblCustomer.CustomerContact;
            supplier.CustomerAddress = supplierinvoice.tblCustomer.CustomerAddress;
            supplier.CustomerArea = supplierinvoice.tblCustomer.CustomerArea;
            purchaseinvoice.customer = supplier;





            var purchaseitem = new List<CustomerInvoiceDetail>();
            foreach (var item in supplierinvoice.tblCustomerInvoiceDetails)
            {
                var product = new CustomerInvoiceDetail();
                product.CustomerInvoiceDetailID = item.CustomerInvoiceDetailID;
                product.CustomerInvoiceID = item.CustomerInvoiceID;
                product.ProductID = item.ProductID;
                product.ProductName = item.tblStock.ProductName;
                product.SaleQuantity = item.SaleQuantity;
                product.SaleUnitPrice = item.SaleUnitPrice;
                product.previousunitunitprice = item.PreviousSaleunitprice;
                product.manufacturedate = (DateTime)item.manufacturedate;
                product.expirydate = (DateTime)item.expirydate;
                product.ItemCost = (item.SaleQuantity * item.SaleUnitPrice);
                purchaseitem.Add(product);
            }
            purchaseinvoice.InvoiceDetails = purchaseitem;
            return View(purchaseinvoice);
        }



        public ActionResult AllSales()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);

            var purchaselist = new List<PrintSaleInvoiceMV>();
            var allpurchases = DB.tblCustomerInvoices.Where(s => s.CompanyID == companyid && s.BranchID == branchid);
            foreach (var supplierinvoice in allpurchases)
            {
                var purchaseinvoice = new PrintSaleInvoiceMV();

                // Set Purchase Invoice Header Detail
                var invoiceheader = new CustomerInvoiceMV();

                invoiceheader.CustomerInvoiceID = supplierinvoice.CustomerInvoiceID;
                invoiceheader.CustomerID = supplierinvoice.CustomerID;
                invoiceheader.CompanyID = supplierinvoice.CompanyID;
                invoiceheader.BranchID = supplierinvoice.BranchID;
                invoiceheader.InvoiceNo = supplierinvoice.InvoiceNo;
                invoiceheader.TotalAmount = supplierinvoice.TotalAmount;
                invoiceheader.InvoiceDate = supplierinvoice.InvoiceDate;
                invoiceheader.Description = supplierinvoice.Description;
                invoiceheader.subtotalamount = supplierinvoice.subtotalamount;
                invoiceheader.estimatedtax = supplierinvoice.estimatedtax;
                invoiceheader.shippingfee = supplierinvoice.shippingfee;
                purchaseinvoice.InvoiceHeader = invoiceheader;




                // Set Purchase Branch Invoice 
                var branch = new BranchMV();
                branch.BranchName = supplierinvoice.tblBranch.BranchName;
                branch.BranchContact = supplierinvoice.tblBranch.BranchContact;
                branch.BranchAddress = supplierinvoice.tblBranch.BranchAddress;
                purchaseinvoice.branch = branch;



                // set Purchase Invoice Supplier 
                var supplier = new CustomerMV();
                supplier.Customername = supplierinvoice.tblCustomer.Customername;
                supplier.CustomerContact = supplierinvoice.tblCustomer.CustomerContact;
                supplier.CustomerAddress = supplierinvoice.tblCustomer.CustomerAddress;
                supplier.CustomerArea = supplierinvoice.tblCustomer.CustomerArea;
                purchaseinvoice.customer = supplier;





                var purchaseitem = new List<CustomerInvoiceDetail>();
                foreach (var item in supplierinvoice.tblCustomerInvoiceDetails)
                {
                    var product = new CustomerInvoiceDetail();
                    product.CustomerInvoiceDetailID = item.CustomerInvoiceDetailID;
                    product.CustomerInvoiceID = item.CustomerInvoiceID;
                    product.ProductID = item.ProductID;
                    product.ProductName = item.tblStock.ProductName;
                    product.SaleQuantity = item.SaleQuantity;
                    product.SaleUnitPrice = item.SaleUnitPrice;
                    product.previousunitunitprice = item.PreviousSaleunitprice;
                    product.manufacturedate = (DateTime)item.manufacturedate;
                    product.expirydate = (DateTime)item.expirydate;
                    product.ItemCost = (item.SaleQuantity * item.SaleUnitPrice);
                    purchaseitem.Add(product);
                }

                var supplierpayment = DB.tblCustomerPayments.Where(p => p.CustomerInvoiceID == supplierinvoice.CustomerInvoiceID).ToList();
                if (supplierpayment != null)
                {
                    if (supplierpayment.Count() > 0)
                    {
                        purchaseinvoice.PaidAmount = supplierpayment.Sum(s => s.PaidAmount);
                    }
                }
                purchaseinvoice.InvoiceDetails = purchaseitem;
                purchaselist.Add(purchaseinvoice);
            }
            return View(purchaselist);
        }
    }

}
