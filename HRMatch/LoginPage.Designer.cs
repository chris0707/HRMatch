namespace HRMatch
{
    partial class LoginPage
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
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbEmployer = new System.Windows.Forms.RadioButton();
            this.rbJobSeeker = new System.Windows.Forms.RadioButton();
            this.logintBtn = new System.Windows.Forms.Button();
            this.registerLink = new System.Windows.Forms.Label();
            this.getResumeWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(122, 88);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(215, 20);
            this.tbUsername.TabIndex = 0;
            this.tbUsername.Text = "chrisTest@gmail.com";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(122, 114);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(215, 20);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.Text = "@Test123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username/Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "HRMatch";
            // 
            // rbEmployer
            // 
            this.rbEmployer.AutoSize = true;
            this.rbEmployer.Location = new System.Drawing.Point(131, 65);
            this.rbEmployer.Name = "rbEmployer";
            this.rbEmployer.Size = new System.Drawing.Size(68, 17);
            this.rbEmployer.TabIndex = 5;
            this.rbEmployer.TabStop = true;
            this.rbEmployer.Text = "Employer";
            this.rbEmployer.UseVisualStyleBackColor = true;
            this.rbEmployer.CheckedChanged += new System.EventHandler(this.rbEmployer_CheckedChanged);
            // 
            // rbJobSeeker
            // 
            this.rbJobSeeker.AutoSize = true;
            this.rbJobSeeker.Location = new System.Drawing.Point(222, 65);
            this.rbJobSeeker.Name = "rbJobSeeker";
            this.rbJobSeeker.Size = new System.Drawing.Size(79, 17);
            this.rbJobSeeker.TabIndex = 6;
            this.rbJobSeeker.TabStop = true;
            this.rbJobSeeker.Text = "Job Seeker";
            this.rbJobSeeker.UseVisualStyleBackColor = true;
            this.rbJobSeeker.CheckedChanged += new System.EventHandler(this.rbJobSeeker_CheckedChanged);
            // 
            // logintBtn
            // 
            this.logintBtn.Location = new System.Drawing.Point(192, 140);
            this.logintBtn.Name = "logintBtn";
            this.logintBtn.Size = new System.Drawing.Size(75, 23);
            this.logintBtn.TabIndex = 7;
            this.logintBtn.Text = "Login";
            this.logintBtn.UseVisualStyleBackColor = true;
            this.logintBtn.Click += new System.EventHandler(this.logintBtn_Click);
            // 
            // registerLink
            // 
            this.registerLink.AutoSize = true;
            this.registerLink.Location = new System.Drawing.Point(206, 176);
            this.registerLink.Name = "registerLink";
            this.registerLink.Size = new System.Drawing.Size(46, 13);
            this.registerLink.TabIndex = 8;
            this.registerLink.Text = "Register";
            this.registerLink.Click += new System.EventHandler(this.registerLink_Click);
            // 
            // getResumeWorker1
            // 
            this.getResumeWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getResumeWorker1_DoWork);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 217);
            this.Controls.Add(this.registerLink);
            this.Controls.Add(this.logintBtn);
            this.Controls.Add(this.rbJobSeeker);
            this.Controls.Add(this.rbEmployer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbEmployer;
        private System.Windows.Forms.RadioButton rbJobSeeker;
        private System.Windows.Forms.Button logintBtn;
        private System.Windows.Forms.Label registerLink;
        private System.ComponentModel.BackgroundWorker getResumeWorker1;
    }
}

