using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNotes_v0._1
{
    public partial class DBPass : Form
    {
        public DBPass()
        {
            InitializeComponent();
        }

        public static string password = "";
        public void login_Click_1(object sender, EventArgs e)
        {
            password = textBox1.Text;
            Close();
        }
    }
}
