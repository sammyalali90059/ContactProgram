using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces
{
    public interface IContactsRepository
    {
        IQueryable<Contact> GetContacts();
        void AddContact(Contact c);
    }
}
