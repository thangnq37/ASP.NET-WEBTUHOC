using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTHoc.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Vui lòng nhập username")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập password")]
        public string Password { set; get; }
        public bool RememberMe { get; set; }
    }
}