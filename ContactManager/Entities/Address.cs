using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class Address
    {
        public int Id {  get; set; }
        public int Contact_Id { get; set; }
        public string Type_Code { get; set; }
        public String CreationDate { get; set; }
        public String UpdateDate { get; set; }
        public int Number { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String PostalCode { get; set; }
        public String Country { get; set; }

        public Address(int id, int contact_Id, string type_Code, string creationDate, string updateDate, int number, string street, string city, string postalCode, string country)
        {
            Id = id;
            Contact_Id = contact_Id;
            Type_Code = type_Code;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            Number = number;
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public Address(int contact_Id, string type_Code, int number, string street, string city, string postalCode, string country)
        {
            Contact_Id = contact_Id;
            Type_Code = type_Code;
            Number = number;
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
