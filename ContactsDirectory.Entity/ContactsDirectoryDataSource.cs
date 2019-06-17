using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactsDirectory.Core;
using Microsoft.EntityFrameworkCore;

namespace ContactsDirectory.Entity
{
    public class ContactsDirectoryDataSource : IDataSource, IDisposable
    {
        private readonly ContactsDirectoryContext DataContext;
        public ContactsDirectoryDataSource(ContactsDirectoryContext context)
        {
            DataContext = context;
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            contact.Id = Guid.NewGuid();
            await DataContext.Contacts.AddAsync(contact);
            await DataContext.SaveChangesAsync();
            return contact;
        }

        public async  Task<Contact> DeleteContact(Contact contact)
        {
            Contact deleted = DataContext.Contacts.Remove(contact).Entity;
            await DataContext.SaveChangesAsync();
            return deleted;
        }

        public async Task<Contact> GetContact(Guid id)
        {
            return await DataContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Contact>> GetContacts()
        {
            return await DataContext.Contacts.Include(c => c.Slots).Include(c => c.Dates).ToListAsync();
        }

        public async Task<Contact> UpdateContact(Guid id, Contact contact)
        {
            contact.Id = id;
            Contact updated = DataContext.Contacts.Update(contact).Entity;
            await DataContext.SaveChangesAsync();
            return updated;
        }
  }
}
