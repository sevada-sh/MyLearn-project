using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.ViewModels.Accounts
{
    public class LoginViewModel
    {
        //[Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        //[StringLength(100)]
        //public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [EmailAddress]
        [StringLength(250)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [DataType(DataType.Password)]
        [StringLength(250)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }

        //public bool IsAdmin { get; set; }

        //public bool IsWriter { get; set; }

        //public bool IsTeacher { get; set; }

        //public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
