using DataBaseLayer;
using ERP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_App.Controllers
{
    public class AccountsSettingController : Controller
    {
        private CloudERPEntities DB = new CloudERPEntities();
        // GET: AccountsSetting
        public ActionResult BranchAccountSetting()
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

            var accountsettinglist = DB.tblAccountSettings.Where(a => a.CompanyID == companyid && a.BranchID == branchid).ToList();
            var list = new List<AccountSettingMV>();
            foreach(var item in accountsettinglist)
            {
                var accountsetting = new AccountSettingMV();
                accountsetting.AccountControlID = item.AccountControlID;
                accountsetting.AccountControl = item.tblAccountControl != null? item.tblAccountControl.AccountControlName : string.Empty;
                accountsetting.AccountSettingID = item.AccountSettingID;
                accountsetting.AccountHeadID = item.AccountHeadID;
                accountsetting.AccountHead = item.tblAccountHead != null? item.tblAccountHead.AccountHeadName : string.Empty;
                accountsetting.AccountSubControlID = item.AccountSubControlID;
                accountsetting.AccountSubControl = item.tblAccountSubControl != null ? item.tblAccountSubControl.AccountSubControlName: string.Empty;
                accountsetting.AccountActivityID = item.AccountActivityID;
                accountsetting.AccountActivity = item.tblAccountActivity!= null ? item.tblAccountActivity.Name: string.Empty;
                list.Add(accountsetting);
            }
            return View(list);
        }
        public JsonResult GetAccountControls(int? accountheadID)
        {

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

            var list = new List<AccountControlMV>();
            var tblAccountControls = DB.tblAccountControls.Where(a => a.BranchID == branchid && a.CompanyID == companyid && a.AccountHeadID == accountheadID).ToList();
            foreach (var account in tblAccountControls)
            {
                var accountcontrol = new AccountControlMV();
                accountcontrol.AccountControlID = account.AccountControlID;
                accountcontrol.AccountHeadID = account.AccountHeadID;
                var accounthead = DB.tblAccountHeads.Find(account.AccountHeadID);
                accountcontrol.AccountHead = accounthead.AccountHeadName;
                accountcontrol.AccountControlName = account.AccountControlName;
                accountcontrol.UserID = account.UserID;
                accountcontrol.CreatedBy = account.tblUser.UserName;
                list.Add(accountcontrol);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAccountSubControls(int? accountcontrolID)
        {

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

            var list = new List<AccountSubControlMV>();
            var tblAccountControls = DB.tblAccountSubControls.Where(a => a.BranchID == branchid && a.CompanyID == companyid && a.AccountControlID == accountcontrolID).ToList();
            foreach (var account in tblAccountControls)
            {
                var accountcontrol = new AccountSubControlMV();
                accountcontrol.AccountSubControlID = account.AccountSubControlID;
                accountcontrol.AccountHeadID = account.AccountHeadID;
                accountcontrol.AccountSubControlName = account.AccountSubControlName;
                list.Add(accountcontrol);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateBranchAccountSetting()
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
            var accountsettingmv = new AccountSettingMV();
            accountsettingmv.CompanyID = companyid;
            accountsettingmv.BranchID = branchid;
            ViewBag.AccountHeadID = new SelectList(DB.tblAccountHeads.ToList(), "AccountHeadID", "AccountHeadName", "0");
            ViewBag.AccountControlID= new SelectList(DB.tblAccountControls.ToList(), "AccountControlID", "AccountControlName", "0");
            ViewBag.AccountSubControlID= new SelectList(DB.tblAccountSubControls.ToList(), "AccountSubControlID", "AccountSubControlName", "0");
            ViewBag.AccountActivityID= new SelectList(DB.tblAccountActivities.ToList(), "AccountActivityID", "Name", "0");
            return View(accountsettingmv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBranchAccountSetting(AccountSettingMV accountsettingmv)
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

            try
            {
                if (ModelState.IsValid)
                {
                    var checkaccountsetting = DB.tblAccountSettings.Where(e =>e.CompanyID == companyid && e.BranchID == branchid && 
                     e.AccountActivityID == accountsettingmv.AccountActivityID).FirstOrDefault();
                    if (checkaccountsetting == null)
                    {
                        var newsetting = new tblAccountSetting();
                        newsetting.AccountHeadID = accountsettingmv.AccountHeadID;
                        newsetting.AccountControlID = accountsettingmv.AccountControlID;
                        newsetting.AccountSubControlID = accountsettingmv.AccountSubControlID;
                        newsetting.AccountActivityID = accountsettingmv.AccountActivityID;
                        newsetting.CompanyID = accountsettingmv.CompanyID;
                        newsetting.BranchID = accountsettingmv.BranchID;
                        DB.tblAccountSettings.Add(newsetting);        
                        DB.SaveChanges();
                        return RedirectToAction("BranchAccountSetting");
                    }
                    else
                    {
                        ModelState.AddModelError("Account Setting", "Already Exist!");
                        ViewBag.ExistError = "Already Exist";
                    }
                }
            }
            catch (Exception )
            {
                ModelState.AddModelError("Name", "Must be Filled All Field with correct data!");
           
            }
            ViewBag.AccountHeadID = new SelectList(DB.tblAccountHeads.ToList(), "AccountHeadID", "AccountHeadName", accountsettingmv.AccountHeadID);
            ViewBag.AccountControlID = new SelectList(DB.tblAccountControls.ToList(), "AccountControlID", "AccountControlName", accountsettingmv.AccountControlID);
            ViewBag.AccountSubControlID = new SelectList(DB.tblAccountSubControls.ToList(), "AccountSubControlID", "AccountSubControlName", accountsettingmv.AccountSubControlID);
            ViewBag.AccountActivityID = new SelectList(DB.tblAccountActivities.ToList(), "AccountActivityID", "Name", accountsettingmv.AccountActivityID);
            return View(accountsettingmv);
        }






        public ActionResult EditBranchAccountSetting(int? id)
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
            var accountsetting = DB.tblAccountSettings.Find(id);
            var accountsettingmv = new AccountSettingMV();
            accountsettingmv.AccountSettingID = accountsetting.AccountSettingID;
            accountsettingmv.AccountHeadID= accountsetting.AccountHeadID;
            accountsettingmv.AccountControlID= accountsetting.AccountControlID;
            accountsettingmv.AccountSubControlID= accountsetting.AccountSubControlID;
            accountsettingmv.AccountActivityID= accountsetting.AccountActivityID;

            accountsettingmv.CompanyID = companyid;
            accountsettingmv.BranchID = branchid;
            ViewBag.AccountHeadID = new SelectList(DB.tblAccountHeads.ToList(), "AccountHeadID", "AccountHeadName", accountsetting.AccountHeadID);
            ViewBag.AccountControlID = new SelectList(DB.tblAccountControls.Where(a => a.AccountHeadID == accountsetting.AccountHeadID).ToList(), "AccountControlID", "AccountControlName", accountsetting.AccountControlID);
            ViewBag.AccountSubControlID = new SelectList(DB.tblAccountSubControls.Where(a => a.AccountControlID == accountsetting.AccountControlID).ToList(), "AccountSubControlID", "AccountSubControlName", accountsetting.AccountSubControlID);
            ViewBag.AccountActivityID = new SelectList(DB.tblAccountActivities.ToList(), "AccountActivityID", "Name", accountsetting.AccountActivityID);
            return View(accountsettingmv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBranchAccountSetting(AccountSettingMV accountsettingmv)
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

            try
            {
                if (ModelState.IsValid)
                {
                    var checkaccountsetting = DB.tblAccountSettings.Where(e => e.CompanyID == companyid && e.BranchID == branchid && e.AccountSettingID != accountsettingmv.AccountSettingID && e.AccountActivityID == accountsettingmv.AccountActivityID).FirstOrDefault();
                    if (checkaccountsetting == null)
                    {
                        var editsetting = DB.tblAccountSettings.Find(accountsettingmv.AccountSettingID);
                        editsetting.AccountHeadID = accountsettingmv.AccountHeadID;
                        editsetting.AccountControlID = accountsettingmv.AccountControlID;
                        editsetting.AccountSubControlID = accountsettingmv.AccountSubControlID;
                        editsetting.AccountActivityID = accountsettingmv.AccountActivityID;
                        DB.Entry(editsetting).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                        return RedirectToAction("BranchAccountSetting");
                    }
                    else
                    {
                        ModelState.AddModelError("Account Setting", "Already Exist!");
                        ViewBag.ExistError = "Already Exist";
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("Name", "Must be Filled All Field with correct data!");

            }
            ViewBag.AccountHeadID = new SelectList(DB.tblAccountHeads.ToList(), "AccountHeadID", "AccountHeadName", accountsettingmv.AccountHeadID);
            ViewBag.AccountControlID = new SelectList(DB.tblAccountControls.Where(a => a.AccountHeadID == accountsettingmv.AccountHeadID).ToList(), "AccountControlID", "AccountControlName", accountsettingmv.AccountControlID);
            ViewBag.AccountSubControlID = new SelectList(DB.tblAccountSubControls.Where(a => a.AccountControlID == accountsettingmv.AccountControlID).ToList(), "AccountSubControlID", "AccountSubControlName", accountsettingmv.AccountSubControlID);
            ViewBag.AccountActivityID = new SelectList(DB.tblAccountActivities.ToList(), "AccountActivityID", "Name", accountsettingmv.AccountActivityID);
            return View(accountsettingmv);
        }
    }
}