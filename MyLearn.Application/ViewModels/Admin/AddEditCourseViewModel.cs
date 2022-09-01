using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.ViewModels.Admin
{
    public class AddEditCourseViewModel
    {
        [Required]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [StringLength(30)]
        [Display(Name = "نام")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [StringLength(20)]
        [Display(Name = "استاد")]
        public string CourseTeacher { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [DataType(DataType.Currency)]
        [Display(Name = "قیمت")]
        public double CoursePrice { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [StringLength(1500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "تعداد ویدیو")]
        public int CourseVideosCount { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "سطح")]
        public string CourseLevel { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "آیا دوره در حال برگزاری است؟")]
        public bool CourseIsHolding { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "تگ های دوره")]
        public string CourseTags { get; set; }

        [Display(Name = "کد تخفیف")]
        public decimal Discount { get; set; }


        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "عکس دوره")]
        public IFormFile CourseImage { get; set; }
    }
}
