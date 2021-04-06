using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNotes_1
{
    public partial class DBPassword : Form
    {
        public DBPassword()
        {
            InitializeComponent();
        }

        public static string password = "";

        private void login_Click(object sender, EventArgs e)
        {
            password = textBox1.Text;
            this.Close();
        }
    }
}
