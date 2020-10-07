namespace HRMatch
{
    partial class ViewDetailsPartial
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSkills = new System.Windows.Forms.CheckedListBox();
            this.lblSkillsTitle = new System.Windows.Forms.Label();
            this.tbJobDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.deleteWorker1 = new System.ComponentModel.BackgroundWorker();
            this.updateJobWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(11, 52);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(165, 52);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSkills);
            this.panel1.Controls.Add(this.lblSkillsTitle);
            this.panel1.Controls.Add(this.tbJobDescription);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 239);
            this.panel1.TabIndex = 20;
            // 
            // cbSkills
            // 
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Location = new System.Drawing.Point(15, 126);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Size = new System.Drawing.Size(200, 94);
            this.cbSkills.TabIndex = 4;
            // 
            // lblSkillsTitle
            // 
            this.lblSkillsTitle.AutoSize = true;
            this.lblSkillsTitle.Location = new System.Drawing.Point(12, 110);
            this.lblSkillsTitle.Name = "lblSkillsTitle";
            this.lblSkillsTitle.Size = new System.Drawing.Size(80, 13);
            this.lblSkillsTitle.TabIndex = 3;
            this.lblSkillsTitle.Text = "Required Skills:";
            // 
            // tbJobDescription
            // 
            this.tbJobDescription.Location = new System.Drawing.Point(15, 28);
            this.tbJobDescription.Multiline = true;
            this.tbJobDescription.Name = "tbJobDescription";
            this.tbJobDescription.Size = new System.Drawing.Size(200, 59);
            this.tbJobDescription.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Description:";
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(12, 12);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(228, 26);
            this.tbTitle.TabIndex = 21;
            this.tbTitle.Text = "Software Developer";
            this.tbTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // deleteWorker1
            // 
            this.deleteWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.deleteWorker1_DoWork);
            // 
            // updateJobWorker1
            // 
            this.updateJobWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateJobWorker1_DoWork);
            // 
            // ViewDetailsPartial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 333);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Name = "ViewDetailsPartial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbJobDescription;
        private System.Windows.Forms.Label lblSkillsTitle;
        private System.Windows.Forms.CheckedListBox cbSkills;
        private System.ComponentModel.BackgroundWorker deleteWorker1;
        private System.ComponentModel.BackgroundWorker updateJobWorker1;
    }
}

