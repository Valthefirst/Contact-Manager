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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(int id)
        {
            InitializeComponent();
            DBHelper dbh = new DBHelper();
            Contact contact = dbh.GetContact(id);
            Title_Box.Content = contact.Title;
            F_Name_Box.Content = contact.FirstName;
            M_Name_Box.Content = contact.MiddleName;
            L_Name_Box.Content = contact.LastName;
            Gender_Box.Content = contact.Gender;

            Email_Box.Content = contact.Email.EmailAddress;
            switch (contact.Email.Type_code)
            {
                case "M":
                    E_Type_Box.Content = "Main";
                    break;
                case "W":
                    E_Type_Box.Content = "Work";
                    break;
                //case "S":
                //    E_Type_Box.Content = "School";
                //    break;
                case "O":
                    E_Type_Box.Content = "Other";
                    break;
            }

            Phone_Box.Content = contact.Phone.PhoneNumber;
            switch (contact.Phone.Type_code)
            {
                case "M":
                    P_Type_Box.Content = "Mobile";
                    break;
                case "W":
                    P_Type_Box.Content = "Work";
                    break;
                case "H":
                    P_Type_Box.Content = "Home";
                    break;
                case "O":
                    P_Type_Box.Content = "Other";
                    break;
            }

            if (contact.Address.Number == 0)
            {
                StreetNumber_Box.Content = "";
            }
            else
            {
                StreetNumber_Box.Content = contact.Address.Number;
            }
            Street_Box.Content = contact.Address.Street;
            City_Box.Content = contact.Address.City;
            PostalCode_Box.Content = contact.Address.PostalCode;
            if (contact.Address.PostalCode.Length > 3)
            {
                PostalCode_Box.Content = contact.Address.PostalCode.Insert(3, " ");
            }
            Country_Box.Content = contact.Address.Country;
            switch (contact.Address.Type_Code)
            {
                //case "S":
                //    A_Type_Box.Content = "School";
                //    break;
                case "W":
                    A_Type_Box.Content = "Work";
                    break;
                case "H":
                    A_Type_Box.Content = "Home";
                    break;
                case "O":
                    A_Type_Box.Content = "Other";
                    break;
            }
        }
    }
}
