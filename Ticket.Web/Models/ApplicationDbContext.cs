using Microsoft.EntityFrameworkCore;
using Ticket.Web.Models;

namespace Ticket.Web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
    }
}
