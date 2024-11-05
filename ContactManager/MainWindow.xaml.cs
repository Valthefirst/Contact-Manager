using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        DBHelper dbh;
        public MainWindow()
        {
            InitializeComponent();
            dbh = new DBHelper();
            contacts = dbh.GetAllContacts();
            ContactsListItems.ItemsSource = contacts;
        }

        private void ContactsListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contact selectedContact = (Contact)ContactsListItems.SelectedItem;
            if (selectedContact != null)
            {
                DetailsWindow newWindow = new DetailsWindow(selectedContact.Id);
                newWindow.ShowDialog();
            }
        }

        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            AddContact addWindow = new AddContact();
            // Subscribe to the event
            addWindow.ContactAdded += AddWindow_ContactAdded;
            addWindow.ShowDialog();
        }

        private void AddWindow_ContactAdded(object sender, EventArgs e)
        {
            // Refresh the contacts list after the AddContact window is closed
            contacts = dbh.GetAllContacts();
            ContactsListItems.ItemsSource = null;
            ContactsListItems.ItemsSource = contacts;
        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            Contact selectedContact = (Contact)ContactsListItems.SelectedItem;
            if (selectedContact != null)
            {
                EditContact editWindow = new EditContact(selectedContact.Id);
                // Subscribe to the event
                editWindow.ContactModified += EditWindow_ContactModified;
                editWindow.ShowDialog();
            }
        }

        private void EditWindow_ContactModified(object sender, EventArgs e)
        {
            // Refresh the contacts list after the EditContact window is closed
            contacts = dbh.GetAllContacts();
            ContactsListItems.ItemsSource = null;
            ContactsListItems.ItemsSource = contacts;
        }

        private void Del_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsListItems.SelectedIndex >= 0)
            {
                MessageBoxResult result = MessageBox.Show("Delete this contact?", "Contact Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // I need to get the id from the selected contact
                    //get selection ---> get contact -----> then id ---> use it
                    Contact x = (Contact)ContactsListItems.SelectedItem;
                    int id = x.Id;
                    
                    dbh.Delete(id);
                    MessageBox.Show("Contact deleted!", "Confirmation");
                    contacts = dbh.GetAllContacts();
                    ContactsListItems.ItemsSource = contacts;
                }
            }
            

        }

        //private void Ex_Contact_btn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Imp_Contact_btn_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
