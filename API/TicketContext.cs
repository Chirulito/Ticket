using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API;
public class TicketContext : DbContext
{
    public TicketContext(DbContextOptions<TicketContext> options)
        : base(options) {}

    public DbSet<Event> Events { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceTicket> InvoiceTickets { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<PaymentCategory> PaymentCategories { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<API.Models.UserRole> UserRole { get; set; } = default!;
    public DbSet<API.Models.UserHistory> UserHistory { get; set; } = default!;

}
