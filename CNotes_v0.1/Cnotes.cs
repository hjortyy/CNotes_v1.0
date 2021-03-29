using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using LiteDB;
using System.Drawing.Imaging;

namespace CNotes_v0._1
{
    public partial class Cnotes : Form
    {

        public Cnotes()
        {
            InitializeComponent();
            FillTheBox(CaseBox);
            
        }

        public class Cases
        {
            public int Id { get; set; }
            public string Case_Number { get; set; }
            public string Case_Name { get; set; }
            public string Start_Date { get; set; }
            public string End_Date { get; set; }
        }
        
        public class Entry
        {
            public int Entry_ID { get; set; }
            public string Note_Text { get; set; }
            public string Attach_ID { get; set; }
            public string Screen_ID { get; set; }
            public int Time { get; set; }
            public int Case_ID { get; set; }
        }

        public class Attachments
        {
            public int Id { get; set; }
            public string Hash { get; set; }
            public string Name { get; set; }
        }
        

        private MD5 md5 = MD5.Create();

        private void FillTheBox(ComboBox CaseBox)
        {
            /*Fills the dropdown listbox with case names*/
            CaseBox.Items.Clear();
            using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
            {
                var collection = db.GetCollection<Cases>("cases");
                var query = collection
                    .FindAll()
                    .OrderBy(x => x.Start_Date)
                    .Select(x => x.Case_Name).ToList();
                foreach (var itemlist in query)
                {
                    CaseBox.Items.Add(itemlist);
                }
            }
        }

        private void FillTheView(ListView displayNotes)
        {
            /* Fills the note display with entries related to the selected case */
            displayNotes.Clear();
            displayNotes.Columns.Add("Time", 90);
            displayNotes.Columns.Add("Note", 590);
            displayNotes.Columns.Add("Attachment", 50);
            displayNotes.Columns.Add("Screenshot", 50);
            int? selectedcase = ReturnCaseID();
            using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
            {
                var collection = db.GetCollection<Entry>("entries");
                var query = collection
                    .Find(Query.EQ("Case_ID", selectedcase))
                    .OrderBy(x => x.Time)
                    .Select(x => new
                    {
                        notetext = x.Note_Text,
                        timestamp = x.Time,
                        attachment = x.Attach_ID,
                        screenshot = x.Screen_ID
                    }).ToList();
                foreach (var itemlist in query)
                {
                    ListViewItem entry = new ListViewItem();
                    string note = itemlist.notetext;
                    int time = itemlist.timestamp;
                    string attachment = itemlist.attachment;
                    string screenshot = itemlist.screenshot;
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(time);
                    string humantime = dateTimeOffset.ToString("dd/MM/yy HH:mm");               // Changes the Epoch time that is stored with the note entry to a human readable format
                    displayNotes.Items.Add(new ListViewItem(new string[] { humantime, note, attachment, screenshot }));
                }
            }
            if (displayNotes.Items.Count > 0)           // Scrolls down to the bottom of the note entries, ensuring that the latest note is visible
            {
                displayNotes.Items[displayNotes.Items.Count - 1].EnsureVisible();
            }
        }
        
        public static string BytesToString(byte[] bytes)
        {
            /* Changes the MD5 hash bytes to string format
             * Only used in tandem with "GetHashMd5()"     */
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }

        private byte[] GetHashMd5(string filename)
        {
            /* Returns the MD5 hash of a file */
            using (FileStream stream = File.OpenRead(filename))
            {
                return md5.ComputeHash(stream);
            }
        }

        private int? attachID = null;

        private void Attach_Click(object sender, EventArgs e)
        {
            /*  */
            int newname = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            int? caseIDnr = ReturnCaseID();
            if (caseIDnr != null)
            {
                string caseID = caseIDnr.ToString();
                var destinationPath = @".\FileAttachments\" + caseID;
                Directory.CreateDirectory(destinationPath);
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog1.FileName;
                    string destinationFile = Path.Combine(destinationPath, newname.ToString());
                    File.Copy(filePath, destinationFile, true);
                    using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
                    {
                        var name = newname.ToString();
                        var collection = db.GetCollection<Attachments>("attachments");
                        var attachment = new Attachments
                        {
                            Hash = BytesToString(GetHashMd5(destinationFile)),
                            Name = name
                        };
                        collection.Insert(attachment);
                        var query = collection
                            .Find(Query.EQ("Name", name))
                            .Select(x => x.Id).FirstOrDefault();
                        attachID = query;
                    }
                }
            }
            else
            {

            }
        }

        public static string caseIDtopass = "";
        public int? ReturnCaseID()
        {
            /*  */
            
            try
            {
                string selectedCase = CaseBox.SelectedItem.ToString();
                using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
                {
                    var collection = db.GetCollection<Cases>("cases");
                    var query = collection
                        .Find(Query.EQ("Case_Name", selectedCase))
                        .Select(x => x.Id).FirstOrDefault();

                    string caseID = query.ToString();
                    int caseIDnr = Int32.Parse(caseID);
                    caseIDtopass = caseID;              // Sets the value of the caseIDtopass variable so it can be called from the "Save" form, used for screenshots
                    return caseIDnr;
                }
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("You must select a case from the drop down menu at the top", "Error");
                return null;
            }
        }

        public void Submit_Click(object sender, EventArgs e)
        {
            string note = NoteBox.Text;
            int? caseID = ReturnCaseID();
            if (caseID != null)
            {
                int caseIDnr = caseID ?? default(int);
                int time = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                NoteInsert(note, time, caseIDnr, attachID.ToString(), screenID.ToString());
                FillTheView(displayNotes);
                NoteBox.Clear();
                screenID = null;                // Resets the "flag" for screenshots
                attachID = null;                // Resets the "flag" for attachments
            }
            else
            {
                displayNotes.Items.Add("", "You must select a case before you can submit");
            }
        }

        private void NoteInsert(string note_text, int time, int caseID, string attachmentID, string screenshotID)
        {
            /* Happens when the "Submit" button is pressed, takes the information 
             * defined in "Submit_Click" function and adds it to the database */
            using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
            {
                var collection = db.GetCollection<Entry>("entries");
                var entry = new Entry
                {
                    Note_Text = note_text,
                    Attach_ID = attachmentID,
                    Screen_ID = screenshotID,
                    Time = time,
                    Case_ID = caseID
                };
                collection.Insert(entry);
            }
        }
        private void CaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* When the selected case is changed, it runs the function to fill 
             * the note display up again with the newly selected case */
            FillTheView(displayNotes);
        }

        public static int? screenID = null;
        private void Screenshot_Click(object sender, EventArgs e)
        {   // Launches the "SelectArea" form using the same method as the "MainMenu", redefined below
            int? caseID = ReturnCaseID();
            if (caseID != null)
            {
                LoadForm(new SelectArea());
            }
        }
        private void LoadForm(Form frm)
        {   // Handles how a new form is shown
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            this.Hide();
            frm.Show();
        }
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {   // Handles what happens when a new form, launched from this form, is closed
            this.Show();
        }
    }
}
