using HBSecurityMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HBSecurityMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly Db _context = new Db();

        // GET: User
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            var userToCheckEmail = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (ModelState.IsValid && userToCheckEmail == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                Response.Write("<script>alert('You have successfully signed up!');</script>");
                return RedirectToAction("Login", "User");
            }
            else
            {
                Response.Write("<script>alert('This email is being used by another user. Try another email!');</script>");
                return RedirectToAction("SignUp", "User");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                var userDb = _context.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (userDb != null)
                {
                    Session["Email"] = userDb.Email;
                    Session["Name"] = userDb.ContactName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Response.Write("<script>alert('Email or password is invalid. Try again!');</script>");
                    return View();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return View();
                throw ex;
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == Session["Email"].ToString());
            return View(user);
        }
        [HttpPost]
        public ActionResult Update(User user)
        {
            User userToUpdate = (from u in _context.Users where u.Email == user.Email select u).FirstOrDefault();

            if (userToUpdate != null)
            {
                userToUpdate.CompanyName = user.CompanyName;
                userToUpdate.ContactName = user.ContactName;
                userToUpdate.ContactTitle = user.ContactTitle;
                userToUpdate.Phone = user.Phone;
                userToUpdate.Address = user.Address;
                userToUpdate.PostalCode = user.PostalCode;
                userToUpdate.Country = user.Country;
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
                Session["Name"] = user.ContactName;
                _context.SaveChanges();

                ViewBag.Message = "User record updated.";
                Response.Write("<script>alert('User record updated successfully!');</script>");
            }
            else
            {
                ViewBag.Message = "User not found.";
            }
            return RedirectToAction("Index", "Home");

        }
    }
}