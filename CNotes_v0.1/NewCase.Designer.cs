
namespace CNotes_v0._1
{
    partial class NewCase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCase));
            this.EndDateCal = new System.Windows.Forms.DateTimePicker();
            this.StartDateCal = new System.Windows.Forms.DateTimePicker();
            this.CaseNameTextbox = new System.Windows.Forms.TextBox();
            this.CaseNumberTextbox = new System.Windows.Forms.TextBox();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.CaseNameLabel = new System.Windows.Forms.Label();
            this.CaseNumberLabel = new System.Windows.Forms.Label();
            this.SubmitCaseChangesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EndDateCal
            // 
            this.EndDateCal.Checked = false;
            this.EndDateCal.Location = new System.Drawing.Point(134, 154);
            this.EndDateCal.Name = "EndDateCal";
            this.EndDateCal.ShowCheckBox = true;
            this.EndDateCal.Size = new System.Drawing.Size(301, 20);
            this.EndDateCal.TabIndex = 25;
            // 
            // StartDateCal
            // 
            this.StartDateCal.Location = new System.Drawing.Point(134, 100);
            this.StartDateCal.Name = "StartDateCal";
            this.StartDateCal.Size = new System.Drawing.Size(301, 20);
            this.StartDateCal.TabIndex = 24;
            // 
            // CaseNameTextbox
            // 
            this.CaseNameTextbox.Location = new System.Drawing.Point(134, 50);
            this.CaseNameTextbox.Name = "CaseNameTextbox";
            this.CaseNameTextbox.Size = new System.Drawing.Size(301, 20);
            this.CaseNameTextbox.TabIndex = 23;
            // 
            // CaseNumberTextbox
            // 
            this.CaseNumberTextbox.Location = new System.Drawing.Point(134, 5);
            this.CaseNumberTextbox.Name = "CaseNumberTextbox";
            this.CaseNumberTextbox.Size = new System.Drawing.Size(301, 20);
            this.CaseNumberTextbox.TabIndex = 22;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(18, 160);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(82, 13);
            this.EndDateLabel.TabIndex = 21;
            this.EndDateLabel.Text = "Case End Date:";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(18, 106);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(85, 13);
            this.StartDateLabel.TabIndex = 20;
            this.StartDateLabel.Text = "Case Start Date:";
            // 
            // CaseNameLabel
            // 
            this.CaseNameLabel.AutoSize = true;
            this.CaseNameLabel.Location = new System.Drawing.Point(18, 53);
            this.CaseNameLabel.Name = "CaseNameLabel";
            this.CaseNameLabel.Size = new System.Drawing.Size(65, 13);
            this.CaseNameLabel.TabIndex = 19;
            this.CaseNameLabel.Text = "Case Name:";
            // 
            // CaseNumberLabel
            // 
            this.CaseNumberLabel.AutoSize = true;
            this.CaseNumberLabel.Location = new System.Drawing.Point(18, 8);
            this.CaseNumberLabel.Name = "CaseNumberLabel";
            this.CaseNumberLabel.Size = new System.Drawing.Size(74, 13);
            this.CaseNumberLabel.TabIndex = 18;
            this.CaseNumberLabel.Text = "Case Number:";
            // 
            // SubmitCaseChangesButton
            // 
            this.SubmitCaseChangesButton.Location = new System.Drawing.Point(360, 230);
            this.SubmitCaseChangesButton.Name = "SubmitCaseChangesButton";
            this.SubmitCaseChangesButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitCaseChangesButton.TabIndex = 17;
            this.SubmitCaseChangesButton.Text = "Submit Changes";
            this.SubmitCaseChangesButton.UseVisualStyleBackColor = true;
            this.SubmitCaseChangesButton.Click += new System.EventHandler(this.SubmitCaseChangesButton_Click_1);
            // 
            // NewCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 288);
            this.Controls.Add(this.EndDateCal);
            this.Controls.Add(this.StartDateCal);
            this.Controls.Add(this.CaseNameTextbox);
            this.Controls.Add(this.CaseNumberTextbox);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.CaseNameLabel);
            this.Controls.Add(this.CaseNumberLabel);
            this.Controls.Add(this.SubmitCaseChangesButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewCase";
            this.Text = "NewCase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker EndDateCal;
        private System.Windows.Forms.DateTimePicker StartDateCal;
        private System.Windows.Forms.TextBox CaseNameTextbox;
        private System.Windows.Forms.TextBox CaseNumberTextbox;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label CaseNameLabel;
        private System.Windows.Forms.Label CaseNumberLabel;
        private System.Windows.Forms.Button SubmitCaseChangesButton;
    }
}