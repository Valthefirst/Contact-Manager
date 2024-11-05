using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class Phone
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public String Type_code { get; set; }
        public String PhoneNumber { get; set; }
        public String CreationDate { get; set; }
        public String UpdateDate { get; set; }

        public Phone(int id, int contactId, string type_code, string phoneNumber, string creationDate, string updateDate)
        {
            Id = id;
            ContactId = contactId;
            PhoneNumber = phoneNumber;
            Type_code = type_code;
            CreationDate = creationDate;
            UpdateDate = updateDate;
        }

        public Phone(int contactId, string type_code, string phoneNumber)
        {
            ContactId = contactId;
            PhoneNumber = phoneNumber;
            Type_code = type_code;
        }

        //public override string ToString()
        //{
        //    return PhoneNumber;
        //}
    }
}
