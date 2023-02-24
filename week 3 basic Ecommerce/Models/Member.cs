using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Data;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace week_3_basic_Ecommerce.Models {
    public class Member {

        [Key]
        public int MemberId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }
    }

    public class RegisterViewModel {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 6)] //(maximum, minimum length)
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
