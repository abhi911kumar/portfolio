using Portfolio.Helpers;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class UtilityController : Controller
    {
        //
        // POST: /Utility/SendMail
        [HttpPost]
        public JsonResult SendMail(ConnectMailViewModel mailModel)
        {
            if (ModelState.IsValid)
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableMailFeature"]))
                {
                    MailingModel mailingModel = new MailingModel();
                    mailingModel.MailSubject = "Quick Connect Mail";
                    mailingModel.MailBody = PopulateBody(mailModel);
                    mailingModel.MailTo = ConfigurationManager.AppSettings["EmailTo"];
                    MailHelper mailHelper = new MailHelper();
                    mailHelper.SendMail(mailingModel);
                }
                return Json(new { Status = "Success", Message = "Message Sent Successfully !!" });
            }
            else
            {
                return Json(new { Status = "Error", Message = "Message Sending Failed. Please try again Later!!" });
            }
        }

        private string PopulateBody(ConnectMailViewModel mailModel)
        {
            ViewData.Model = mailModel;
            var sw = new StringWriter();
            var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, "_QuickConnectEmailTemplate");
            var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
            viewResult.View.Render(viewContext, sw);
            viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

            string htmlstring = sw.GetStringBuilder().ToString();
            
            return htmlstring;
        }
    }
}