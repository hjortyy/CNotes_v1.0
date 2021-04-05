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


namespace CNotes_v0._1
{
    public partial class MainMenu : Form
    {
        
        public MainMenu()
        {
            /* Creates a directory for the database
             * Checks if the user is admin, if they are
             * not then displays a message box informing
             * the user to run as admin, then exits the program.
             * If the user is admin, runs as normal */
            InitializeComponent();
            var database = @".\database\";
            Directory.CreateDirectory(database);
            var admin = IsAdmin();
            if (admin == false)
            {
                MessageBox.Show("You should run this program as Admin!", "Error");
                this.Close();
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
    }
}
