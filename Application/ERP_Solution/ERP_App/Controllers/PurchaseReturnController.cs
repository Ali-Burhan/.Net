using DataBaseLayer;
using ERP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_App.Controllers
{
    public class PurchaseReturnController : Controller
    {
        // GET: PurchaseReturn
        private CloudERPEntities DB = new CloudERPEntities();
        // GET: Purchase
        public ActionResult PurchaseReturnStockProducts( )
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
            var stock = DB.tblPurchaseCartReturnDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();
            var saleitems = new PurchaseReturnCartMV();
            var list = new List<PurchaseReturnItemMV>();
            double extax = 0;
            double subTotal = 0;
            foreach (var product in stock)
            {
                var item = new PurchaseReturnItemMV();
                //  item.BranchID = product.BranchID;
                //  item.CategoryID = product.CategoryID;
                // item.CompanyID = product.CompanyID;
                item.CreatedBy = product.tblUser.UserName;
                item.PreviousPurchaseUnitPrice = product.PreviousPurchaseUnitPrice;
                item.Description = product.Description;
                item.ExpiryDate = product.ExpiryDate;
                item.ManufactureDate = product.ManufactureDate;
                // item.IsActive = product.IsActive;
                item.ProductID = product.ProductID;
                item.ProductName = product.tblStock.ProductName;
                item.PurchaseQuantity = product.PurchaseQuantity;
                item.purchaseUnitPrice = (double)product.purchaseUnitPrice;
                item.PurchaseCartReturnDetailID = product.PurchaseCartReturnDetail;
                item.UserID = product.UserID;
                item.CategoryName = product.tblStock.tblCategory.categoryName;
                list.Add(item);
                subTotal = subTotal + ((double)product.purchaseUnitPrice * product.PurchaseQuantity);
                extax = (subTotal * 17) / 100;
            }
            saleitems.SaleItemList = list;
            saleitems.OrderSummary = new PurchaseReturnOrderSummaryMV() { SubTotal = subTotal, EstimateTax = extax };
            ViewBag.ProductID = new SelectList(DB.tblStocks.Where(s => s.BranchID == branchid && s.CompanyID == companyid && s.ProductTypeID == 1).ToList(), "ProductID", "ProductName", "0");
            ViewBag.SupplierID = new SelectList(DB.tblSuppliers.Where(s => s.BranchID == branchid && s.CompanyID == companyid).ToList(), "SupplierID", "SupplierName", "0");

            return View(saleitems);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseReturnStockProducts(PurchaseReturnCartMV salecartMV)
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
                var checkproductincart = DB.tblPurchaseCartReturnDetails.Where(i => i.ProductID == salecartMV.ProductID && i.CompanyID == companyid && i.BranchID == branchid && i.UserID == userid && i.ProductTypeID == 1).FirstOrDefault();
                if (checkproductincart == null)
                {
                    var item = new tblPurchaseCartReturnDetail();
                    
                    item.BranchID = branchid;
                    item.CompanyID = companyid;
                    item.ProductID = salecartMV.ProductID;
                    item.PurchaseQuantity = salecartMV.PurchaseQuantity;
                    item.purchaseUnitPrice = salecartMV.purchaseUnitPrice;
                    item.PreviousPurchaseUnitPrice = salecartMV.PreviousPurchaseUnitPrice;
                    item.ManufactureDate = salecartMV.ManufactureDate;
                    item.ExpiryDate = salecartMV.ExpiryDate;
                    item.Description = salecartMV.Description;
                    item.UserID = userid;
                    DB.tblPurchaseCartReturnDetails.Add(item);
                    DB.SaveChanges();
                    return RedirectToAction("PurchaseReturnStockProducts");
                }
                else { ModelState.AddModelError("ProductID", "Already in the cart!"); }
            }
            var stock = DB.tblPurchaseCartReturnDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();
            var purchaseitems = new PurchaseReturnCartMV();
            var list = new List<PurchaseReturnItemMV>();
            foreach (var product in stock)
            {
                var item = new PurchaseReturnItemMV();
                //  item.BranchID = product.BranchID;
                //  item.CategoryID = product.CategoryID;
                // item.CompanyID = product.CompanyID;
                item.CreatedBy = product.tblUser.UserName;
                item.PreviousPurchaseUnitPrice = product.PreviousPurchaseUnitPrice;
                item.Description = product.Description;
                item.ExpiryDate = product.ExpiryDate;
                item.ManufactureDate = product.ManufactureDate;
                // item.IsActive = product.IsActive;
                item.ProductID = product.ProductID;
                item.ProductName = product.tblStock.ProductName;
                item.PurchaseQuantity = product.PurchaseQuantity;
                item.purchaseUnitPrice = (double)product.purchaseUnitPrice;
                item.PurchaseCartReturnDetailID = product.PurchaseCartReturnDetail;
                item.UserID = product.UserID;
                item.CategoryName = product.tblStock.tblCategory.categoryName;
                list.Add(item);
            }
            salecartMV.SaleItemList = list;
            ViewBag.ProductID = new SelectList(DB.tblStocks.Where(s => s.BranchID == branchid && s.CompanyID == companyid && s.ProductTypeID == 1).ToList(), "ProductID", "ProductName", salecartMV.ProductID);
            ViewBag.SupplierID = new SelectList(DB.tblSuppliers.Where(s => s.BranchID == branchid && s.CompanyID == companyid).ToList(), "SupplierID", "SupplierName", salecartMV.SupplierID);
            return View(salecartMV);
        }
  public ActionResult DeletePurchaseReturnCartItem(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var pitem = DB.tblPurchaseCartReturnDetails.Find(id);
            DB.Entry(pitem).State = System.Data.Entity.EntityState.Deleted;
            DB.SaveChanges();
            return RedirectToAction("PurchaseReturnStockProducts");
        }
        public ActionResult CheckoutPurchase(int? supplierid, bool ispaymentispaid,
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
                    var customer = DB.tblSuppliers.Find(supplierid);
                    if (customer == null)
                    {
                        ModelState.AddModelError("SupplierID", "Please Select Supplier");
                        transaction.Rollback();
                    }
                    float totalamount = (float)subtotal + (float)estimatedtax + (float)shippingfee;
                    string invoiceno = "PRN" + datetime.ToString("yyyymmddhhmmss") + userid;
                    var invoiceheader = new tblSupplierReturnInvoice();
                    invoiceheader.SupplierID = (int)supplierid;
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
                    DB.tblSupplierReturnInvoices.Add(invoiceheader);
                    DB.SaveChanges();
                    var purchasestock = DB.tblPurchaseCartReturnDetails.Where(p => p.CompanyID == companyid && p.BranchID == branchid && p.UserID == userid).ToList();

                    foreach (var product in purchasestock)
                    {
                        var purchaseitem = new tblSupplierReturnInvoiceDetail();
                        purchaseitem.SupplierReturnInvoiceID = invoiceheader.SupplierReturnInvoiceID;
                        purchaseitem.ProductID = product.ProductID;
                        purchaseitem.PurchaseReturnQuantity = product.PurchaseQuantity;
                        purchaseitem.PurchaseReturnUnitPrice = product.purchaseUnitPrice;
                        DB.tblSupplierReturnInvoiceDetails.Add(purchaseitem);
                        DB.SaveChanges();





                        var stockproduct = DB.tblStocks.Find(product.ProductID);
                        stockproduct.Manufacture = (DateTime)product.ManufactureDate;
                        stockproduct.ExpiryDate = (DateTime)product.ExpiryDate;
                        stockproduct.Quantity = stockproduct.Quantity - product.PurchaseQuantity;
                        stockproduct.CurrentPurchaseUnitPrice = product.purchaseUnitPrice;
                        stockproduct.SaleUnitPrice = (double)product.purchaseUnitPrice;
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
                    setdebitentry.Credit = totalamount;
                    setdebitentry.Debit = 0;
                    setdebitentry.TransectionDate = datetime;
                    setdebitentry.TransectionTitle = "Purchase Return Form" + customer.SupplierName;
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
                    setcreditentry.Credit = 0;
                    setcreditentry.Debit = totalamount;
                    setcreditentry.TransectionDate = datetime;
                    setcreditentry.TransectionTitle = "Purchase Return Payment is pending(" + customer.SupplierName + ")";
                    setcreditentry.UserID = userid;
                    DB.tblTransactions.Add(setcreditentry);
                    DB.SaveChanges();





                    if (ispaymentispaid == true)
                    {
                        invoiceno = "SPP" + DateTime.Now.ToString("yyyymmddhhmmss") + userid;
                        var incoicepayment = new tblSupplierReturnPayment();




                        incoicepayment.SupplierID = (int)supplierid;
                        incoicepayment.SupplierReturnInvoiceID = invoiceheader.SupplierReturnInvoiceID;
                        incoicepayment.SupplierInvoiceID = invoiceheader.SupplierInvoiceID;
                        incoicepayment.CompanyID = companyid;
                        incoicepayment.BranchID = branchid;
                        incoicepayment.InvoiceNo = invoiceno;
                        incoicepayment.TotalAmount = totalamount;
                        incoicepayment.PaymentAmount = totalamount;
                        incoicepayment.RemainingBalance = 0;
                        incoicepayment.UserID = userid;
                        incoicepayment.InvoiceDate = DateTime.Now;
                        DB.tblSupplierReturnPayments.Add(incoicepayment);
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
                        setdebitentry.Credit = totalamount;
                        setdebitentry.Debit = 0;
                        setdebitentry.TransectionDate = datetime;
                        setdebitentry.TransectionTitle = "Purchase Return Payment is Transfer(" + customer.SupplierName + ")";
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
                        setcreditentry.Credit = 0;
                        setcreditentry.Debit = totalamount;
                        setcreditentry.TransectionDate = datetime;
                        setcreditentry.TransectionTitle = "Purchase Return Payment is Paid(" + customer.SupplierName + ")";
                        setcreditentry.UserID = userid;
                        DB.tblTransactions.Add(setcreditentry);
                        DB.SaveChanges();
                    }

                    DB.Database.ExecuteSqlCommand("TRUNCATE TABLE tblPurchaseCartReturnDetail");
                    transaction.Commit();
                    return RedirectToAction("PrintPurchaseReturnInvoice", new { supplierinvoiceid = invoiceheader.SupplierReturnInvoiceID });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

            }

            return View();
        }
        public ActionResult PrintPurchaseReturnInvoice(int? supplierinvoiceid)
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
            var supplierinvoice = DB.tblSupplierReturnInvoices.Find(supplierinvoiceid);

            var purchaseinvoice = new PrintPurchaseReturnMV();

            // Set Purchase Invoice Header Detail
            var invoiceheader = new SupplierReturnInvoiceMV();
            invoiceheader.SupplierReturnInvoiceID = supplierinvoice.SupplierReturnInvoiceID;
           
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





            var purchaseitem = new List<SupplierReturnInvoiceDetailMV>();
            foreach (var item in supplierinvoice.tblSupplierReturnInvoiceDetails)
            {
                var product = new SupplierReturnInvoiceDetailMV();
                product.SupplierReturnInvoiceDetailID = item.SupplierReturnInvoiceDetailID;
                product.SupplierReturnInvoiceID = item.SupplierReturnInvoiceID;
                product.ProductID = item.ProductID;
                product.ProductName = item.tblStock.ProductName;
                product.PurchaseReturnQuantity = item.PurchaseReturnQuantity;
                product.PurchaseReturnUnitPrice = item.PurchaseReturnUnitPrice;
                product.ItemCost = (item.PurchaseReturnQuantity * item.PurchaseReturnUnitPrice);
                purchaseitem.Add(product);
            }
            purchaseinvoice.InvoiceDetails = purchaseitem;
            return View(purchaseinvoice);
        }



        public ActionResult AllReturnPurchases()
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

            var purchaselist = new List<PrintPurchaseReturnMV>();
            var allpurchases = DB.tblSupplierReturnInvoices.Where(s => s.CompanyID == companyid && s.BranchID == branchid);
            foreach (var supplierinvoice in allpurchases)
            {
                var purchaseinvoice = new PrintPurchaseReturnMV();

                // Set Purchase Invoice Header Detail
                var invoiceheader = new SupplierReturnInvoiceMV();
                invoiceheader.SupplierReturnInvoiceID = supplierinvoice.SupplierReturnInvoiceID;
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





                var purchaseitem = new List<SupplierReturnInvoiceDetailMV>();
                foreach (var item in supplierinvoice.tblSupplierReturnInvoiceDetails)
                {
                    var product = new SupplierReturnInvoiceDetailMV();
                    product.SupplierReturnInvoiceDetailID = item.SupplierReturnInvoiceDetailID;
                    product.SupplierReturnInvoiceID = item.SupplierReturnInvoiceID;
                    product.ProductID = item.ProductID;
                    product.ProductName = item.tblStock.ProductName;
                    product.PurchaseReturnQuantity = item.PurchaseReturnQuantity;
                    product.PurchaseReturnUnitPrice = item.PurchaseReturnUnitPrice;
                    product.ItemCost = (item.PurchaseReturnQuantity * item.PurchaseReturnUnitPrice);
                    purchaseitem.Add(product);
                }

                var supplierpayment = DB.tblSupplierReturnPayments.Where(p => p.SupplierReturnInvoiceID == supplierinvoice.SupplierReturnInvoiceID).ToList();
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