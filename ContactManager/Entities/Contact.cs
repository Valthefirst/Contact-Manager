using ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class Contact
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String CreationDate { get; set; }
        public String UpdateDate { get; set; }
        public Boolean Active { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }

        public Contact(int id, string title, string firstName, string middleName, string lastName, string gender, string creationDate, string updateDate, bool active)
        {
            Id = id;
            Title = title;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            Active = active;
        }

        public Contact(string title, string firstName, string middleName, string lastName, string gender)
        {
            Title = title;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
        }
    }
}
