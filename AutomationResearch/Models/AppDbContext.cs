using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutomationResearch.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>(op => { op.Property(x => x.Id).HasColumnName("User_Id"); });
        }
    }



}