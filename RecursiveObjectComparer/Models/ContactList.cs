using System.Collections.Generic;

namespace RecursiveObjectComparer.Models
{
    public class ContactList
    {
        public ContactList()
        {
            Contacts = new List<Person>();
        }

        public List<Person> Contacts { get; set; }
    }
}
