using System;
using DataBaseLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP_App.Models;

namespace ERP_App.Controllers
{
    public class UserController : Controller
    {
        private CloudERPEntities DB = new CloudERPEntities();

        public List<tblUserType> usertypes { get; private set; }

        // GET: User
        public ActionResult AllUserTypes()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            if(usertypeid != 1)
            {
                return RedirectToAction("Admin", "Dashboard");
            }
            var list = new List<UserTypeMV>();
            var usertypes = DB.tblUserTypes.ToList();
            foreach (var usertype in usertypes)
            {
                list.Add(new UserTypeMV() { UserTypeID = usertype.UserTypeID, UserType = usertype.UserType });
            }
            return View(list);
        }

        public ActionResult CreateUserType()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            if (usertypeid != 1)
            {
                return RedirectToAction("Admin", "Dashboard");
            }
            var usertypemv = new UserTypeMV();
            return View(usertypemv);
        }  
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserType(UserTypeMV usertypemv)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            if (usertypeid != 1)
            {
                return RedirectToAction("Admin", "Dashboard");
            }
            if (ModelState.IsValid)
            {
                var checkusertype = DB.tblUserTypes.Where(u => u.UserType == usertypemv.UserType.Trim()).FirstOrDefault();
                if (checkusertype == null)
                {
                    var newusertype = new tblUserType();
                    newusertype.UserType = usertypemv.UserType;
                    DB.tblUserTypes.Add(newusertype);
                    DB.SaveChanges();
                    return RedirectToAction("AllUserTypes");
                }
                else
                {
                    ModelState.AddModelError("UserType", "Already Exists");
                }
            }
            return View(usertypemv);
        }

        public ActionResult EditUserType(int? usertypeid)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeID = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeID);
            if (usertypeID != 1)
            {
                return RedirectToAction("Admin", "Dashboard");
            }

            var editusertype = DB.tblUserTypes.Find(usertypeid);
            var usertypemv = new UserTypeMV();
            usertypemv.UserTypeID = editusertype.UserTypeID;
            usertypemv.UserType = editusertype.UserType;
            return View(usertypemv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserType(UserTypeMV usertypemv)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            if (usertypeid != 1)
            {
                return RedirectToAction("Admin", "Dashboard");
            }
            if (ModelState.IsValid)
            {
                var checkusertype = DB.tblUserTypes.Where(u => u.UserType == usertypemv.UserType.Trim()  && u.UserTypeID != usertypemv.UserTypeID).FirstOrDefault();
                if (checkusertype == null)
                {
                    var editusertypes = new tblUserType();
                    editusertypes.UserType = usertypemv.UserType;
                    editusertypes.UserTypeID = usertypemv.UserTypeID;
                    DB.Entry(editusertypes).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();
                    return RedirectToAction("AllUserTypes");
                }
                else
                {
                    ModelState.AddModelError("UserType", "Already Exists");
                }
            }
            return View(usertypemv);
        }

    }
}