using ContactsDirectory.Core;
using Microsoft.EntityFrameworkCore;

namespace ContactsDirectory.Entity
{
    public class ContactsDirectoryContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Date> Dates { get; set; }

        public ContactsDirectoryContext(DbContextOptions<ContactsDirectoryContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var contact = modelBuilder.Entity<Contact>();
            contact.HasKey(c => c.Id);
            contact.Property(c => c.FirstName)
                .HasMaxLength(100);
            contact.Property(c => c.LastName)
                .HasMaxLength(100);
            contact.Property(c => c.Department)
                .HasMaxLength(100);
            contact.Property(c => c.Avatar)
                .HasMaxLength(200);
            contact.HasMany(c => c.Slots)
                .WithOne(s => s.Contact)
                .HasForeignKey(s => s.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
            contact.HasMany(c => c.Dates)
                .WithOne(d => d.Contact)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            var slot = modelBuilder.Entity<Slot>();
            slot.HasKey(s => s.Id);
            slot.Property(s => s.Value)
                .HasMaxLength(100);
            slot.Property(s => s.Type)
                .HasMaxLength(100);
            slot.Property(s => s.CustomSlotType)
                .HasMaxLength(100);

            var date = modelBuilder.Entity<Date>();
            date.HasKey(d => d.Id);
            date.Property(d => d.Label)
                .HasMaxLength(100);
        }
    }
}
