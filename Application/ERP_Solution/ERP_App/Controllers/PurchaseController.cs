using DataBaseLayer;
using ERP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_App.Controllers
{
    public class PurchaseController : Controller
    {
        private CloudERPEntities DB = new CloudERPEntities();
        // GET: Purchase
        public ActionResult PurchaseStockProducts()
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
            var stock = DB.tblPurchaseCartDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();
            var purchaseitems = new PurchaseCartMV();
            var list = new List<PurchaseItemsMV>();
            double extax = 0;
            double subTotal = 0;
            foreach (var product in stock)
            {
                var item = new PurchaseItemsMV();
              //  item.BranchID = product.BranchID;
              //  item.CategoryID = product.CategoryID;
               // item.CompanyID = product.CompanyID;
                item.CreateBy = product.tblUser.UserName;
                item.CurrentPurchaseUnitPrice = product.purchaseUnitPrice;
                item.PreviousPurchaseUnitPrice = product.PreviousPurchaseUnitPrice;
                item.Description = product.Description;
                item.ExpiryDate = product.ExpiryDate;
                item.Manufacture = product.ManufactureDate;
               // item.IsActive = product.IsActive;
                item.ProductID = product.ProductID;
                item.ProductName = product.tblStock.ProductName;
                item.Quantity = product.PurchaseQuantity;
                item.SaleUnitPrice = (double)product.SaleUnitPrice;
                item.PurchaseCartDetailID = product.PurchaseCartDetailID;
                item.UserID = product.UserID;
                item.CategoryName = product.tblStock.tblCategory.categoryName;
                list.Add(item);
                subTotal = subTotal + ((double)product.SaleUnitPrice * product.PurchaseQuantity);
                extax = (subTotal * 17) / 100;
            }
            purchaseitems.PurchaseItemList = list;
            purchaseitems.OrderSummary = new PurchaseCartSummaryMV() { SubTotal = subTotal, EstimateTax = extax };
            ViewBag.ProductID = new SelectList(DB.tblStocks.Where(s => s.BranchID == branchid && s.CompanyID == companyid && s.ProductTypeID == 1).ToList(), "ProductID", "ProductName", "0");
            ViewBag.SupplierID = new SelectList(DB.tblSuppliers.Where(s => s.BranchID == branchid && s.CompanyID == companyid).ToList(), "SupplierID", "SupplierName", "0");

            return View(purchaseitems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseStockProducts(PurchaseCartMV purchasecartMV)
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

            if(ModelState.IsValid)
            {
                var checkproductincart = DB.tblPurchaseCartDetails.Where(i => i.ProductID == purchasecartMV.ProductID && i.CompanyID == companyid && i.BranchID == branchid && i.UserID == userid && i.ProductTypeID == 1).FirstOrDefault();
                if (checkproductincart == null )
                {
                    var item = new tblPurchaseCartDetail();
                    item.BranchID = branchid;
                    item.CompanyID = companyid;
                    item.ProductID = purchasecartMV.ProductID;
                    item.PurchaseQuantity = purchasecartMV.PurchaseQuantity;
                    item.purchaseUnitPrice = purchasecartMV.CurrentPurchaseUnitPrice;
                    item.SaleUnitPrice = purchasecartMV.SaleUnitPrice;
                    item.PreviousPurchaseUnitPrice = purchasecartMV.PreviousPurchaseUnitPrice;
                    item.ManufactureDate = purchasecartMV.ManufactureDate;
                    item.ExpiryDate = purchasecartMV.ExpiryDate;
                    item.Description = purchasecartMV.Description;
                    item.UserID = userid;
                    DB.tblPurchaseCartDetails.Add(item);
                    DB.SaveChanges();
                    return RedirectToAction("PurchaseStockProducts");
                }
                else { ModelState.AddModelError("ProductID","Already in the cart!"); }
            }
            var stock = DB.tblPurchaseCartDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();
            var purchaseitems = new PurchaseCartMV();
            var list = new List<PurchaseItemsMV>();
            foreach (var product in stock)
            {
                var item = new PurchaseItemsMV();
                //  item.BranchID = product.BranchID;
                //  item.CategoryID = product.CategoryID;
                // item.CompanyID = product.CompanyID;
                item.CreateBy = product.tblUser.UserName;
                item.CurrentPurchaseUnitPrice = product.purchaseUnitPrice;
                item.PreviousPurchaseUnitPrice = product.PreviousPurchaseUnitPrice;
                item.Description = product.Description;
                item.ExpiryDate = product.ExpiryDate;
                item.Manufacture = product.ManufactureDate;
                // item.IsActive = product.IsActive;
                item.ProductID = product.ProductID;
                item.ProductName = product.tblStock.ProductName;
                item.Quantity = product.PurchaseQuantity;
                item.SaleUnitPrice = (double)product.SaleUnitPrice;
                item.PurchaseCartDetailID = product.PurchaseCartDetailID;
                item.UserID = product.UserID;
                item.CategoryName = product.tblStock.tblCategory.categoryName;
                list.Add(item);
            }
            purchasecartMV.PurchaseItemList = list;
            ViewBag.ProductID = new SelectList(DB.tblStocks.Where(s => s.BranchID == branchid && s.CompanyID == companyid && s.ProductTypeID == 1).ToList(), "ProductID", "ProductName", purchasecartMV.ProductID);
            ViewBag.SupplierID = new SelectList(DB.tblSuppliers.Where(s => s.BranchID == branchid && s.CompanyID == companyid).ToList(), "SupplierID", "SupplierName", purchasecartMV.SupplierID);
            return View(purchasecartMV);
        }

        public ActionResult DeletePurchaseCartItem(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var pitem = DB.tblPurchaseCartDetails.Find(id);
            DB.Entry(pitem).State = System.Data.Entity.EntityState.Deleted;
            DB.SaveChanges();
            return RedirectToAction("PurchaseStockProducts");
        }






        public ActionResult CheckoutPurchase (int? supplierid, bool ispaymentispaid,
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
                    var supplier = DB.tblSuppliers.Find(supplierid);
                    if (supplier == null)
                    {
                        ModelState.AddModelError("SupplierID", "Please Select Supplier");
                        transaction.Rollback();
                    }
                    float totalamount = (float)subtotal + (float)estimatedtax + (float)shippingfee;
                    string invoiceno = "PUR" + datetime.ToString("yyyymmddhhmmss") + userid;
                    var invoiceheader = new tblSupplierInvoice();
                    invoiceheader.SupplierID = (int)supplierid;
                    invoiceheader.CompanyID = companyid;
                    invoiceheader.BranchID = branchid;
                    invoiceheader.InvoiceNo = invoiceno;
                    invoiceheader.TotalAmount = totalamount;
                    invoiceheader.InvoiceDate = datetime;
                    invoiceheader.Description = " ";
                    invoiceheader.UserID = userid;
                    invoiceheader.subtotalamount = subtotal;
                    invoiceheader.estimatedtax = (float)estimatedtax;
                    invoiceheader.shippingfee = (float)shippingfee;
                    DB.tblSupplierInvoices.Add(invoiceheader);
                    DB.SaveChanges();
                    var purchasestock = DB.tblPurchaseCartDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();
                  
                    foreach (var product in purchasestock)
                    {
                        var purchaseitem = new tblSupplierInvoiceDetail();




                        purchaseitem.SupplierInvoiceID = invoiceheader.SupplierInvoiceID;
                        purchaseitem.ProductID = product.ProductID;
                        purchaseitem.PurchaseQuantity = product.PurchaseQuantity;
                        purchaseitem.purchaseUnitPrice = product.purchaseUnitPrice;
                        purchaseitem.previouspurchaseunitprice = product.PreviousPurchaseUnitPrice;
                        purchaseitem.manufacturedate = (DateTime)product.ManufactureDate;
                        purchaseitem.expirydate = (DateTime)product.ExpiryDate;
                        DB.tblSupplierInvoiceDetails.Add(purchaseitem);
                        DB.SaveChanges();





                        var stockproduct = DB.tblStocks.Find(product.ProductID);
                        stockproduct.Manufacture = (DateTime)product.ManufactureDate;
                        stockproduct.ExpiryDate = (DateTime)product.ExpiryDate;
                        stockproduct.Quantity = stockproduct.Quantity + product.PurchaseQuantity;
                        stockproduct.CurrentPurchaseUnitPrice = product.purchaseUnitPrice;
                        stockproduct.SaleUnitPrice = (double)product.SaleUnitPrice;
                        DB.Entry(stockproduct).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();       }
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
                    var debitentry = DB.tblAccountSettings.Where(s => s.AccountActivityID == 3 && s.CompanyID == companyid && s.BranchID == branchid).FirstOrDefault();
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
                    setdebitentry.Credit = 0;
                    setdebitentry.Debit = totalamount;
                    setdebitentry.TransectionDate = datetime;
                    setdebitentry.TransectionTitle = "Purchase Form" + supplier.SupplierName;
                    setdebitentry.UserID = userid;
                    DB.tblTransactions.Add(setdebitentry);
                    DB.SaveChanges();



                    //Credit Entry
                    var creditentry = DB.tblAccountSettings.Where(s => s.AccountActivityID == 7 && s.CompanyID == companyid && s.BranchID == branchid).FirstOrDefault();
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
                    setcreditentry.Credit = totalamount;
                    setcreditentry.Debit = 0;
                    setcreditentry.TransectionDate = datetime;
                    setcreditentry.TransectionTitle = "Purchase Payment is pending(" + supplier.SupplierName + ")";
                    setcreditentry.UserID = userid;
                    DB.tblTransactions.Add(setcreditentry);
                    DB.SaveChanges();





                    if (ispaymentispaid == true)
                    {
                        invoiceno = "PPP" + DateTime.Now.ToString("yyyymmddhhmmss") + userid;
                        var incoicepayment = new tblSupplierPayment();




                        incoicepayment.SupplierID = (int)supplierid;
                        incoicepayment.SupplierInvoiceID = invoiceheader.SupplierInvoiceID;
                        incoicepayment.CompanyID = companyid;
                        incoicepayment.BranchID = branchid;
                        incoicepayment.InvoiceNo = invoiceno;
                        incoicepayment.TotalAmount = totalamount;
                        incoicepayment.PaymentAmount = totalamount;
                        incoicepayment.RemainingBalance = 0;
                        incoicepayment.UserID = userid;
                        incoicepayment.InvoiceDate = DateTime.Now;
                        DB.tblSupplierPayments.Add(incoicepayment);
                        DB.SaveChanges();




                        //Payment Debit Transaction :Purchase Payment Pending
                            debitentry = DB.tblAccountSettings.Where(s => s.AccountActivityID == 6 && s.CompanyID == companyid && s.BranchID == branchid).FirstOrDefault();
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
                        setdebitentry.Credit = 0;
                        setdebitentry.Debit = totalamount;
                        setdebitentry.TransectionDate = datetime;
                        setdebitentry.TransectionTitle = "Purchase Payment is Trasnfer(" + supplier.SupplierName+ ")";
                        setdebitentry.UserID = userid;
                        DB.tblTransactions.Add(setdebitentry);
                        DB.SaveChanges();




                        //Payment Credit Entry : Purchse Payment Paid
                        creditentry = DB.tblAccountSettings.Where(s => s.AccountActivityID == 7 && s.CompanyID == companyid && s.BranchID == branchid).FirstOrDefault();
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
                        setcreditentry.Credit = totalamount;
                        setcreditentry.Debit = 0;
                        setcreditentry.TransectionDate = datetime;
                        setcreditentry.TransectionTitle = "Purchase Payment is Paid(" + supplier.SupplierName + ")";
                        setcreditentry.UserID = userid;
                        DB.tblTransactions.Add(setcreditentry);
                        DB.SaveChanges();

                    }

                    DB.Database.ExecuteSqlCommand("TRUNCATE TABLE tblPurchaseCartDetail");
                    transaction.Commit();
                    return RedirectToAction("PrintPurchaseInvoice", new { supplierinvoiceid = invoiceheader.SupplierInvoiceID });
                }
                catch (Exception)
            {
                    transaction.Rollback();
            }

        }
            

            return View();
        }

        public ActionResult PrintPurchaseInvoice(int? supplierinvoiceid)
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
            var supplierinvoice = DB.tblSupplierInvoices.Find(supplierinvoiceid);

            var purchaseinvoice = new PrintPurchaseInvoiceMV();

            // Set Purchase Invoice Header Detail
            var invoiceheader = new SupplierInvoiceMV();

            invoiceheader.SupplierInvoiceID = supplierinvoice.SupplierInvoiceID;
            invoiceheader.SupplierID = supplierinvoice.SupplierID;
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
            var supplier = new SupplierMV();
            supplier.SupplierName = supplierinvoice.tblSupplier.SupplierName;
            supplier.SupplierConatctNo = supplierinvoice.tblSupplier.SupplierConatctNo;
            supplier.SupplierAddress = supplierinvoice.tblSupplier.SupplierAddress;
            supplier.SupplierEmail = supplierinvoice.tblSupplier.SupplierEmail;
            purchaseinvoice.supplier = supplier;





            var purchaseitem = new List<SupplierInvoiceDetailMV>();
            foreach (var item in supplierinvoice.tblSupplierInvoiceDetails)
            {
                var product = new SupplierInvoiceDetailMV();
                product.SupplierInvoiceDetailID = item.SupplierInvoiceDetailID;
                product.SupplierInvoiceID = item.SupplierInvoiceID;
                product.ProductID = item.ProductID;
                product.ProductName = item.tblStock.ProductName;
                product.PurchaseQuantity = item.PurchaseQuantity;
                product.purchaseUnitPrice = item.purchaseUnitPrice;
                product.previouspurchaseunitprice = item.previouspurchaseunitprice;
                product.manufacturedate = item.manufacturedate;
                product.expirydate = item.expirydate;
                product.ItemCost = (item.PurchaseQuantity * item.purchaseUnitPrice);
                purchaseitem.Add(product);
            }
            purchaseinvoice.InvoiceDetails = purchaseitem;
            return View(purchaseinvoice);
        }
        


        public ActionResult AllPurchases()
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

            var purchaselist = new List<PrintPurchaseInvoiceMV>();
            var allpurchases = DB.tblSupplierInvoices.Where(s => s.CompanyID == companyid && s.BranchID == branchid);
            foreach (var supplierinvoice in allpurchases)
            {
                var purchaseinvoice = new PrintPurchaseInvoiceMV();

                // Set Purchase Invoice Header Detail
                var invoiceheader = new SupplierInvoiceMV();

                invoiceheader.SupplierInvoiceID = supplierinvoice.SupplierInvoiceID;
                invoiceheader.SupplierID = supplierinvoice.SupplierID;
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
                var supplier = new SupplierMV();
                supplier.SupplierName = supplierinvoice.tblSupplier.SupplierName;
                supplier.SupplierConatctNo = supplierinvoice.tblSupplier.SupplierConatctNo;
                supplier.SupplierAddress = supplierinvoice.tblSupplier.SupplierAddress;
                supplier.SupplierEmail = supplierinvoice.tblSupplier.SupplierEmail;
                purchaseinvoice.supplier = supplier;





                var purchaseitem = new List<SupplierInvoiceDetailMV>();
                foreach (var item in supplierinvoice.tblSupplierInvoiceDetails)
                {
                    var product = new SupplierInvoiceDetailMV();
                    product.SupplierInvoiceDetailID = item.SupplierInvoiceDetailID;
                    product.SupplierInvoiceID = item.SupplierInvoiceID;
                    product.ProductID = item.ProductID;
                    product.ProductName = item.tblStock.ProductName;
                    product.PurchaseQuantity = item.PurchaseQuantity;
                    product.purchaseUnitPrice = item.purchaseUnitPrice;
                    product.previouspurchaseunitprice = item.previouspurchaseunitprice;
                    product.manufacturedate = item.manufacturedate;
                    product.expirydate = item.expirydate;
                    product.ItemCost = (item.PurchaseQuantity * item.purchaseUnitPrice);
                    purchaseitem.Add(product);
                }

                var supplierpayment = DB.tblSupplierPayments.Where(p => p.SupplierInvoiceID == supplierinvoice.SupplierInvoiceID).ToList();
                if (supplierpayment != null)
                {
                    if (supplierpayment.Count() > 0)
                    {
                        purchaseinvoice.PaidAmount = supplierpayment.Sum(s => s.PaymentAmount);
                    }
                }
                purchaseinvoice.InvoiceDetails = purchaseitem;
                purchaselist.Add(purchaseinvoice);
            }
            return View(purchaselist);
        }
    }

}