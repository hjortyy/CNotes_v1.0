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
    public partial class CaseManager : Form
    {
        public CaseManager()
        {
            
            InitializeComponent();
            FillTheList(CaseListBox);
        }

        public class Cases
        {
            public int Id { get; set; }
            public string Case_Number { get; set; }
            public string Case_Name { get; set; }
            public string Start_Date { get; set; }
            public string End_Date { get; set; }
        }

        public void SetDateTimeFormat()
        {
            StartDateCal.Format = DateTimePickerFormat.Custom;
            StartDateCal.CustomFormat = "mm/dd/yyyy";
            EndDateCal.Format = DateTimePickerFormat.Custom;
            EndDateCal.CustomFormat = "mm/dd/yyyy";
        }

        

        private void FillTheList(ListBox listBox)
        {
            listBox.Items.Clear();
            using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
            {
                var collection = db.GetCollection<Cases>("cases");
                var queryID = collection
                    .FindAll()
                    .OrderBy(x => x.Id)
                    .Select(x => x.Id).ToList();
                foreach (var ID in queryID)
                {
                    string caseID = ID.ToString();
                    var queryNR = collection
                        .Find(Query.EQ("_id", ID))
                        .Select(x => x.Case_Number).Single();
                    var caseNR = queryNR.ToString();
                    var newit = caseID + "     " + caseNR;
                    listBox.Items.Add(newit);
                }
            }
        }

        public void CaseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CaseID = CaseListBox.SelectedItem.ToString();            //get Case_ID from selected item of ListBox
            int index = CaseID.IndexOf(' ');                                //trim the selected item string to fit in the query
            if (index > 0)
                CaseID = CaseID.Substring(0, index);
            int ID = Int32.Parse(CaseID);
            using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
            {
                var collection = db.GetCollection<Cases>("cases");
                var query = collection
                    .Find(Query.EQ("_id", ID))
                    .Select(x => new
                    {
                        number = x.Case_Number,
                        name = x.Case_Name,
                        startdateraw = x.Start_Date,
                        enddateraw = x.End_Date
                    }).ToList();
                
                foreach (var itemlist in query)
                {
                    string number = itemlist.number;
                    CaseNumberTextbox.Text = number.ToString();
                    string name = itemlist.name;
                    CaseNameTextbox.Text = name;
                    string startdateraw = itemlist.startdateraw;
                    if (startdateraw != null)
                    {
                        DateTime startdate = DateTime.Parse(
                                startdateraw,
                                new System.Globalization.CultureInfo("pt-BR"));
                        StartDateCal.Value = startdate;
                    }
                    string enddateraw = itemlist.enddateraw;
                    if (enddateraw != null)
                    {
                        DateTime enddate = DateTime.Parse(
                                    enddateraw,
                                    new System.Globalization.CultureInfo("pt-BR"));
                        EndDateCal.Value = enddate;
                    }

                }
            }
        }

        

        private void SubmitCaseChangesButton_Click(object sender, EventArgs e)
        {
            string CaseID = CaseListBox.SelectedItem.ToString();            //get Case_ID from selected item of ListBox
            int index = CaseID.IndexOf(' ');                                //trim the selected item string to fit in the query
            if (index > 0)
                CaseID = CaseID.Substring(0, index);
            int ID = Int32.Parse(CaseID);
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
            using (var db = new LiteDatabase(@"password=CNotes2021;filename=.\database\Lite.db"))
            {
                var collection = db.GetCollection<Cases>("cases");
                var update = collection
                    .FindById(ID);
                update.Case_Name = CaseName;
                update.Case_Number = CaseNumber;
                update.Start_Date = StartDate;
                update.End_Date = EndDate;
                collection.Update(update);
            }
            FillTheList(CaseListBox);
        }

        private void NewCaseButton_Click(object sender, EventArgs e)
        {
            LoadForm(new NewCase());
        }
        private void LoadForm(Form frm)
        {
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            this.Hide();
            frm.Show();
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            FillTheList(CaseListBox);
        }

        
    }
}
