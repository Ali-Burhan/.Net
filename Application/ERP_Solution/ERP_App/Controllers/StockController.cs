using DataBaseLayer;
using ERP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_App.Controllers
{
    public class StockController : Controller
    {

        private CloudERPEntities DB = new CloudERPEntities();
        // GET: Stock
        public ActionResult AllCategories()
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


            var list = new List<CatagoryMV>();
            var categories = DB.tblCategories.Where(c => c.CompanyID == companyid && c.BranchID == branchid).ToList();
            foreach (var category in categories)
            {
                var username = category.tblUser.UserName;
                list.Add(new CatagoryMV()
                {
                    BranchID = category.BranchID,
                    CategoryID = category.CategoryID,
                    categoryName = category.categoryName,
                    CompanyID = category.CompanyID,
                    UserID = category.UserID,
                    CreatedBy = username
                });
            }
            return View(list);
        }
        public ActionResult CreateCategory()
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

            var categorymv = new CatagoryMV();
            return View(categorymv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CatagoryMV categoryMV)
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
                var checkcategory = DB.tblCategories.Where(u => u.categoryName == categoryMV.categoryName.Trim() && u.CompanyID == companyid && u.BranchID == branchid).FirstOrDefault();
                if (checkcategory == null)
                {
                    var newcategory = new tblCategory();
                    newcategory.CompanyID = companyid;
                    newcategory.BranchID = branchid;
                    newcategory.categoryName = categoryMV.categoryName;
                    newcategory.UserID = userid;
                    DB.tblCategories.Add(newcategory);
                    DB.SaveChanges();
                    return RedirectToAction("AllCategories");
                }
                else
                {
                    ModelState.AddModelError("categoryName", "Already Exist!");
                }
            }
            return View(categoryMV);
        }
        public ActionResult EditCategory(int? categoryID)
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
            var category = DB.tblCategories.Find(categoryID);
            var categorymv = new CatagoryMV();
            categorymv.CategoryID = category.CategoryID;
            categorymv.BranchID = category.BranchID;
            categorymv.categoryName = category.categoryName;
            categorymv.CompanyID = category.CompanyID;
            categorymv.BranchID = category.BranchID;
            return View(categorymv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(CatagoryMV categoryMV)
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
                var checkcategory = DB.tblCategories.Where(u => u.categoryName == categoryMV.categoryName.Trim() && u.CategoryID != categoryMV.CategoryID && u.CompanyID == companyid && u.BranchID == branchid).FirstOrDefault();
                if (checkcategory == null)
                {
                    var editcategory = DB.tblCategories.Find(categoryMV.CategoryID);
                    editcategory.categoryName = categoryMV.categoryName;
                    editcategory.UserID = userid;

                    DB.Entry(editcategory).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();
                    return RedirectToAction("AllCategories");
                }
                else
                {
                    ModelState.AddModelError("categoryName", "Already Exist!");
                }
            }
            return View(categoryMV);
        }
        public ActionResult StockProducts()
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
            var stock = DB.tblStocks.Where(p => p.CompanyID == companyid && p.BranchID == branchid).ToList();
            var list = new List<StockMV>();
            foreach (var product in stock)
            {
                var item = new StockMV();
                item.BranchID = product.BranchID;
                item.CategoryID = product.CategoryID;
                item.CompanyID = product.CompanyID;
                item.CreateBy = product.tblUser.UserName;
                item.CurrentPurchaseUnitPrice = product.CurrentPurchaseUnitPrice;
                item.Description = product.Description;
                item.ExpiryDate = product.ExpiryDate;
                item.Manufacture = product.Manufacture;
                item.IsActive = product.IsActive;
                item.ProductID = product.ProductID;
                item.ProductName = product.ProductName;
                item.Quantity = product.Quantity;
                item.SaleUnitPrice = product.SaleUnitPrice;
                item.StockTreshHoldQuantity = product.StockTreshHoldQuantity;
                item.UserID = product.UserID;
                item.CategoryName = product.tblCategory.categoryName;
                list.Add(item);
            }
            return View(list);
        }
        public ActionResult CreateProduct()
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

            var stockmv= new StockMV();
            ViewBag.CategoryID = new SelectList(DB.tblCategories.Where(c => c.CompanyID == companyid && c.BranchID == branchid), "CategoryID", "CategoryName", stockmv.CompanyID);
            ViewBag.ProductTypeID = new SelectList(DB.tblProductTypes.ToList(), "ProductTypeID", "ProductTypeName", stockmv.ProductTypeID);
            return View(stockmv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(StockMV stockmv)
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
                var checkproduct = DB.tblStocks.Where(u => u.ProductName == stockmv.ProductName.Trim()&& u.CategoryID == stockmv.CategoryID && u.CompanyID == companyid && u.BranchID == branchid).FirstOrDefault();
                if (checkproduct == null)
                {
                    var newproduct = new tblStock();
                    newproduct.CategoryID = stockmv.CategoryID;
                    newproduct.ProductTypeID = stockmv.ProductTypeID;
                    newproduct.CompanyID = companyid;
                    newproduct.BranchID = branchid;
                    newproduct.ProductName = stockmv.ProductName;
                    newproduct.Quantity = stockmv.Quantity;
                    newproduct.SaleUnitPrice = stockmv.SaleUnitPrice;
                    newproduct.CurrentPurchaseUnitPrice = stockmv.CurrentPurchaseUnitPrice;
                    newproduct.ExpiryDate = stockmv.ExpiryDate;
                    newproduct.Manufacture = stockmv.Manufacture;
                    newproduct.StockTreshHoldQuantity = stockmv.StockTreshHoldQuantity;
                    newproduct.Description = stockmv.Description;
                    newproduct.UserID = userid;
                    newproduct.IsActive = stockmv.IsActive;
                    DB.tblStocks.Add(newproduct);
                    DB.SaveChanges();
                    return RedirectToAction("StockProducts");
                }
                else
                {
                    ModelState.AddModelError("categoryName", "Already Exist!");
                }
            }
            ViewBag.CategoryID = new SelectList(DB.tblCategories.Where(c => c.CompanyID == companyid && c.BranchID == branchid), "CategoryID", "CategoryName", stockmv.CompanyID);
            ViewBag.ProductTypeID = new SelectList(DB.tblProductTypes.ToList(), "ProductTypeID", "ProductTypeName", stockmv.ProductTypeID);
            return View(stockmv);
        }


       
        public ActionResult EditProduct(int? productID)
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

            var product = DB.tblStocks.Find(productID);
            var stockmv = new StockMV();
            stockmv.BranchID = product.BranchID;
            stockmv.CompanyID = product.CompanyID;
            stockmv.CurrentPurchaseUnitPrice = product.CurrentPurchaseUnitPrice;
            stockmv.Description = product.Description;
            stockmv.ExpiryDate = product.ExpiryDate;
            stockmv.Manufacture = product.Manufacture;
            stockmv.ProductID = product.ProductID;
            stockmv.ProductName = product.ProductName;
            stockmv.SaleUnitPrice = product.SaleUnitPrice;
            stockmv.StockTreshHoldQuantity = product.StockTreshHoldQuantity;
            stockmv.IsActive = product.IsActive;
            ViewBag.CategoryID = new SelectList(DB.tblCategories.Where(c => c.CompanyID == companyid && c.BranchID == branchid), "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.ProductTypeID = new SelectList(DB.tblProductTypes.ToList(), "ProductTypeID", "ProductTypeName", product.ProductTypeID);

            return View(stockmv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(StockMV stockmv)
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
                var checkproduct = DB.tblStocks.Where(u => u.ProductName == stockmv.ProductName.Trim() && u.CategoryID == stockmv.CategoryID && u.CompanyID == companyid && u.BranchID == branchid && u.ProductID != stockmv.ProductID).FirstOrDefault();
                if (checkproduct == null)
                {

                    var editproduct = DB.tblStocks.Find(stockmv.ProductID);
                    editproduct.ProductName = stockmv.ProductName;
                    editproduct.ProductTypeID = stockmv.ProductTypeID;
                    editproduct.SaleUnitPrice = stockmv.SaleUnitPrice;
                    editproduct.CurrentPurchaseUnitPrice = stockmv.CurrentPurchaseUnitPrice;
                    editproduct.ExpiryDate = stockmv.ExpiryDate;
                    editproduct.Manufacture = stockmv.Manufacture;
                    editproduct.StockTreshHoldQuantity = stockmv.StockTreshHoldQuantity;
                    editproduct.Description = stockmv.Description;
                    editproduct.UserID = userid;
                    editproduct.IsActive = stockmv.IsActive;
                    DB.Entry(editproduct).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();
                    return RedirectToAction("StockProducts");
                }
                else
                {
                    ModelState.AddModelError("categoryName", "Already Exist!");
                }
            }
            ViewBag.CategoryID = new SelectList(DB.tblCategories.Where(c => c.CompanyID == companyid && c.BranchID == branchid), "CategoryID", "CategoryName", stockmv.CompanyID);
            ViewBag.ProductTypeID = new SelectList(DB.tblProductTypes.ToList(), "ProductTypeID", "ProductTypeName", stockmv.ProductTypeID);

            return View(stockmv);
        }
        public JsonResult GetSelectProductDetails(int? productid)
        {
            var data = new SelectProduct();
            if (productid > 0)
            {
                var product = DB.tblStocks.Find(productid);
                data.SaleUnitPrice = product.SaleUnitPrice;
                data.CurrentPurchaseUnitPrice = product.CurrentPurchaseUnitPrice;
            }
            else
            {
                data.SaleUnitPrice = 0;
                data.CurrentPurchaseUnitPrice = 0;
            }
                return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}

class SelectProduct
{
    public double SaleUnitPrice { get; set; }
    public double CurrentPurchaseUnitPrice { get; set; }

}