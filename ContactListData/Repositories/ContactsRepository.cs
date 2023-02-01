using ContactListData.Context;
using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ContactListData.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactContext _context;

        public ContactsRepository(ContactContext context)
        {
            _context = context;
        }

        public IQueryable<Contact> GetContacts()
        {
            return _context.Contacts.AsQueryable();
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }
    }
}
