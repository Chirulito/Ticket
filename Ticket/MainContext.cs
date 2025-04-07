using Microsoft.EntityFrameworkCore;

namespace Ticket
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) {}
    }
}
