namespace HRMatch
{
    partial class CreateJobPage
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
            this.tbJobTitle = new System.Windows.Forms.TextBox();
            this.labelJobTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboSkillSet = new System.Windows.Forms.ComboBox();
            this.checkedBoxSkills = new System.Windows.Forms.CheckedListBox();
            this.addJobWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // tbJobTitle
            // 
            this.tbJobTitle.Location = new System.Drawing.Point(132, 32);
            this.tbJobTitle.Name = "tbJobTitle";
            this.tbJobTitle.Size = new System.Drawing.Size(215, 20);
            this.tbJobTitle.TabIndex = 0;
            // 
            // labelJobTitle
            // 
            this.labelJobTitle.AutoSize = true;
            this.labelJobTitle.Location = new System.Drawing.Point(71, 35);
            this.labelJobTitle.Name = "labelJobTitle";
            this.labelJobTitle.Size = new System.Drawing.Size(47, 13);
            this.labelJobTitle.TabIndex = 9;
            this.labelJobTitle.Text = "Job Title";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(163, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(119, 20);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "Create Profile";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(185, 289);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Job";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(132, 58);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(215, 80);
            this.tbDescription.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Skill Set";
            // 
            // comboSkillSet
            // 
            this.comboSkillSet.FormattingEnabled = true;
            this.comboSkillSet.Location = new System.Drawing.Point(132, 145);
            this.comboSkillSet.Name = "comboSkillSet";
            this.comboSkillSet.Size = new System.Drawing.Size(215, 21);
            this.comboSkillSet.TabIndex = 17;
            this.comboSkillSet.SelectedIndexChanged += new System.EventHandler(this.comboSkillSet_SelectedIndexChanged);
            // 
            // checkedBoxSkills
            // 
            this.checkedBoxSkills.CheckOnClick = true;
            this.checkedBoxSkills.FormattingEnabled = true;
            this.checkedBoxSkills.Location = new System.Drawing.Point(42, 172);
            this.checkedBoxSkills.MultiColumn = true;
            this.checkedBoxSkills.Name = "checkedBoxSkills";
            this.checkedBoxSkills.Size = new System.Drawing.Size(361, 109);
            this.checkedBoxSkills.TabIndex = 18;
            // 
            // addJobWorker1
            // 
            this.addJobWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.addJobWorker1_DoWork);
            // 
            // CreateJobPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 324);
            this.Controls.Add(this.checkedBoxSkills);
            this.Controls.Add(this.comboSkillSet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.labelJobTitle);
            this.Controls.Add(this.tbJobTitle);
            this.Name = "CreateJobPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HRMatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbJobTitle;
        private System.Windows.Forms.Label labelJobTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboSkillSet;
        private System.Windows.Forms.CheckedListBox checkedBoxSkills;
        private System.ComponentModel.BackgroundWorker addJobWorker1;
    }
}

