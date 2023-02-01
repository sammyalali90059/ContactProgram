using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
{
    public class ContactService
    {
        private readonly IContactsRepository _repository;

        public ContactService(IContactsRepository repository)
        {
            _repository = repository;
        }


        public void AddContact(Contact c)
        {
            if (_repository.GetContacts().Any(i => i.MobileNo == c.MobileNo))
                throw new Exception("Contact with the same Phone Number already exists");
            else
            {
                _repository.AddContact(new Contact()
                {
                    Name = c.Name,
                    Surname = c.Surname,
                    MobileNo = c.MobileNo,
                    Picture = c.Picture,
                });
            }
        }

        public IQueryable<Contact> GetContacts()
        {
            var list = from i in _repository.GetContacts()
                       select new Contact()
                       {
                           Name = i.Name,
                           Surname = i.Surname,
                           MobileNo = i.MobileNo,
                           Picture = i.Picture,
                           Id = i.Id,
                       };
            return list;
        }
    }
}
