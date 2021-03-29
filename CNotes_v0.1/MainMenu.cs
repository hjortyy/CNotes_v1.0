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
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void LoadForm(Form frm)
        {
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            this.Hide();
            frm.Show();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void LCNotes_Click(object sender, EventArgs e)
        {

            LoadForm(new Cnotes());

        }

        private void LInfo_Click(object sender, EventArgs e)
        {
            LoadForm(new Info2());
        }

        private void LCase_Click(object sender, EventArgs e)
        {
            LoadForm(new CaseManager());
        }

        private void LReport_Click(object sender, EventArgs e)
        {
            LoadForm(new Report());
        }
    }
}
