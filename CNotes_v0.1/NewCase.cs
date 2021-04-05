using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using LiteDB;

namespace CNotes_v0._1
{
    public partial class NewCase : Form
    {
        public NewCase()
        {
            InitializeComponent();
        }

        public class Cases
        {
            public int Id { get; set; }
            public string Case_Number { get; set; }
            public string Case_Name { get; set; }
            public string Start_Date { get; set; }
            public string End_Date { get; set; }
        }

        private void SubmitCaseChangesButton_Click_1(object sender, EventArgs e)
        {
            /* Gets the information from the text fields */
            string CaseName = CaseNameTextbox.Text;
            string CaseNumber = CaseNumberTextbox.Text;
            string StartDate = StartDateCal.Value.ToString();
            string EndDate = null;
            if (EndDateCal.Checked == true)
            {
                EndDate = EndDateCal.Value.ToString();
            }

            CaseNameTextbox.Clear();
            CaseNumberTextbox.Clear();
            
            /* Inserts that information into the database and creates 
             * new file directories for screenshots and attachments */
            using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
            {
                var col = db.GetCollection<Cases>("cases");
                var newcase = new Cases
                {
                    Case_Number = CaseNumber,
                    Case_Name = CaseName,
                    Start_Date = StartDate,
                    End_Date = EndDate
                };
                int id = col.Insert(newcase);
                var fileattachmentspath = @".\FileAttachments\" + id.ToString();
                var screenshotspath = @".\Screenshots\" + id.ToString();
                Directory.CreateDirectory(fileattachmentspath);
                Directory.CreateDirectory(screenshotspath);
                
            }
            this.Close();
        }

    }
}
