using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace AutomationResearch.ViewModels.Admin
{
    public class RegisterViewModel
    {


        [Display(AutoGenerateField = false)]
        public string UserId { get; set; }

        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "{0} باید حداقل 2 و حداکثر 100 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "از کاراکترهای غیرمجاز استفاده نکنید.")]
        public string FName { get; set; }

        [Display(Name = "فامیلی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [StringLength(maximumLength: 250, MinimumLength = 2, ErrorMessage = "{0} باید حداقل 2 و حداکثر 250 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "از کاراکترهای غیرمجاز استفاده نکنید.")]
        public string LName { get; set; }



        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 40, MinimumLength = 4, ErrorMessage = "{0} باید حداقل 4 و حداکثر 40 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "از کاراکترهای غیرمجاز استفاده نکنید.")]
        [Remote("IsUserNameInUse", "UserManager", HttpMethod = "POST")]
        public string UserName { get; set; }

        [Display(Name = "کدملی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [MinLength(10, ErrorMessage = "{0} باید 10 رقمی باشد")]
        [MaxLength(10, ErrorMessage = "{0} باید 10 رقمی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "فرمت {0} صحیح نیست.")]
        public string MelliCode { get; set; }



        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Display(Name = "تکرار گذرواژه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "گذرواژه ها مطابقت ندارند")]
        public string ConfirmPassword { get; set; }



        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [EmailAddress(ErrorMessage = "قالب ایمیل درست نیست")]
        public string Email { get; set; }



        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(11, ErrorMessage = "{0} باید 11 رقمی باشد")]
        [MaxLength(11, ErrorMessage = "{0} باید 11 رقمی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "فرمت {0} صحیح نیست.")]
        public string PhoneNumber { get; set; }

    }
}