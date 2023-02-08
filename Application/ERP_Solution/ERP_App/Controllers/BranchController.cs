using DataBaseLayer;
using ERP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_App.Controllers
{
    public class BranchController : Controller
    {

        private CloudERPEntities DB = new CloudERPEntities();
        public ActionResult AllCompanyBranchs()
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
            var branchs = DB.tblBranches.Where(b => b.BrchID == branchid && b.CompanyID == companyid).ToList();
            var list = new List<BranchMV>();
            foreach (var branch in branchs)
            {
                var addbranch = new BranchMV();
                addbranch.BranchID = branch.BranchID;
                addbranch.BranchTypeID = branch.BranchTypeID;
                addbranch.BranchType = branch.tblBranchType.BranchType;
                addbranch.BranchName = branch.BranchName;
                addbranch.BranchContact = branch.BranchContact;
                addbranch.BranchAddress = branch.BranchAddress;
                addbranch.CompanyID = branch.CompanyID;
                var company = DB.tblCompanies.Find(branch.CompanyID).Name;
                addbranch.Company = company;
                addbranch.BrchID = branch.BrchID;


                var employee = branch.tblEmployees.Where(b => b.Designation.ToLower().Contains("focal")).FirstOrDefault();
                if (employee != null)
                {
                    var user = DB.tblUsers.Find(employee.UserID);
                    if(user.IsActive==true)
                    {
                        addbranch.IsHaveAFocalPerson = true;
                    }
                    else
                    {
                        addbranch.IsHaveAFocalPerson = false;
                    }
                }
                else
                {
                    addbranch.IsHaveAFocalPerson = true;
                }
                list.Add(addbranch);
            }
            return View(list);
        }
        public ActionResult CreateCompanyBranch()
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



            ViewBag.BranchTypeID = new SelectList(DB.tblBranchTypes.Where(bt => bt.BranchTypeID < branchtypeid), "BranchTypeID ", "BranchType", "0");
            var branch = new BranchMV();
            branch.CompanyID = companyid;
            return View(branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompanyBranch(BranchMV branchmv)
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
                var newbranch = new tblBranch();
                newbranch.BranchName = branchmv.BranchName;
                newbranch.BranchTypeID = branchmv.BranchTypeID;
                newbranch.BranchAddress= branchmv.BranchAddress;
                newbranch.BranchContact= branchmv.BranchContact;
                newbranch.CompanyID = companyid;
                newbranch.BrchID = branchid;
                DB.tblBranches.Add(newbranch);
                DB.SaveChanges();
                return View("AllCompanyBranchs");
            }


            ViewBag.BranchTypeID = new SelectList(DB.tblBranchTypes.Where(bt => bt.BranchTypeID > branchtypeid), "BranchTypeID ", "BranchType", branchmv.BranchTypeID);
            var branch = new BranchMV();
            branch.CompanyID = companyid;
            return View(branch);
        }

        public ActionResult EditCompanyBranch(int? branchID)
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

            var editbranch = DB.tblBranches.Find(branchID);
            var branchmv = new BranchMV();
            branchmv.BranchID = editbranch.BranchID;
            branchmv.BranchTypeID = editbranch.BranchTypeID;
            branchmv.BranchType = editbranch.tblBranchType.BranchType;
            branchmv.BranchName = editbranch.BranchName;
            branchmv.BranchContact = editbranch.BranchContact;
            branchmv.BranchAddress = editbranch.BranchAddress;
            branchmv.CompanyID = editbranch.CompanyID;
            var company = DB.tblCompanies.Find(editbranch.CompanyID).Name;
            branchmv.Company = company;
            branchmv.BrchID = editbranch.BrchID;

            ViewBag.BranchTypeID = new SelectList(DB.tblBranchTypes.Where(bt => bt.BranchTypeID == branchtypeid), "BranchTypeID", "BranchType", editbranch.BranchTypeID);
            return View(branchmv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCompanyBranch(BranchMV branchmv)
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
                var editbranch = new tblBranch();
                editbranch.BranchID = branchmv.BranchID;
                editbranch.BranchName = branchmv.BranchName;
                editbranch.BranchTypeID = branchmv.BranchTypeID;
                editbranch.BranchAddress = branchmv.BranchAddress;
                editbranch.BranchContact = branchmv.BranchContact;
                editbranch.CompanyID = branchmv.CompanyID;
                editbranch.BrchID = branchmv.BrchID;
                DB.Entry(editbranch).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("AllCompanyBranchs");

            }
            ViewBag.BranchTypeID = new SelectList(DB.tblBranchTypes.Where(bt => bt.BranchTypeID == branchtypeid), "BranchTypeID", "BranchType", branchmv.BranchTypeID);
            return View(branchmv);
        }
        public ActionResult ShowBranchFocalPerson(int? branchID)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var focalperson = new FocalPersonMV();
            focalperson.employeeMV = new EmployeeMV();
            focalperson.userMV = new UserMV();
            var employees = DB.tblEmployees.Where(e => e.BranchID == branchID && e.Designation.Contains("Focal"));
            foreach (var employee in employees)
            {
                var user = DB.tblUsers.Where(u => u.UserID == employee.UserID && u.IsActive == true).FirstOrDefault();
                if (user != null)
                {
                    focalperson.CompanyID = employee.CompanyID;
                    focalperson.BranchID = employee.BranchID;
                    // Employee Detials
                    focalperson.employeeMV.Name = employee.Name;
                    focalperson.employeeMV.ContactNo = employee.ContactNo;
                    focalperson.employeeMV.Photo = employee.Photo;
                    focalperson.employeeMV.Email = employee.Email;
                    focalperson.employeeMV.Address = employee.Address;
                    focalperson.employeeMV.CNIC = employee.CNIC;
                    focalperson.employeeMV.Designation = employee.Designation;
                    focalperson.employeeMV.Description = employee.Description;
                    focalperson.employeeMV.MonthlySalary = employee.MonthlySalary;
                    // User Detials
                    focalperson.userMV.UserID = user.UserID;
                    focalperson.userMV.UserType = user.tblUserType.UserType;
                    focalperson.userMV.FullName = user.FullName;
                    focalperson.userMV.Email = user.Email;
                    focalperson.userMV.ContactNo = user.ContactNo;
                    focalperson.userMV.UserName = user.UserName;
                    focalperson.userMV.IsActive = user.IsActive;
                    focalperson.userMV.Address = user.Address;
                }
            }
            return View(focalperson);
        }
    }
}