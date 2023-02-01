using System.ComponentModel.DataAnnotations;

namespace week_3_basic_Ecommerce.Models {
    public class Game {

        /// <summary>
        /// Unique identifier for specific game
        /// </summary>
        [Key]
        public int GameId { get; set; }

        /// <summary>
        /// Official title of game
        /// </summary>
        [Required]
        public string? Title { get; set; }

        /// <summary>
        /// sales price
        /// </summary>
        [Range(0, 1000)]
        public double Price { get; set; }
    }
}
