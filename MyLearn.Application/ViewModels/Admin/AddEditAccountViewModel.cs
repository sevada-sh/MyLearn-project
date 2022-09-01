using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.ViewModels.Admin
{
    public class AddEditAccountViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [StringLength(100)]
        [Display(Name = "نام کاربر")]
        public string UserName { get; set; }

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

        [Display(Name = "آیا ادمین است؟")]
        public bool IsAdmin { get; set; }

        [Display(Name = "آیا نویسنده است؟")]
        public bool IsWriter { get; set; }

        [Display(Name = "آیا معلم است؟")]
        public bool IsTeacher { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "عکس کاربر")]
        public IFormFile AccountImage { get; set; }
    }
}
