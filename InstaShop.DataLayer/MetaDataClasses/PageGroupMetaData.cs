using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaShop.DataLayer.Models
{
   public class PageGroupMetaData
    {
        [Key]
        public int GroupID { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکترهای ورودی {0} نباید بیشتر از 250 کاراکتر باشد")]
        public string GroupTitle { get; set; }
    }

    [MetadataType(typeof(PageGroupMetaData))]
    public partial class PageGroup
    {

    }
}
