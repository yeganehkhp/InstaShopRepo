using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InstaShop.DataLayer.Models
{
    public class PageMetaData
    {
        [Key]
        public int PageID { get; set; }

        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupID { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 250 کاراکتر باشد")]
        public string Username { get; set; }

        [Display(Name = "نام صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 250 کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "تصویر پروفایل")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 250 کاراکتر باشد")]
        public string ProfileImage { get; set; }

        [Display(Name = "شماره تلفن")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 50 کاراکتر باشد")]
        public string Phone { get; set; }

        [Display(Name = "بایو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 1000 کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Bio { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "اسلایدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "بازدید")]
        public Nullable<int> Visit { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(2000, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 2000 کاراکتر باشد")]
        public string Tags { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public Nullable<System.DateTime> CreateDate { get; set; }
    }

    [MetadataType(typeof(PageMetaData))]
    public partial class Page
    {

    }
}
