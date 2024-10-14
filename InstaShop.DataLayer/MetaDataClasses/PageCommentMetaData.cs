using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaShop.DataLayer.Models
{
    public class PageCommentMetaData
    {
        [Key]
        public int CommentID { get; set; }

        [Display(Name = "صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PageID { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد.")]
        public string Email { get; set; }

        [Display(Name = "سایت")]
        [MaxLength(200)]
        public string WebSite { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public System.DateTime CreateDate { get; set; }

        [Display(Name = "نمایش در صفحه")]
        public Nullable<bool> ShowInPage { get; set; }
    }


    [MetadataType(typeof(PageCommentMetaData))]
    public partial class PageComment
    {

    }
}
