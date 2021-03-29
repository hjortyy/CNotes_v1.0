
namespace CNotes_v0._1
{
    partial class CaseManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaseManager));
            this.CaseListBox = new System.Windows.Forms.ListBox();
            this.NewCaseButton = new System.Windows.Forms.Button();
            this.SubmitCaseChangesButton = new System.Windows.Forms.Button();
            this.CaseNumberLabel = new System.Windows.Forms.Label();
            this.CaseNameLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.CaseNumberTextbox = new System.Windows.Forms.TextBox();
            this.CaseNameTextbox = new System.Windows.Forms.TextBox();
            this.StartDateCal = new System.Windows.Forms.DateTimePicker();
            this.EndDateCal = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // CaseListBox
            // 
            this.CaseListBox.FormattingEnabled = true;
            this.CaseListBox.Location = new System.Drawing.Point(12, 12);
            this.CaseListBox.Name = "CaseListBox";
            this.CaseListBox.Size = new System.Drawing.Size(160, 225);
            this.CaseListBox.TabIndex = 0;
            this.CaseListBox.SelectedIndexChanged += new System.EventHandler(this.CaseListBox_SelectedIndexChanged);
            // 
            // NewCaseButton
            // 
            this.NewCaseButton.Location = new System.Drawing.Point(52, 253);
            this.NewCaseButton.Name = "NewCaseButton";
            this.NewCaseButton.Size = new System.Drawing.Size(75, 23);
            this.NewCaseButton.TabIndex = 1;
            this.NewCaseButton.Text = "New Case";
            this.NewCaseButton.UseVisualStyleBackColor = true;
            this.NewCaseButton.Click += new System.EventHandler(this.NewCaseButton_Click);
            // 
            // SubmitCaseChangesButton
            // 
            this.SubmitCaseChangesButton.Location = new System.Drawing.Point(547, 253);
            this.SubmitCaseChangesButton.Name = "SubmitCaseChangesButton";
            this.SubmitCaseChangesButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitCaseChangesButton.TabIndex = 2;
            this.SubmitCaseChangesButton.Text = "Submit Changes";
            this.SubmitCaseChangesButton.UseVisualStyleBackColor = true;
            this.SubmitCaseChangesButton.Click += new System.EventHandler(this.SubmitCaseChangesButton_Click);
            // 
            // CaseNumberLabel
            // 
            this.CaseNumberLabel.AutoSize = true;
            this.CaseNumberLabel.Location = new System.Drawing.Point(205, 31);
            this.CaseNumberLabel.Name = "CaseNumberLabel";
            this.CaseNumberLabel.Size = new System.Drawing.Size(74, 13);
            this.CaseNumberLabel.TabIndex = 3;
            this.CaseNumberLabel.Text = "Case Number:";
            // 
            // CaseNameLabel
            // 
            this.CaseNameLabel.AutoSize = true;
            this.CaseNameLabel.Location = new System.Drawing.Point(205, 76);
            this.CaseNameLabel.Name = "CaseNameLabel";
            this.CaseNameLabel.Size = new System.Drawing.Size(65, 13);
            this.CaseNameLabel.TabIndex = 4;
            this.CaseNameLabel.Text = "Case Name:";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(205, 129);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(85, 13);
            this.StartDateLabel.TabIndex = 5;
            this.StartDateLabel.Text = "Case Start Date:";
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(205, 183);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(82, 13);
            this.EndDateLabel.TabIndex = 6;
            this.EndDateLabel.Text = "Case End Date:";
            // 
            // CaseNumberTextbox
            // 
            this.CaseNumberTextbox.Location = new System.Drawing.Point(321, 28);
            this.CaseNumberTextbox.Name = "CaseNumberTextbox";
            this.CaseNumberTextbox.Size = new System.Drawing.Size(301, 20);
            this.CaseNumberTextbox.TabIndex = 8;
            // 
            // CaseNameTextbox
            // 
            this.CaseNameTextbox.Location = new System.Drawing.Point(321, 73);
            this.CaseNameTextbox.Name = "CaseNameTextbox";
            this.CaseNameTextbox.Size = new System.Drawing.Size(301, 20);
            this.CaseNameTextbox.TabIndex = 10;
            // 
            // StartDateCal
            // 
            this.StartDateCal.Location = new System.Drawing.Point(321, 123);
            this.StartDateCal.Name = "StartDateCal";
            this.StartDateCal.Size = new System.Drawing.Size(301, 20);
            this.StartDateCal.TabIndex = 15;
            // 
            // EndDateCal
            // 
            this.EndDateCal.Checked = false;
            this.EndDateCal.Location = new System.Drawing.Point(321, 177);
            this.EndDateCal.Name = "EndDateCal";
            this.EndDateCal.ShowCheckBox = true;
            this.EndDateCal.Size = new System.Drawing.Size(301, 20);
            this.EndDateCal.TabIndex = 16;
            // 
            // CaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 301);
            this.Controls.Add(this.EndDateCal);
            this.Controls.Add(this.StartDateCal);
            this.Controls.Add(this.CaseNameTextbox);
            this.Controls.Add(this.CaseNumberTextbox);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.CaseNameLabel);
            this.Controls.Add(this.CaseNumberLabel);
            this.Controls.Add(this.SubmitCaseChangesButton);
            this.Controls.Add(this.NewCaseButton);
            this.Controls.Add(this.CaseListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CaseManager";
            this.Text = "Case Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox CaseListBox;
        private System.Windows.Forms.Button NewCaseButton;
        private System.Windows.Forms.Button SubmitCaseChangesButton;
        private System.Windows.Forms.Label CaseNumberLabel;
        private System.Windows.Forms.Label CaseNameLabel;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.TextBox CaseNumberTextbox;
        private System.Windows.Forms.TextBox CaseNameTextbox;
        private System.Windows.Forms.DateTimePicker StartDateCal;
        private System.Windows.Forms.DateTimePicker EndDateCal;
    }
}