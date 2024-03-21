using ASP_ER_Core_MVC_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_ER_Core_MVC_Test.Data;

public class BobContext : DbContext
{
    public BobContext(DbContextOptions<BobContext> options) : base(options) { }
    
    public DbSet<BobModel> Bobs { get; set; }
    public DbSet<BrainModel> Brains { get; set; }
}