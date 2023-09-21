namespace Synthesis_assignment
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.pbLogo = new System.Windows.Forms.PictureBox();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.lblLogin = new System.Windows.Forms.Label();
			this.btnSignUp = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pbLogo
			// 
			this.pbLogo.BackColor = System.Drawing.Color.Ivory;
			this.pbLogo.Image = global::Synthesis_assignment.Properties.Resources.logo_transparent1;
			this.pbLogo.Location = new System.Drawing.Point(766, 57);
			this.pbLogo.Name = "pbLogo";
			this.pbLogo.Size = new System.Drawing.Size(800, 800);
			this.pbLogo.TabIndex = 20;
			this.pbLogo.TabStop = false;
			// 
			// tbUsername
			// 
			this.tbUsername.BackColor = System.Drawing.Color.Ivory;
			this.tbUsername.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(85)))), ((int)(((byte)(119)))));
			this.tbUsername.Location = new System.Drawing.Point(68, 366);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(367, 53);
			this.tbUsername.TabIndex = 26;
			// 
			// tbPassword
			// 
			this.tbPassword.BackColor = System.Drawing.Color.Ivory;
			this.tbPassword.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(85)))), ((int)(((byte)(119)))));
			this.tbPassword.Location = new System.Drawing.Point(68, 443);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(367, 53);
			this.tbPassword.TabIndex = 25;
			this.tbPassword.UseSystemPasswordChar = true;
			// 
			// btnLogin
			// 
			this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(85)))), ((int)(((byte)(119)))));
			this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnLogin.ForeColor = System.Drawing.Color.White;
			this.btnLogin.Location = new System.Drawing.Point(20, 608);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(428, 88);
			this.btnLogin.TabIndex = 24;
			this.btnLogin.Text = "LOGIN";
			this.btnLogin.UseVisualStyleBackColor = false;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(12, 441);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(55, 55);
			this.pictureBox3.TabIndex = 23;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(12, 364);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(55, 55);
			this.pictureBox2.TabIndex = 22;
			this.pictureBox2.TabStop = false;
			// 
			// lblLogin
			// 
			this.lblLogin.BackColor = System.Drawing.Color.Ivory;
			this.lblLogin.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(85)))), ((int)(((byte)(119)))));
			this.lblLogin.Location = new System.Drawing.Point(20, 302);
			this.lblLogin.Name = "lblLogin";
			this.lblLogin.Size = new System.Drawing.Size(428, 50);
			this.lblLogin.TabIndex = 21;
			this.lblLogin.Text = "Please log in to continue";
			// 
			// btnSignUp
			// 
			this.btnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(85)))), ((int)(((byte)(119)))));
			this.btnSignUp.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnSignUp.ForeColor = System.Drawing.Color.White;
			this.btnSignUp.Location = new System.Drawing.Point(20, 702);
			this.btnSignUp.Name = "btnSignUp";
			this.btnSignUp.Size = new System.Drawing.Size(428, 88);
			this.btnSignUp.TabIndex = 27;
			this.btnSignUp.Text = "SIGN UP";
			this.btnSignUp.UseVisualStyleBackColor = false;
			this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
			// 
			// cbRole
			// 
			// 
			// pictureBox4
			//
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Ivory;
			this.ClientSize = new System.Drawing.Size(1578, 944);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.btnSignUp);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.lblLogin);
			this.Controls.Add(this.pbLogo);
			this.Name = "Login";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private PictureBox pbLogo;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnLogin;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label lblLogin;
        private Button btnSignUp;
    }
}