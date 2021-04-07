using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using LiteDB;


namespace CNotes_v0._1
{
    public partial class MainMenu : Form
    {
        public class User
        {
            public int Id { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Company { get; set; }
            public string Department { get; set; }
            public string Contact_Email { get; set; }
        }

        public MainMenu()
        {
            /* Creates a directory for the database
             * Checks if the user is admin, if they are
             * not then displays a message box informing
             * the user to run as admin, then exits the program.
             * If the user is admin, runs as normal */
            InitializeComponent();
            LReport.Enabled = false;
            LCNotes.Enabled = false;
            LCase.Enabled = false;
            var database = @".\database\";
            Directory.CreateDirectory(database);
            var admin = IsAdmin();
            if (admin == false)
            {
                MessageBox.Show("You should run this program as Admin!", "Error");
                this.Close();
            }
            else
            {
                if (DBPass.password == "")
                {
                    DBPass obj = new DBPass();
                    this.Hide();
                    obj.ShowDialog();
                    line = $"password={DBPass.password} ;filename=.\\database\\Lite.db";
                }
                InfoFilled();

            }
            
            
        }

        public static string line = $"";

        private void InfoFilled()
        {
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
                    List<string> infolist = new List<string>(new string[] { firstname, lastname, company, department, email });
                    if (infolist.Distinct().Skip(1).Any())
                    {
                        LReport.Enabled = true;
                        LCase.Enabled = true;
                        LCNotes.Enabled = true;
                    }
                    else
                    {
                        LReport.Enabled = false;
                        LCase.Enabled = false;
                        LCNotes.Enabled = false;
                    }
                }
                    
            }
        }

        public static bool IsAdmin()
        {
            /* Checks if the user is an administrator, or running the software as administrator */
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void LoadForm(Form frm)
        {
            /* When called, shows the new form and hides the Main Menu. 
             * When the new form is closed it does what is stated in the frm_FormClosed function*/
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            this.Hide();
            frm.Show();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            /* Sends to LoadForm function what should be done when the form loaded is closed.
             * When the form launched is closed, it will show the Main Menu */
            this.Show();
            InfoFilled();
        }
        private void LCNotes_Click(object sender, EventArgs e)
        {
            /* Loads the Cnotes form when the CNotes button
             * is pressed using the LoadForm function*/
            LoadForm(new Cnotes());

        }

        private void LInfo_Click(object sender, EventArgs e)
        {
            /* Loads the Info2 form when the Info button
             * is pressed using the LoadForm function*/
            LoadForm(new Info2());
        }

        private void LCase_Click(object sender, EventArgs e)
        {
            /* Loads the CaseManager form when the Case button
             * is pressed using the LoadForm function*/
            LoadForm(new CaseManager());
        }

        private void LReport_Click(object sender, EventArgs e)
        {
            /* Loads the Report form when the Report button
             * is pressed using the LoadForm function*/
            LoadForm(new Report());
        }

        private void Login()
        {
            LoadForm(new DBPass());
        }
    }
}
