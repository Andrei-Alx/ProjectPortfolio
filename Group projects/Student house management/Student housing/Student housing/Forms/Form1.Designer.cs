namespace Student_housing
{
    partial class LOGIN
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btLogIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbxPassword = new System.Windows.Forms.MaskedTextBox();
            this.pbxUsernameLogin = new System.Windows.Forms.PictureBox();
            this.pbxPasswordLogin = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUsernameLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPasswordLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxUsername
            // 
            this.tbxUsername.BackColor = System.Drawing.Color.Ivory;
            this.tbxUsername.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.tbxUsername.Location = new System.Drawing.Point(133, 312);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(290, 53);
            this.tbxUsername.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.label1.Location = new System.Drawing.Point(71, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 85);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please log in";
            // 
            // btLogIn
            // 
            this.btLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btLogIn.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.btLogIn.Location = new System.Drawing.Point(81, 448);
            this.btLogIn.Name = "btLogIn";
            this.btLogIn.Size = new System.Drawing.Size(342, 77);
            this.btLogIn.TabIndex = 3;
            this.btLogIn.Text = "LOGIN";
            this.btLogIn.UseVisualStyleBackColor = false;
            this.btLogIn.Click += new System.EventHandler(this.btLogIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(537, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(877, 719);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tbxPassword
            // 
            this.tbxPassword.BackColor = System.Drawing.Color.Ivory;
            this.tbxPassword.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.ForeColor = System.Drawing.Color.Black;
            this.tbxPassword.Location = new System.Drawing.Point(133, 390);
            this.tbxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(290, 53);
            this.tbxPassword.TabIndex = 7;
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // pbxUsernameLogin
            // 
            this.pbxUsernameLogin.Image = ((System.Drawing.Image)(resources.GetObject("pbxUsernameLogin.Image")));
            this.pbxUsernameLogin.Location = new System.Drawing.Point(81, 312);
            this.pbxUsernameLogin.Margin = new System.Windows.Forms.Padding(4);
            this.pbxUsernameLogin.Name = "pbxUsernameLogin";
            this.pbxUsernameLogin.Size = new System.Drawing.Size(45, 38);
            this.pbxUsernameLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxUsernameLogin.TabIndex = 18;
            this.pbxUsernameLogin.TabStop = false;
            // 
            // pbxPasswordLogin
            // 
            this.pbxPasswordLogin.Image = ((System.Drawing.Image)(resources.GetObject("pbxPasswordLogin.Image")));
            this.pbxPasswordLogin.Location = new System.Drawing.Point(81, 390);
            this.pbxPasswordLogin.Margin = new System.Windows.Forms.Padding(4);
            this.pbxPasswordLogin.Name = "pbxPasswordLogin";
            this.pbxPasswordLogin.Size = new System.Drawing.Size(45, 38);
            this.pbxPasswordLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPasswordLogin.TabIndex = 19;
            this.pbxPasswordLogin.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM4";
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1412, 711);
            this.Controls.Add(this.pbxPasswordLogin);
            this.Controls.Add(this.pbxUsernameLogin);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btLogIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxUsername);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUsernameLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPasswordLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLogIn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MaskedTextBox tbxPassword;
        private System.Windows.Forms.PictureBox pbxUsernameLogin;
        private System.Windows.Forms.PictureBox pbxPasswordLogin;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort;
    }
}

