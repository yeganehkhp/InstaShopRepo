using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaShop.DataLayer.Models
{
    public class AdminLoginMetaData
    {
        [Key]
        public int LoginID { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 200 کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 250 کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 200 کاراکتر باشد")]
        public string Password { get; set; }
    }

    [MetadataType(typeof(AdminLoginMetaData))]
    public partial class AdminLogin
    {

    }
}
