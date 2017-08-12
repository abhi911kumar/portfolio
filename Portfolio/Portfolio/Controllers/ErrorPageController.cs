using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ErrorIcon = "Cross.png";
            ViewBag.ErrorCode = "Error";
            ViewBag.ErrorTitle = "Error";
            ViewBag.ErrorDesc = "There was an error. Please Try again Later.";
            return PartialView("~/Views/ErrorPage/Error.cshtml");
        }

        public ActionResult Error404()
        {
            ViewBag.ErrorIcon = "Caution.png";
            ViewBag.ErrorCode = "404";
            ViewBag.ErrorTitle = "Page not found";
            ViewBag.ErrorDesc = "The requested URL/Page was not found on this server.";
            return PartialView("~/Views/ErrorPage/Error.cshtml");
        }

        public ActionResult Error500()
        {
            ViewBag.ErrorIcon = "Cross.png";
            ViewBag.ErrorCode = "500";
            ViewBag.ErrorTitle = "This is an error";
            ViewBag.ErrorDesc = "There was an error. Please try again later.";
            return PartialView("~/Views/ErrorPage/Error.cshtml");
        }

        public ActionResult IncompatibleBrowser()
        {
            return View();
        }

        public ActionResult JavaScriptDisabled()
        {
            return View();
        }
	}
}