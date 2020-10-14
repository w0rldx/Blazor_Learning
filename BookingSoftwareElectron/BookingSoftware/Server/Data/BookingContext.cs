using Microsoft.EntityFrameworkCore;
using BookingSoftware.Shared;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=booking.db");
    }
}