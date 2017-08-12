using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Models
{
    public class MailingModel
    {
        public string MailTo { get; set; }
        public string MailSubject { get; set; }
        public string DocString { get; set; }
        [AllowHtml]
        public string MailBody { get; set; }
    }
}