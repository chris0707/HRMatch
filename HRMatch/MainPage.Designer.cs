namespace HRMatch
{
    partial class MainPage
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCand = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.getAllSeekersWorker1 = new System.ComponentModel.BackgroundWorker();
            this.getIndexWorker1 = new System.ComponentModel.BackgroundWorker();
            this.getAllJobPostingWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "HRMatch";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(297, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCand
            // 
            this.lblCand.AutoSize = true;
            this.lblCand.Location = new System.Drawing.Point(182, 41);
            this.lblCand.Name = "lblCand";
            this.lblCand.Size = new System.Drawing.Size(82, 13);
            this.lblCand.TabIndex = 7;
            this.lblCand.Text = "Job/Candidates";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Filter";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(12, 14);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(150, 13);
            this.lblFullName.TabIndex = 10;
            this.lblFullName.Text = "Welcome: Christopher Albarillo";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 36);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status: Employer/Seeker";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Location = new System.Drawing.Point(19, 60);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(145, 296);
            this.ButtonPanel.TabIndex = 12;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(185, 60);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(187, 296);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // getAllSeekersWorker1
            // 
            this.getAllSeekersWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getAllSeekersWorker1_DoWork);
            // 
            // getIndexWorker1
            // 
            this.getIndexWorker1.WorkerSupportsCancellation = true;
            this.getIndexWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getIndexWorker1_DoWork);
            // 
            // getAllJobPostingWorker1
            // 
            this.getAllJobPostingWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getAllJobPostingWorker1_DoWork);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(384, 397);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblCand);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label3);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCand;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.ListView listView1;
        private System.ComponentModel.BackgroundWorker getAllSeekersWorker1;
        private System.ComponentModel.BackgroundWorker getIndexWorker1;
        private System.ComponentModel.BackgroundWorker getAllJobPostingWorker1;
    }
}

