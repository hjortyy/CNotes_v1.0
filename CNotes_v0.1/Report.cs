using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;
using System.IO;
using System.IO.Compression;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace CNotes_v0._1
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            FillTheList(caseListBox);
        }

        /* ALL FOLLOWING CLASSES ARE TO EXPLICITLY STATE WHAT TABLES ARE IN THE LiteDB DATABASE */
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

        public class Screenshots
        {
            public int Id { get; set; }
            public string Hash { get; set; }
            public string Name { get; set; }
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

        private void FillTheList(ListBox listBox)
        {
            /* Fills the listview of cases with information gotten from the
             * database table "Cases". Fetches both Case_Id and Case_Number.*/
            listBox.Items.Clear();
            using (var db = new LiteDatabase(MainMenu.line))
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

        public void CreateHTML(int caseID)
        {
            /* Generates a .txt file of the needed html. Gets information from 
             * relevant database tables and puts it in the html.*/
            StreamWriter sw = new StreamWriter(".\\html.txt");
            
            sw.WriteLine("<h1><img style=\"float: right;\" src=\"logo.png\" alt=\"\" width=\"150\"/></h1>");
            sw.WriteLine("<h2>Author:</h2>");
            sw.WriteLine("<table style=\"width: 250px; \">");
            sw.WriteLine("<tbody>");
            sw.WriteLine("<tr>");
            using (var db = new LiteDatabase(MainMenu.line))
            {
                /* Gets information from "User" table*/
                var collection = db.GetCollection<User>("user");
                var userinfo = collection
                    .Find(Query.EQ("_id", 1))
                    .Select(x => new
                    {
                        firstname = x.First_Name,
                        lastname = x.Last_Name,
                        company = x.Company,
                        department = x.Department,
                        email = x.Contact_Email
                    }).ToList();
                foreach (var i in userinfo)
                {
                    string firstname = i.firstname;
                    string lastname = i.lastname;
                    string company = i.company;
                    string department = i.department;
                    string email = i.email;
                    sw.WriteLine("<td style=\"width: 80px; font-weight: bold;\">First Name:</td>");
                    sw.WriteLine("<td style=\"width: 170px; \">" + firstname+"</td>");
                    sw.WriteLine("</tr>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"width: 80px; font-weight: bold;\">Last Name:</td>");
                    sw.WriteLine("<td style=\"width: 920px; \">" + lastname + "</td>");
                    sw.WriteLine("</tr>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"width: 80px; font-weight: bold;\">Company:</td>");
                    sw.WriteLine("<td style=\"width: 920px; \">" + company + "</td>");
                    sw.WriteLine("</tr>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"width: 80px; font-weight: bold;\">Department:</td>");
                    sw.WriteLine("<td style=\"width: 920px; \">" + department + "</td>");
                    sw.WriteLine("</tr>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"width: 80px; font-weight: bold;\">Contact email:</td>");
                    sw.WriteLine("<td style=\"width: 920px; \">" + email + "</td>");
                }
            }
            sw.WriteLine("</tr>");
            sw.WriteLine("</tbody>");
            sw.WriteLine("</table>");
            sw.WriteLine("<h2>Case information:</h2>");
            sw.WriteLine("<table style=\"width: 350px; \">");
            sw.WriteLine("<tbody>");
            sw.WriteLine("<tr>");
            using (var db = new LiteDatabase(MainMenu.line))
            {
                var collection = db.GetCollection<Cases>("cases");
                var userinfo = collection
                    .Find(Query.EQ("_id", caseID))
                    .Select(x => new
                    {
                        casenumber = x.Case_Number,
                        startdate = x.Start_Date,
                        enddate = x.End_Date
                    }).ToList();
                foreach (var i in userinfo)
                {
                    string casenumber = i.casenumber;
                    string startdate = i.startdate;
                    string enddate = i.enddate;
                    sw.WriteLine("<td style=\"width: 80px; font-weight: bold;\">Case Number:</td>");
                    sw.WriteLine("<td style=\"width: 270px; \">" + casenumber + "</td>");
                    sw.WriteLine("</tr>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"width: 80px; font-weight: bold;\">Start date:</td>");
                    sw.WriteLine("<td style=\"width: 270px; \">" + startdate + "</td>");
                    sw.WriteLine("</tr>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"width: 80px; font-weight: bold;\">End date:</td>");
                    sw.WriteLine("<td style=\"width: 270px; \">" + enddate + "</td>");
                }
            }
            sw.WriteLine("</tr>");
            sw.WriteLine("</tbody>");
            sw.WriteLine("</table>");
            sw.WriteLine("<h2>Note Log:</h2>");
            sw.WriteLine("<table style=\"width: 540px; \">");
            sw.WriteLine("<tbody>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<td style=\"width: 90px; font-weight: bold;\">Time</td>");
            sw.WriteLine("<td style=\"width: 450px; font-weight: bold;\">Note Text</td>");
            sw.WriteLine("</tr>");
            using (var db = new LiteDatabase(MainMenu.line))
            {
                var collection = db.GetCollection<Entry>("entries");
                var query = collection
                    .Find(Query.EQ("Case_ID", caseID))
                    .OrderBy(x => x.Time)
                    .Select(x => new
                    {
                        notetext = x.Note_Text,
                        timestamp = x.Time,
                        screenshot = x.Screen_ID,
                        attachment = x.Attach_ID
                    }).ToList();
                foreach (var itemlist in query)
                {
                    string note = itemlist.notetext;
                    int time = itemlist.timestamp;
                    string screenID = itemlist.screenshot;
                    string attachID = itemlist.attachment;
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(time);
                    string humantime = dateTimeOffset.ToString("dd/MM/yy HH:mm");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"width: 90px; font-weight: bold; text-align: left; vertical-align: top;\" > " + humantime+" </td>");
                    if (screenID != null && screenshotCheckBox.Checked)
                    {
                        /* If there is a screenshot attached to the entry, and the user has chosen 
                         * to include screenshots in the pdf report, it gets information from that table*/
                        int screenIDnr = Int32.Parse(screenID);
                        var collection2 = db.GetCollection<Screenshots>("screenshots");
                        var query2 = collection2
                            .Find(Query.EQ("_id", screenIDnr))
                            .Select(x => new
                            {
                                name = x.Name,
                                hash = x.Hash
                            }).ToList();
                        foreach (var iii in query2)
                        {
                            string name = iii.name;
                            string hash = iii.hash;
                            string screenName = "Screenshots/" + caseID.ToString() + "/" + name + ".png";
                            sw.WriteLine("<td style=\"width: 450px; \">" + note + "<img style=\"float: right;\" src=\"" + screenName + "\" alt=\"\" width=\"450\"/>hash: " + hash + " <a href=\"" + screenName + "\">ScreenshotFullRes</a></td>");
                        }
                    }
                    else
                    {
                        sw.WriteLine("<td style=\"width: 450px; \">" + note+"</td>");
                    }
                    if (attachID != null)
                    {
                        /*If the note entry has a file attachment, then it gets information from that table*/
                        int attachIDnr = Int32.Parse(attachID);
                        var collection3 = db.GetCollection<Attachments>("attachments");
                        var query3 = collection3
                            .Find(Query.EQ("_id", attachIDnr))
                            .Select(x => new
                            {
                                name = x.Name,
                                hash = x.Hash
                            }).ToList();
                        foreach (var iiii in query3)
                        {
                            string name = iiii.name;
                            string hash = iiii.hash;
                            string attachName = "FileAttachments/" + caseID.ToString() + "/" + name;
                            sw.WriteLine("</tr>");
                            sw.WriteLine("<tr>");
                            sw.WriteLine("<td style=\"width: 90px; font - weight: bold; text - align: left; vertical - align: top; \" ></td>");
                            sw.WriteLine("<td style=\"width: 450px; \">File attachment's hash: " + hash + " <a href=\"" + attachName + "\">ClickHere</a></td>");
                        }
                    }
                    sw.WriteLine("</tr>");
                }
            }
            sw.WriteLine("</tbody>");
            sw.WriteLine("</table>");
            sw.WriteLine("<p style=\"text-align:right\">Report generated &nbsp;&nbsp;" + DateTime.Now.ToString("d. MMMM yyyy HH:mm") + "</p>");
            sw.Close();
        }

        public int caseid = 0;
        private void caseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Returns the Case_Id of the selected case when the selection changes */
            string CaseID = caseListBox.SelectedItem.ToString();            //get Case_ID from selected item of ListBox
            int index = CaseID.IndexOf(' ');                                //trim the selected item string to fit in the query
            if (index > 0)
                CaseID = CaseID.Substring(0, index);
            int cid = Int32.Parse(CaseID);
            caseid = cid;
        }
        public static void PdfSharpConvert(string filename)
        {
            /*Converts the html in html.txt to pdf*/
            string html = File.ReadAllText(".\\html.txt");
            PdfDocument pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
            pdf.Save(filename);
        }


        private void generate_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "zip";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //string zipfoldername = caseid.ToString() + "CasePacket.zip";
                string zippath = saveFileDialog1.FileName;
                string screenshots = @".\Screenshots\" + caseid.ToString();
                string attachments = @".\FileAttachments\" + caseid.ToString();
                string filename = caseid.ToString() + "CaseLog.pdf";
                CreateHTML(caseid);
                PdfSharpConvert(filename);
                string html = @".\html.txt";
                string caselog = @".\" + filename;
                using (FileStream zipfolder = new FileStream(zippath, FileMode.Create))
                {
                    using (ZipArchive zip = new ZipArchive(zipfolder, ZipArchiveMode.Create))
                    {
                        ZipArchiveEntry readmeEntry;
                        DirectoryInfo s = new DirectoryInfo(screenshots);
                        FileInfo[] screenshot = s.GetFiles("*");
                        foreach (FileInfo file in screenshot)
                        {
                            readmeEntry = zip.CreateEntryFromFile(screenshots + "\\" + file.Name, "Screenshots" + "/" + caseid.ToString() + "/" + file.Name);
                        }
                        DirectoryInfo a = new DirectoryInfo(attachments);
                        FileInfo[] attachment = a.GetFiles("*");
                        foreach (FileInfo file in attachment)
                        {
                            readmeEntry = zip.CreateEntryFromFile(attachments + "\\" + file.Name, "FileAttachments" + "/" + caseid.ToString() + "/" + file.Name);
                        }
                        zip.CreateEntryFromFile(html, "html.txt");
                        zip.CreateEntryFromFile(caselog, filename);
                    }
                }
            }
            else
            {

            }
        }
    }
}
