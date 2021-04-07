using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;

namespace CNotes_v0._1
{
    public partial class Info2 : Form
    {
        public Info2()
        {
            /* Calls the FirstRun function to populate the database.
             * Then fills the listbox with information from it */
            InitializeComponent();
            FirstRun();
            FillFields(listBox1);
        }

        public class User
        {
            public int Id { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Company { get; set; }
            public string Department { get; set; }
            public string Contact_Email { get; set; }
        }

        public void FirstRun()
        {
            /* If the User collection is empty, populates it with spaces.
             * This is so that the rest of the form runs smoothly, 
             * as in the fields that depend on information from the database
             * are still able to be populated. */
            using (var db = new LiteDatabase(MainMenu.line))
            {
                var collection = db.GetCollection<User>("user");
                var query = collection
                    .FindById(1);
                if (query == null)
                {
                    var empty = new User
                    {
                        Id = 1,
                        First_Name = "*",
                        Last_Name = "*",
                        Company = "*",
                        Department = "*",
                        Contact_Email = "*"
                    };
                    collection.Insert(empty);
                }

            }
        }

        public void FillFields(ListBox listBox)
        {
            /* Fetches information from the User collection of the database, 
             * then adds that to the listbox to display the information back to the user */
            using (var db = new LiteDatabase(MainMenu.line))
            {
                var collection = db.GetCollection<User>("user");
                var query = collection
                    .Find(Query.EQ("_id", 1))
                    .Select(x => new
                    {
                        firstname = x.First_Name,
                        lastname = x.Last_Name,
                        company = x.Company,
                        department = x.Department,
                        email = x.Contact_Email
                    }).ToList();
                foreach (var itemlist in query)
                {
                    string firstname = itemlist.firstname;
                    string lastname = itemlist.lastname;
                    string company = itemlist.company;
                    string department = itemlist.department;
                    string email = itemlist.email;
                    listBox.Items.Clear();
                    listBox.Items.Add("First name:" + "\t" + firstname);
                    listBox.Items.Add("Last name:" + "\t" + lastname);
                    listBox.Items.Add("Company:" + "\t" + company);
                    listBox.Items.Add("Department:" + "\t" + department);
                    listBox.Items.Add("Contact email:" + "\t" + email);
                    firstnameTextBox.Text = firstname;
                    lastnameTextBox.Text = lastname;
                    companyTextBox.Text = company;
                    departmentTextBox.Text = department;
                    emailTextBox.Text = email;
                }
            }
        }



        public void button1_Click(object sender, EventArgs e)
        {
            /* Takes the information from the text boxes on the form 
             * and inserts it into the database, then runs the FillFields
             * function again to update the listbox */
            string firstname = firstnameTextBox.Text;
            string lastname = lastnameTextBox.Text;
            string company = companyTextBox.Text;
            string department = departmentTextBox.Text;
            string email = emailTextBox.Text;
            /*
             * Decided that clearing the information from the text boxes
             * would be uncomfortable. If the user made a mistake they
             * would have to input the whole field.
             * 
            firstnameTextBox.Clear();
            lastnameTextBox.Clear();
            companyTextBox.Clear();
            departmentTextBox.Clear();
            emailTextBox.Clear();
            */
            using (var db = new LiteDatabase(MainMenu.line))
            {
                var collection = db.GetCollection<User>("user");
                var update = collection
                    .FindById(1);
                update.First_Name = firstname;
                update.Last_Name = lastname;
                update.Company = company;
                update.Department = department;
                update.Contact_Email = email;
                collection.Update(update);
            }
            FillFields(listBox1);
        }
    }
}
