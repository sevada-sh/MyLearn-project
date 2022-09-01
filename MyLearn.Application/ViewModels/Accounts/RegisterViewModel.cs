using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.ViewModels.Accounts
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "نام کاربری")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        [StringLength(250)]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [StringLength(250)]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Compare("Password", ErrorMessage = "یا رمز عبور وارد شده همخوانی ندارد")]
        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [StringLength(250)]
        public string ConfirmPassword { get; set; }

    }
}
