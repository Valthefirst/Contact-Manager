using ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class DBHelper
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        public List<Contact> GetAllContacts()
        {
            List<Contact> arr = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contact";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string title = reader.IsDBNull(1) ? null : reader.GetString(1);
                        string firstName = reader.GetString(2);
                        string middleName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        string lastName = reader.GetString(4);
                        string gender = reader.GetString(5) ?? "";
                        string creationDate = reader.GetDateTime(6).ToString();
                        string updateDate = reader.GetDateTime(7).ToString();
                        bool active = reader.GetBoolean(8);

                        Contact contact = new Contact(id, title, firstName, middleName, lastName, gender, creationDate, updateDate, active);
                        contact.Email = GetEmailByContactId(id);
                        contact.Phone = GetPhoneByContactId(id);
                        arr.Add(contact);
                    }
                }
            }
            return arr;
        }

        public Contact GetContact(int id)
        {
            var ConString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                string query = @"SELECT * FROM Contact WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int contactId = reader.GetInt32(0);
                        string title = reader.IsDBNull(1) ? null : reader.GetString(1);
                        string firstName = reader.GetString(2);
                        string middleName = reader.IsDBNull(3) ? null : reader.GetString(3);
                        string lastName = reader.GetString(4);
                        string gender = reader.GetString(5) ?? "";
                        string creationDate = reader.GetDateTime(6).ToString();
                        string updateDate = reader.GetDateTime(7).ToString();
                        bool active = reader.GetBoolean(8);

                        Contact contact = new Contact(contactId, title, firstName, middleName, lastName, gender, creationDate, updateDate, active);
                        contact.Email = GetEmailByContactId(id);
                        contact.Phone = GetPhoneByContactId(id);
                        contact.Address = GetAddressByContactId(id);
                        return contact;
                    }
                }
            }
            return null;
        }

        //public List<Email> GetEmailsByContactId(int contactId)
        //{
        //    List<Email> emails = new List<Email>();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT * FROM Email WHERE Contact_Id = @ContactId";
        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@ContactId", contactId);
        //            connection.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Email email = new Email(
        //                    reader.GetInt32(0), // Id
        //                    reader.GetInt32(1), // ContactId
        //                    reader.GetString(2), // Type_code
        //                    reader.GetString(3), // CreationDate
        //                    reader.GetString(4), // UpdateDate
        //                    reader.GetString(5)  // EmailAddress
        //                );
        //                emails.Add(email);
        //            }
        //        }
        //    }
        //    return emails;
        //}

        public Email GetEmailByContactId(int contactId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Email WHERE Contact_Id = @ContactId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", contactId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Email email = new Email(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetDateTime(3).ToString(),
                            reader.GetDateTime(4).ToString(),
                            reader.GetString(5)
                        );
                        return email;
                    }
                }
            }
            return null;
        }

        //public List<Phone> GetPhonesByContactId(int contactId)
        //{
        //    List<Phone> phones = new List<Phone>();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT * FROM Phone WHERE Contact_Id = @ContactId";
        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@ContactId", contactId);
        //            connection.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Phone phone = new Phone(
        //                    reader.GetInt32(0),
        //                    reader.GetInt32(1),
        //                    reader.GetString(2),
        //                    reader.GetString(3),
        //                    reader.GetDateTime(4).ToString(),
        //                    reader.GetDateTime(5).ToString()
        //                );
        //                phones.Add(phone);
        //            }
        //        }
        //    }
        //    return phones;
        //}

        public Phone GetPhoneByContactId(int contactId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Phone WHERE Contact_Id = @ContactId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", contactId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Phone phone = new Phone(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetDateTime(4).ToString(),
                            reader.GetDateTime(5).ToString()
                        );
                        return phone;
                    }
                }
            }
            return null;
        }


        //public List<Address> GetAddressesByContactId(int contactId)
        //{
        //    List<Address> addresses = new List<Address>();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT * FROM Address WHERE Contact_Id = @ContactId";
        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@ContactId", contactId);
        //            connection.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Address address = new Address(
        //                    reader.GetInt32(0),
        //                    reader.GetInt32(1),
        //                    reader.GetString(2),
        //                    reader.GetDateTime(3).ToString(),
        //                    reader.GetDateTime(4).ToString(),
        //                    reader.GetInt32(5),
        //                    reader.GetString(6),
        //                    reader.GetString(7),
        //                    reader.GetString(8),
        //                    reader.GetString(9)
        //                );
        //                addresses.Add(address);
        //            }
        //        }
        //    }
        //    return addresses;
        //}

        public Address GetAddressByContactId(int contactId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Address WHERE Contact_Id = @ContactId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", contactId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Address address = new Address(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetDateTime(3).ToString(),
                            reader.GetDateTime(4).ToString(),
                            reader.GetInt32(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetString(8),
                            reader.GetString(9)
                        );
                        return address;
                    }
                }
            }
            return null;
        }

        public int AddContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Contact (Title, FirstName, MiddleName, LastName, Gender, Active, CreationDate, UpdateDate) VALUES (@Title, @FirstName, @MiddleName, @LastName, @Gender, 1, GETDATE(), GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    if (contact.Title == null)
                    {
                        cmd.Parameters.AddWithValue("@Title", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Title", contact.Title);
                    }
                    cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    if (contact.MiddleName == null)
                    {
                        cmd.Parameters.AddWithValue("@MiddleName", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MiddleName", contact.MiddleName);
                    }
                    cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@Gender", contact.Gender);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                // to get the id of the last inserted contact
                string query2 = "SELECT TOP 1 * FROM Contact ORDER BY Id DESC";
                SqlCommand cmd2 = new SqlCommand(query2, connection);
                int contactId = 0;
                using (SqlDataReader reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contactId = reader.GetInt32(0);
                    }
                }
                return contactId;
            }
        }

        public void AddEmail(Email email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Email (Contact_Id, EmailAddress, Type_code, CreationDate, UpdateDate) VALUES (@ContactId, @Email, @Type_code, GETDATE(), GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", email.ContactId);
                    cmd.Parameters.AddWithValue("@Email", email.EmailAddress);
                    cmd.Parameters.AddWithValue("@Type_code", email.Type_code);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddPhone(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Phone (Contact_Id, PhoneNumber, Type_code, CreationDate, UpdateDate) VALUES (@ContactId, @PhoneNumber, @Type_code, GETDATE(), GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", phone.ContactId);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Type_code", phone.Type_code);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddAddress(Address address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Address (Contact_Id, Type_code, Number, Street, City, PostalCode, Country, CreationDate, UpdateDate) VALUES (@ContactId, @Type_code, @Number, @Street, @City, @PostalCode, @Country, GETDATE(), GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", address.Contact_Id);
                    cmd.Parameters.AddWithValue("@Type_code", address.Type_Code);
                    cmd.Parameters.AddWithValue("@Number", address.Number);
                    cmd.Parameters.AddWithValue("@Street", address.Street);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", address.Country);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateContact(int contactId, Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Contact SET Title = @Title, FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Gender = @Gender, UpdateDate = GETDATE() WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", contactId);
                    cmd.Parameters.AddWithValue("@Title", contact.Title);
                    cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", contact.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@Gender", contact.Gender);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmail(Email email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Email SET EmailAddress = @Email, Type_code = @Type_code, UpdateDate = GETDATE() WHERE Contact_Id = @ContactId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", email.ContactId);
                    cmd.Parameters.AddWithValue("@Email", email.EmailAddress);
                    cmd.Parameters.AddWithValue("@Type_code", email.Type_code);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePhone(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Phone SET PhoneNumber = @PhoneNumber, Type_code = @Type_code, UpdateDate = GETDATE() WHERE Contact_Id = @ContactId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", phone.ContactId);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Type_code", phone.Type_code);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAddress(Address address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Address SET Type_code = @Type_code, Number = @Number, Street = @Street, City = @City, PostalCode = @PostalCode, Country = @Country, UpdateDate = GETDATE() WHERE Contact_Id = @ContactId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactId", address.Contact_Id);
                    cmd.Parameters.AddWithValue("@Type_code", address.Type_Code);
                    cmd.Parameters.AddWithValue("@Number", address.Number);
                    cmd.Parameters.AddWithValue("@Street", address.Street);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", address.Country);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query1 = @"DELETE FROM Contact WHERE Id = @Id";
                string query2 = @"DELETE FROM Email WHERE Contact_Id = @Id";
                string query3 = @"DELETE FROM Phone WHERE Contact_Id = @Id";
                string query4 = @"DELETE FROM Address WHERE Contact_Id = @Id";
                connection.Open();

                using (SqlCommand cmd2 = new SqlCommand(query2, connection))
                {
                    cmd2.Parameters.AddWithValue("@Id", Id);
                    cmd2.ExecuteNonQuery();
                }

                using (SqlCommand cmd3 = new SqlCommand(query3, connection))
                {
                    cmd3.Parameters.AddWithValue("@Id", Id);
                    cmd3.ExecuteNonQuery();
                }

                using (SqlCommand cmd4 = new SqlCommand(query4, connection))
                {
                    cmd4.Parameters.AddWithValue("@Id", Id);
                    cmd4.ExecuteNonQuery();
                }

                using (SqlCommand cmd1 = new SqlCommand(query1, connection))
                {
                    cmd1.Parameters.AddWithValue("@Id", Id);
                    cmd1.ExecuteNonQuery();
                }
            }
        }

        //public void DeactivateContact(int Id, bool Active)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = @"UPDATE Contact SET active = " + !Active + " WHERE Id = " + Id;
        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            //cmd.Parameters.AddWithValue("@Id", c.getId);
        //            //cmd.Parameters.AddWithValue("@firstname", user.FirstName);
        //            //cmd.Parameters.AddWithValue("@lastname", user.LastName);
        //            //add whatever parameters you required to update here
        //            int rows = cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
