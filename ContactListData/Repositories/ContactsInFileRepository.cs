using Domain.Interfaces;
using Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ContactListData.Repositories
{
    public class ContactsInFileRepository : IContactsRepository
    {
        private readonly string _filePath;

        public ContactsInFileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IQueryable<Contact> GetContacts()
        {
            var json = File.ReadAllText(_filePath); //reads the entire contents of the file located at the path stored in the _filePath variable as a string
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(json); //deserializes the JSON string stored in json into a list of Contact objects.
            return contacts.AsQueryable(); //method is called on the list of Contact objects to convert it into a queryable object, which can be used to perform LINQ operations on the data.
        }

        public void AddContact(Contact c)
        {
            var contacts = GetContacts().ToList();
            // assigns the Id property of the new contact as the maximum Id value in the list of existing contacts + 1. If the list is empty, it sets the Id as 1. Finally, it writes the updated list of contacts back to the file.
            c.Id = contacts.Count == 0 ? 1 : contacts.Max(x => x.Id) + 1;

            contacts.Add(c);
            var json = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(_filePath, json);
        }
    }

}
