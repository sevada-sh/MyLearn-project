using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.ViewModels.Admin
{
    public class AddEditArticleViewModel
    {
        [Required]
        public int ArtilceId { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [StringLength(30)]
        [Display(Name = "نام")]
        public string ArticleName { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [StringLength(20)]
        [Display(Name = "نویسنده")]
        public string ArticleWriter { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [Display(Name = "متن")]
        public string ArticleText { get; set; }

        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        [DataType(DataType.Time)]
        [Display(Name = "تاریخ انتشار")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "عکس مقاله")]
        [Required(ErrorMessage = "لطفا فیلد مورد نظر را پر کنید")]
        public IFormFile ArticleImage { get; set; }
    }
}
