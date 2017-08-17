using System;
using System.Collections.Generic;
using System.Text;

namespace RecursiveObjectComparerTool.Models
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
