
namespace CNotes_v0._1
{
    partial class Cnotes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("notetext");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("time");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cnotes));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Attach = new System.Windows.Forms.Button();
            this.Screenshot = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.NoteBox = new System.Windows.Forms.TextBox();
            this.CaseBox = new System.Windows.Forms.ComboBox();
            this.displayNotes = new System.Windows.Forms.ListView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Submit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.NoteBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CaseBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.displayNotes, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.39755F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.60245F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Attach);
            this.flowLayoutPanel1.Controls.Add(this.Screenshot);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 406);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(710, 41);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // Attach
            // 
            this.Attach.Location = new System.Drawing.Point(3, 3);
            this.Attach.Name = "Attach";
            this.Attach.Size = new System.Drawing.Size(75, 23);
            this.Attach.TabIndex = 1;
            this.Attach.Text = "Attach";
            this.Attach.UseVisualStyleBackColor = true;
            this.Attach.Click += new System.EventHandler(this.Attach_Click);
            // 
            // Screenshot
            // 
            this.Screenshot.Location = new System.Drawing.Point(84, 3);
            this.Screenshot.Name = "Screenshot";
            this.Screenshot.Size = new System.Drawing.Size(75, 23);
            this.Screenshot.TabIndex = 2;
            this.Screenshot.Text = "Screenshot";
            this.Screenshot.UseVisualStyleBackColor = true;
            this.Screenshot.Click += new System.EventHandler(this.Screenshot_Click);
            // 
            // Submit
            // 
            this.Submit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Submit.Location = new System.Drawing.Point(719, 330);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(78, 70);
            this.Submit.TabIndex = 1;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // NoteBox
            // 
            this.NoteBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteBox.Location = new System.Drawing.Point(3, 330);
            this.NoteBox.Multiline = true;
            this.NoteBox.Name = "NoteBox";
            this.NoteBox.Size = new System.Drawing.Size(710, 70);
            this.NoteBox.TabIndex = 2;
            // 
            // CaseBox
            // 
            this.CaseBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CaseBox.DropDownHeight = 66;
            this.CaseBox.FormattingEnabled = true;
            this.CaseBox.IntegralHeight = false;
            this.CaseBox.Location = new System.Drawing.Point(3, 6);
            this.CaseBox.Name = "CaseBox";
            this.CaseBox.Size = new System.Drawing.Size(296, 21);
            this.CaseBox.TabIndex = 3;
            this.CaseBox.SelectedIndexChanged += new System.EventHandler(this.CaseBox_SelectedIndexChanged);
            // 
            // displayNotes
            // 
            this.displayNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayNotes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.displayNotes.HideSelection = false;
            this.displayNotes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.displayNotes.LabelWrap = false;
            this.displayNotes.Location = new System.Drawing.Point(3, 37);
            this.displayNotes.Name = "displayNotes";
            this.displayNotes.Size = new System.Drawing.Size(710, 287);
            this.displayNotes.TabIndex = 4;
            this.displayNotes.UseCompatibleStateImageBehavior = false;
            this.displayNotes.View = System.Windows.Forms.View.Details;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Select an attachment";
            // 
            // Cnotes
            // 
            this.AcceptButton = this.Submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cnotes";
            this.Text = "CNotes";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Attach;
        private System.Windows.Forms.Button Screenshot;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox NoteBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox CaseBox;
        private System.Windows.Forms.ListView displayNotes;
    }
}