using EventManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
: base(options)
        { }
        public DbSet<Event> Events { get; set; }
    }
}