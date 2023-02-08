﻿using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login(string useremail, string password)
        {
            if (!string.IsNullOrEmpty(useremail))
            {
            using (CloudERPEntities db = new CloudERPEntities())
            {
                var user = db.tblUsers.Where(u => u.Email == useremail && u.Password == password && u.IsActive == true).FirstOrDefault();
                if(user == null)
                {
                    ViewBag.ErrorMessage = "Username and password is inccorrect";
                }
                else
                {
                        Session["UserID"] = user.UserID;
                        Session["UserName"] = user.UserName;
                        Session["Email"] = user.Email;
                        Session["UserTypeID"] = user.UserTypeID;
                        Session["UserType"] = user.tblUserType.UserType;
                        Session["IsActive"] = user.IsActive == true? "Active" : "No-Active";
                        if(user.UserID> 2)
                        {
                            var employee = db.tblEmployees.Where(u => u.UserID == user.UserID).FirstOrDefault();
                            if (employee == null)
                            {
                                ViewBag.ErrorMessage = "Username and password is inccorrect";
                                Logout();
                                return View();
                            }
                            else
                            {
                                Session["EmployeeID"] = employee.EmployeeID;
                                Session["EmployeeName"] = employee.Name;
                                Session["ContactNo"] = employee.ContactNo;
                                Session["Photo"] = employee.Photo;
                                Session["Email"] = employee.Email;
                                Session["Address"] = employee.Address;
                                Session["CNIC"] = employee.CNIC;
                                Session["Designation"] = employee.Designation;
                                Session["Description"] = employee.Description;
                                Session["MonthlySalary"] = employee.MonthlySalary;
                                Session["BranchID"] = employee.BranchID;
                                Session["CompanyID"] = employee.CompanyID;
                                Session["EmployeeUserID"] = employee.UserID;
                                Session["BranchTypeID"] = db.tblBranches.Find(employee.BranchID).BranchTypeID;
                            }

                            var company = db.tblCompanies.Find(employee.CompanyID);
                            if(company == null)
                            {
                                ViewBag.ErrorMessage = "Username and password is inccorrect";
                                Logout();
                                return View();
                            }
                            else
                            {
                                Session["CompanyID"] = company.CompanyID;
                                Session["Name"] = company.Name;
                                Session["Logo"] = company.Logo;
                            }
                        }
                        var usertypeid = user.UserTypeID;
                        if (user.UserTypeID == 1)
                    {
                        return RedirectToAction("Admin", "Dashboard");
                    }
                       else if (usertypeid == 2)
                        {
                            return RedirectToAction("SubAdmin", "Dashboard");
                        }
                        else if (usertypeid == 3)
                        {
                            return RedirectToAction("HeadOffice", "Dashboard");
                        }
                        else if (usertypeid == 4)
                        {
                            return RedirectToAction("HeadOfficeUser", "Dashboard");
                        }
                        else if (usertypeid == 5)
                        {
                            return RedirectToAction("BranchUser", "Dashboard");
                        }
                        else if (usertypeid == 6)
                        {
                            return RedirectToAction("BranchOperator", "Dashboard");
                        }
                    }
            }
            }
            else
            {
                ViewBag.ErrorMessage = string.Empty;
            }
            Session["UserName"] = string.Empty;
            Session["Email"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            Session["UserType"] = string.Empty;
            Session["IsActive"] = string.Empty;


            Session["EmployeeID"] = string.Empty;
            Session["EmployeeName"] = string.Empty;
            Session["ContactNo"] = string.Empty;
            Session["Photo"] = string.Empty;
            Session["Email"] = string.Empty;
            Session["Address"] = string.Empty;
            Session["CNIC"] = string.Empty;
            Session["Designation"] = string.Empty;
            Session["Description"] = string.Empty;
            Session["MonthlySalary"] = string.Empty;
            Session["BranchID"] = string.Empty;
            Session["CompanyID"] = string.Empty;
            Session["BranchTypeID"] = string.Empty;
            Session["EmployeeUserID"] = string.Empty;

            Session["CompanyID"] = string.Empty;
            Session["Name"] = string.Empty;
            Session["Logo"] = string.Empty;
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserName"] = string.Empty;
            Session["Email"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            Session["UserType"] = string.Empty;
            Session["IsActive"] = string.Empty;


            Session["EmployeeID"] = string.Empty;
            Session["EmployeeName"] = string.Empty;
            Session["ContactNo"] = string.Empty;
            Session["Photo"] = string.Empty;
            Session["Email"] = string.Empty;
            Session["Address"] = string.Empty;
            Session["CNIC"] = string.Empty;
            Session["Designation"] = string.Empty;
            Session["Description"] = string.Empty;
            Session["MonthlySalary"] = string.Empty;
            Session["BranchID"] = string.Empty;
            Session["CompanyID"] = string.Empty;
            Session["BranchTypeID"] = string.Empty;
            Session["EmployeeUserID"] = string.Empty;

            Session["CompanyID"] = string.Empty;
            Session["Name"] = string.Empty;
            Session["Logo"] = string.Empty;
            return RedirectToAction("Login");

        }
    }
}