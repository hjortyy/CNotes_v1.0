
namespace CNotes_v0._1
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.caseListBox = new System.Windows.Forms.ListBox();
            this.generate = new System.Windows.Forms.Button();
            this.screenshotCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // caseListBox
            // 
            this.caseListBox.FormattingEnabled = true;
            this.caseListBox.Location = new System.Drawing.Point(12, 9);
            this.caseListBox.Name = "caseListBox";
            this.caseListBox.Size = new System.Drawing.Size(160, 264);
            this.caseListBox.TabIndex = 0;
            this.caseListBox.SelectedIndexChanged += new System.EventHandler(this.caseListBox_SelectedIndexChanged);
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(383, 250);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(94, 23);
            this.generate.TabIndex = 2;
            this.generate.Text = "Generate Log";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // screenshotCheckBox
            // 
            this.screenshotCheckBox.AutoSize = true;
            this.screenshotCheckBox.Location = new System.Drawing.Point(191, 254);
            this.screenshotCheckBox.Name = "screenshotCheckBox";
            this.screenshotCheckBox.Size = new System.Drawing.Size(158, 17);
            this.screenshotCheckBox.TabIndex = 3;
            this.screenshotCheckBox.Text = "Include images in report text";
            this.screenshotCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(188, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 148);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 286);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.screenshotCheckBox);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.caseListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Report";
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox caseListBox;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.CheckBox screenshotCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}