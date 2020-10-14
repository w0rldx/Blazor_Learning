using Microsoft.EntityFrameworkCore;
using BookingSoftware.Shared;

namespace BookingSoftware.Server.Data
{
    public class BookingContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Magic string.
        /// </summary>
        public static readonly string RowVersion = nameof(RowVersion);

        /// <summary>
        /// Magic strings.
        /// </summary>
        public static readonly string BookDb = nameof(BookDb).ToLower();


        public BookingContext(DbContextOptions<BookingContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=booking.db");
    }
}