using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Data;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace week_3_basic_Ecommerce.Models {
    public class Member {

        /// <summary>
        /// Primary key value for member to identify specific members
        /// </summary>
        [Key]
        public int MemberId { get; set; }


        /// <summary>
        /// Email Address of member used to login
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Password created by member and used to login
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Members phone number
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// the userName of member
        /// </summary>
        public string? UserName { get; set; }
    }

    public class RegisterViewModel {

        /// <summary>
        /// Email member uses to create an account and login
        /// </summary>
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// Used to verify user entered intended email address
        /// </summary>
        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string? ConfirmEmail { get; set; }

        /// <summary>
        /// Password member enters when creating an account and logging in
        /// </summary>
        [Required]
        [StringLength(75, MinimumLength = 6)] //(maximum, minimum length)
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        /// <summary>
        /// Used to verify that the member entered their intended password
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }

    public class LoginViewModel {

        /// <summary>
        /// Email address used for member login
        /// </summary>
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = null!; 

        /// <summary>
        /// password used for member login
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; } = null!;
    }
}
