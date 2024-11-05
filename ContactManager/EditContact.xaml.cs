using ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for EditContact.xaml
    /// </summary>
    public partial class EditContact : Window
    {
        public event EventHandler ContactModified;
        private int contactId;
        public EditContact(int id)
        {
            InitializeComponent();
            contactId = id;
            DBHelper dbh = new DBHelper();
            Contact contact = dbh.GetContact(id);
            Title_Box.Text = contact.Title;
            F_Name_Box.Text = contact.FirstName;
            M_Name_Box.Text = contact.MiddleName;
            L_Name_Box.Text = contact.LastName;
            Gender_Box.Text = contact.Gender;

            Email_Box.Text = contact.Email.EmailAddress;
            switch (contact.Email.Type_code)
            {
                case "M":
                    E_Type_Box.Text = "Main";
                    break;
                case "W":
                    E_Type_Box.Text = "Work";
                    break;
                //case "S":
                //    E_Type_Box.Text = "School";
                //    break;
                case "O":
                    E_Type_Box.Text = "Other";
                    break;
                case "N":
                    E_Type_Box.Text = "Not Available";
                    break;
            }

            Phone_Box.Text = contact.Phone.PhoneNumber;
            switch (contact.Phone.Type_code)
            {
                case "M":
                    P_Type_Box.Text = "Mobile";
                    break;
                case "W":
                    P_Type_Box.Text = "Work";
                    break;
                case "H":
                    P_Type_Box.Text = "Home";
                    break;
                case "O":
                    P_Type_Box.Text = "Other";
                    break;
                case "N":
                    P_Type_Box.Text = "Not Available";
                    break;
            }

            StreetNumber_Box.Text = contact.Address.Number.ToString();
            Street_Box.Text = contact.Address.Street;
            City_Box.Text = contact.Address.City;
            PostalCode_Box.Text = contact.Address.PostalCode;
            Country_Box.Text = contact.Address.Country;
            switch (contact.Address.Type_Code)
            {
                //case "S":
                //    A_Type_Box.Text = "School";
                //    break;
                case "W":
                    A_Type_Box.Text = "Work";
                    break;
                case "H":
                    A_Type_Box.Text = "Home";
                    break;
                case "O":
                    A_Type_Box.Text = "Other";
                    break;
                case "N":
                    A_Type_Box.Text = "Not Available";
                    break;
            }
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            DBHelper dbh = new DBHelper();

            string title = Title_Box.Text;
            string firstName = F_Name_Box.Text;
            string middleName = M_Name_Box.Text;
            string lastName = L_Name_Box.Text;
            string gender = Gender_Box.Text;
            if (gender == "")
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

            string emailAddress = Email_Box.Text;
            string emailType = !string.IsNullOrEmpty(E_Type_Box.Text) ? E_Type_Box.Text.Substring(0, 1) : string.Empty;
            if (emailType == "")
            {
                MessageBox.Show("Please select an email type.");
                return;
            }

            string phoneType = !string.IsNullOrEmpty(P_Type_Box.Text) ? P_Type_Box.Text.Substring(0, 1) : string.Empty;
            if (phoneType == "")
            {
                MessageBox.Show("Please select a phone number type.");
                return;
            }
            string phoneNumber = Phone_Box.Text;

            int streetNumber;
            if (!int.TryParse(StreetNumber_Box.Text, out streetNumber))
            {
                streetNumber = 0;
            }
            string street = Street_Box.Text;
            string city = City_Box.Text;
            string postalCode = PostalCode_Box.Text;
            postalCode = postalCode.Replace(" ", "");
            if (postalCode.Length != 6 && postalCode.Length != 0)
            {
                MessageBox.Show("Postal code must be 6 characters or empty.");
                return;
            }
            string country = Country_Box.Text;
            string addressType = !string.IsNullOrEmpty(A_Type_Box.Text) ? A_Type_Box.Text.Substring(0, 1) : string.Empty;
            if (addressType == "")
            {
                MessageBox.Show("Please select an address type.");
                return;
            }

            Contact contact = new Contact(title, firstName, middleName, lastName, gender);
            dbh.UpdateContact(contactId, contact);

            Email email = new Email(contactId, emailAddress, emailType);
            dbh.UpdateEmail(email);

            Phone phone = new Phone(contactId, phoneType, phoneNumber);
            dbh.UpdatePhone(phone);

            Address address = new Address(contactId, addressType, streetNumber, street, city, postalCode, country);
            dbh.UpdateAddress(address);

            ContactModified?.Invoke(this, EventArgs.Empty);

            Close();
        }
    }
}
