﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecursiveObjectComparer.Models
{
    public class Person
    {
        public Person()
        {
            Addresses = new List<Address>();
            ContactMethods = new List<ContactMethod>();
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FullNameReversed => $"{LastName}, {FirstName}";
        public List<Address> Addresses { get; set; }
        public List<ContactMethod> ContactMethods { get; set; }

    }
}
