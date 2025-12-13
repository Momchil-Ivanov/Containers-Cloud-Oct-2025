using Contacts.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext<ApplicationUser>
    {

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
            // Delete database if it exists, then create all tables fresh
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserContact>(e =>
            {
                e.HasKey(uc => new { uc.ApplicationUserId, uc.ContactId });
            });

            base.OnModelCreating(builder);
        }
    }
}