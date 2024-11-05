using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Entities
{
    internal class Email
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public String Type_code { get; set; }
        public String CreationDate { get; set; }
        public String UpdateDate { get; set; }
        public String EmailAddress { get; set; }

        public Email(int id, int contactId, string type_code, string creationDate, string updateDate, string emailAddress)
        {
            Id = id;
            ContactId = contactId;
            Type_code = type_code;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            EmailAddress = emailAddress;
        }

        public Email(int contactId, string emailAddress, string type_code)
        {
            ContactId = contactId;
            EmailAddress = emailAddress;
            Type_code = type_code;
        }

        public override string ToString()
        {
            return EmailAddress;
        }
    }
}
