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
}
