using ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public event EventHandler ContactAdded;

        public AddContact()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Postal code must be 6 characters.");
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
            int newContactId = dbh.AddContact(contact);

            Email email = new Email(newContactId, emailAddress, emailType);
            dbh.AddEmail(email);

            Phone phone = new Phone(newContactId, phoneType, phoneNumber);
            dbh.AddPhone(phone);

            Address address = new Address(newContactId, addressType, streetNumber, street, city, postalCode, country);
            dbh.AddAddress(address);

            ContactAdded?.Invoke(this, EventArgs.Empty);

            Close();
        }
    }
}
