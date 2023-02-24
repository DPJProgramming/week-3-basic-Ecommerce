using Microsoft.EntityFrameworkCore;
using week_3_basic_Ecommerce.Models;

namespace week_3_basic_Ecommerce.Data {


    public class VideoGameContext : DbContext {

        /// <summary>
        /// constructor passes options to base class which is inherited
        /// from base class
        /// </summary>
        /// <param name=""></param>
        public VideoGameContext(DbContextOptions<VideoGameContext> options)
            : base(options) {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Member> Members { get; set; }
    }
}
