using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class ConnectMailViewModel
    {
        [Required]
        public string SenderName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string SenderEmail { get; set; }
        [Required]
        public string SenderMessage { get; set; }
    }
}