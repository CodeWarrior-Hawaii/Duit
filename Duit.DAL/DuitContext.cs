using System.ComponentModel.DataAnnotations.Schema;
using Duit.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Duit.DAL
{
    public class DuitContext : DbContext, IDuitContext
    {
        public DuitContext()
        {
        }

        public DuitContext(DbContextOptions<DuitContext> config) : base(config)
        {
        }

        public DbSet<ToDosTask> Tasks { get; set; }

        public override int SaveChanges()
        {
            DateTime saveTime = DateTime.Now;
            foreach (var entry in this.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if ((DateTime)entry.Property("CreatedDate").CurrentValue == DateTime.MinValue)
                        {
                            entry.Property("CreatedDate").CurrentValue = saveTime;
                        }
                        break;
                    case EntityState.Modified:
                        if ((DateTime)entry.Property("UpdatedDate").CurrentValue == DateTime.MinValue)
                        {
                            entry.Property("UpdatedDate").CurrentValue = saveTime;
                        }
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }

        public void SeedData()
        {
            if (! Tasks.Any())
            {
                Tasks.Add(new ToDosTask
                {
                    Completed = false,
                    Title = "Get new spark plugs for the Jeep",
                    Description = "DEN 3169 - $3.99 @ Napa",
                    DueDateTime = DateTime.Now.AddDays(3)
                });
                Tasks.Add(new ToDosTask
                {
                    Completed = false,
                    Title = "Cut and haul vines from rock wall"
                });
                Tasks.Add(new ToDosTask
                {
                    Completed = true,
                    Title = "Order new lumber for front gate",
                    Description = "See pictures in the M:\\Pictures\\Frontgate folder",
                    DueDateTime = DateTime.Now.AddDays(3),
                    CompletedDateTime = DateTime.Now.AddDays(-1)
                });
            }

            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("Tasks");
        }

    }
}