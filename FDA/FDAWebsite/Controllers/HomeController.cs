using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDAWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EstablishmentMenuItems()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Registration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Restaurants()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Menu(int Id)
        {
            ViewBag.Message = Id;

            return View();
        }

        public ActionResult MenuItem()
        {
            //ViewBag.Message = Id;

            return View();
        }

        public ActionResult Orders()
        {

            return View();
        }
        public ActionResult PlaceOrder()
        {

            return View();
        }

        public ActionResult ManageRestaurants()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
      
    }
}