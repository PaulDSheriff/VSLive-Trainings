#nullable disable

using Microsoft.EntityFrameworkCore;
using AdvWorks.EntityLayer;

namespace AdvWorks.DataLayer
{
  public partial class AdventureWorksLTDbContext : DbContext
  {
    public AdventureWorksLTDbContext(
      DbContextOptions<AdventureWorksLTDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(
      ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
