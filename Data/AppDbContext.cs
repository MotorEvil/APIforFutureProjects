using APIforUpcomingProjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIforUpcomingProjects.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt)
            : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
/*            builder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<UserRole>()
                .HasOne<User>(x => x.User)
                .WithMany(x => x.UsersRoles)
                .HasForeignKey(x => x.UserId);

            builder.Entity<UserRole>()
                .HasOne<Role>(x => x.Role)
                .WithMany(x => x.UsersRoles)
                .HasForeignKey(x => x.RoleId);

            base.OnModelCreating(builder);
*/        }

        public DbSet<User> Users { get; set; }
        public DbSet<CarModel> Cars { get; set; }
    }
}
