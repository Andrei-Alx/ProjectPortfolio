namespace Student_housing
{
    partial class ADMIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMIN));
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpAdminUsers = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbModifyPassword = new System.Windows.Forms.TextBox();
            this.tbModifyUsername = new System.Windows.Forms.TextBox();
            this.lbxAllUsers = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tpAdminComplaints = new System.Windows.Forms.TabPage();
            this.btnSendWarning = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxComplaintUser = new System.Windows.Forms.ComboBox();
            this.btnRemoveComplaint = new System.Windows.Forms.Button();
            this.lblPartyPlanDay = new System.Windows.Forms.Label();
            this.lbxAllComplaints = new System.Windows.Forms.ListBox();
            this.lblPlanParty = new System.Windows.Forms.Label();
            this.rtxCreateWarning = new System.Windows.Forms.RichTextBox();
            this.tpAdminTechnical = new System.Windows.Forms.TabPage();
            this.btnRemoveVisit = new System.Windows.Forms.Button();
            this.lbxAllScheduledVisits = new System.Windows.Forms.ListBox();
            this.btnScheduleVisit = new System.Windows.Forms.Button();
            this.dudVisitYear = new System.Windows.Forms.DomainUpDown();
            this.dudVisitMonth = new System.Windows.Forms.DomainUpDown();
            this.dudVisitDay = new System.Windows.Forms.DomainUpDown();
            this.lblPartyPlanYear = new System.Windows.Forms.Label();
            this.lblPartyPlanMonth = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRemoveIssue = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbxAllTechnicalIssues = new System.Windows.Forms.ListBox();
            this.tpAdminRules = new System.Windows.Forms.TabPage();
            this.lblGuidelines = new System.Windows.Forms.Label();
            this.lblRules = new System.Windows.Forms.Label();
            this.rtbGuidelines = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.rtbRules = new System.Windows.Forms.RichTextBox();
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRulesAdminTab = new System.Windows.Forms.Button();
            this.btnTechnicalAdminTab = new System.Windows.Forms.Button();
            this.btnComplaintsAdminTab = new System.Windows.Forms.Button();
            this.btnUsersAdminTab = new System.Windows.Forms.Button();
            this.buttonPannelAdmin = new System.Windows.Forms.Panel();
            this.pbxLogOut = new System.Windows.Forms.PictureBox();
            this.tcAdmin.SuspendLayout();
            this.tpAdminUsers.SuspendLayout();
            this.tpAdminComplaints.SuspendLayout();
            this.tpAdminTechnical.SuspendLayout();
            this.tpAdminRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogOut)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpAdminUsers);
            this.tcAdmin.Controls.Add(this.tpAdminComplaints);
            this.tcAdmin.Controls.Add(this.tpAdminTechnical);
            this.tcAdmin.Controls.Add(this.tpAdminRules);
            this.tcAdmin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAdmin.Location = new System.Drawing.Point(150, 143);
            this.tcAdmin.Multiline = true;
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1250, 556);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpAdminUsers
            // 
            this.tpAdminUsers.BackColor = System.Drawing.Color.Ivory;
            this.tpAdminUsers.Controls.Add(this.label13);
            this.tpAdminUsers.Controls.Add(this.label15);
            this.tpAdminUsers.Controls.Add(this.btnRemoveUser);
            this.tpAdminUsers.Controls.Add(this.btnUpdateUser);
            this.tpAdminUsers.Controls.Add(this.label12);
            this.tpAdminUsers.Controls.Add(this.label7);
            this.tpAdminUsers.Controls.Add(this.label11);
            this.tpAdminUsers.Controls.Add(this.label10);
            this.tpAdminUsers.Controls.Add(this.label8);
            this.tpAdminUsers.Controls.Add(this.tbModifyPassword);
            this.tpAdminUsers.Controls.Add(this.tbModifyUsername);
            this.tpAdminUsers.Controls.Add(this.lbxAllUsers);
            this.tpAdminUsers.Controls.Add(this.label9);
            this.tpAdminUsers.Controls.Add(this.label3);
            this.tpAdminUsers.Controls.Add(this.label19);
            this.tpAdminUsers.Controls.Add(this.textBox2);
            this.tpAdminUsers.Controls.Add(this.textBox1);
            this.tpAdminUsers.Controls.Add(this.button1);
            this.tpAdminUsers.Location = new System.Drawing.Point(4, 31);
            this.tpAdminUsers.Name = "tpAdminUsers";
            this.tpAdminUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdminUsers.Size = new System.Drawing.Size(1242, 521);
            this.tpAdminUsers.TabIndex = 0;
            this.tpAdminUsers.Text = "Users";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(32, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(375, 99);
            this.label13.TabIndex = 76;
            this.label13.Text = "Create a new user by adding the \r\nneccesary creitentials in \r\nthe text boxes:\r\n";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(308, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(363, 66);
            this.label15.TabIndex = 75;
            this.label15.Text = "Select a user from the right box\r\n to change its creditentials:";
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnRemoveUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveUser.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRemoveUser.Location = new System.Drawing.Point(595, 463);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(417, 42);
            this.btnRemoveUser.TabIndex = 74;
            this.btnRemoveUser.Text = "Remove the selected user";
            this.btnRemoveUser.UseVisualStyleBackColor = false;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateUser.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateUser.Location = new System.Drawing.Point(312, 335);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(158, 42);
            this.btnUpdateUser.TabIndex = 73;
            this.btnUpdateUser.Text = "Update a user";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(308, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 33);
            this.label12.TabIndex = 70;
            this.label12.Text = "Password:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.label7.Location = new System.Drawing.Point(589, 76);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 40);
            this.label7.TabIndex = 69;
            this.label7.Text = "View all users";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.label11.Location = new System.Drawing.Point(306, 76);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(218, 40);
            this.label11.TabIndex = 68;
            this.label11.Text = "Update a user";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.label10.Location = new System.Drawing.Point(21, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(218, 40);
            this.label10.TabIndex = 67;
            this.label10.Text = "Create a user";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(308, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 33);
            this.label8.TabIndex = 66;
            this.label8.Text = "Username:";
            // 
            // tbModifyPassword
            // 
            this.tbModifyPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbModifyPassword.Location = new System.Drawing.Point(312, 287);
            this.tbModifyPassword.Name = "tbModifyPassword";
            this.tbModifyPassword.Size = new System.Drawing.Size(158, 40);
            this.tbModifyPassword.TabIndex = 63;
            // 
            // tbModifyUsername
            // 
            this.tbModifyUsername.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbModifyUsername.Location = new System.Drawing.Point(312, 231);
            this.tbModifyUsername.Name = "tbModifyUsername";
            this.tbModifyUsername.Size = new System.Drawing.Size(158, 40);
            this.tbModifyUsername.TabIndex = 62;
            // 
            // lbxAllUsers
            // 
            this.lbxAllUsers.ColumnWidth = 748;
            this.lbxAllUsers.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAllUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lbxAllUsers.FormattingEnabled = true;
            this.lbxAllUsers.HorizontalScrollbar = true;
            this.lbxAllUsers.ItemHeight = 33;
            this.lbxAllUsers.Location = new System.Drawing.Point(595, 119);
            this.lbxAllUsers.Margin = new System.Windows.Forms.Padding(1);
            this.lbxAllUsers.Name = "lbxAllUsers";
            this.lbxAllUsers.Size = new System.Drawing.Size(417, 334);
            this.lbxAllUsers.TabIndex = 60;
            this.lbxAllUsers.SelectedIndexChanged += new System.EventHandler(this.lbxAllUsers_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.label9.Location = new System.Drawing.Point(5, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(218, 40);
            this.label9.TabIndex = 59;
            this.label9.Text = "User manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 33);
            this.label3.TabIndex = 58;
            this.label3.Text = "Password:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(32, 204);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 33);
            this.label19.TabIndex = 57;
            this.label19.Text = "Username:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(36, 283);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 40);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(36, 228);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 40);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(36, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create user";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tpAdminComplaints
            // 
            this.tpAdminComplaints.BackColor = System.Drawing.Color.Ivory;
            this.tpAdminComplaints.Controls.Add(this.btnSendWarning);
            this.tpAdminComplaints.Controls.Add(this.label2);
            this.tpAdminComplaints.Controls.Add(this.label1);
            this.tpAdminComplaints.Controls.Add(this.cbxComplaintUser);
            this.tpAdminComplaints.Controls.Add(this.btnRemoveComplaint);
            this.tpAdminComplaints.Controls.Add(this.lblPartyPlanDay);
            this.tpAdminComplaints.Controls.Add(this.lbxAllComplaints);
            this.tpAdminComplaints.Controls.Add(this.lblPlanParty);
            this.tpAdminComplaints.Controls.Add(this.rtxCreateWarning);
            this.tpAdminComplaints.Location = new System.Drawing.Point(4, 31);
            this.tpAdminComplaints.Name = "tpAdminComplaints";
            this.tpAdminComplaints.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdminComplaints.Size = new System.Drawing.Size(1242, 521);
            this.tpAdminComplaints.TabIndex = 1;
            this.tpAdminComplaints.Text = "Complaints";
            // 
            // btnSendWarning
            // 
            this.btnSendWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnSendWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendWarning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendWarning.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendWarning.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendWarning.Location = new System.Drawing.Point(905, 455);
            this.btnSendWarning.Margin = new System.Windows.Forms.Padding(1);
            this.btnSendWarning.Name = "btnSendWarning";
            this.btnSendWarning.Size = new System.Drawing.Size(219, 53);
            this.btnSendWarning.TabIndex = 42;
            this.btnSendWarning.Text = "Send a warning to the user";
            this.btnSendWarning.UseVisualStyleBackColor = false;
            this.btnSendWarning.Click += new System.EventHandler(this.btnSendWarning_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.label2.Location = new System.Drawing.Point(794, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 41;
            this.label2.Text = "Write a complaint:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(794, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 40;
            this.label1.Text = "Select a user:";
            // 
            // cbxComplaintUser
            // 
            this.cbxComplaintUser.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxComplaintUser.FormattingEnabled = true;
            this.cbxComplaintUser.ItemHeight = 41;
            this.cbxComplaintUser.Location = new System.Drawing.Point(798, 84);
            this.cbxComplaintUser.Name = "cbxComplaintUser";
            this.cbxComplaintUser.Size = new System.Drawing.Size(224, 49);
            this.cbxComplaintUser.TabIndex = 39;
            // 
            // btnRemoveComplaint
            // 
            this.btnRemoveComplaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnRemoveComplaint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveComplaint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveComplaint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveComplaint.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveComplaint.Location = new System.Drawing.Point(166, 455);
            this.btnRemoveComplaint.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveComplaint.Name = "btnRemoveComplaint";
            this.btnRemoveComplaint.Size = new System.Drawing.Size(176, 53);
            this.btnRemoveComplaint.TabIndex = 38;
            this.btnRemoveComplaint.Text = "Remove complaint";
            this.btnRemoveComplaint.UseVisualStyleBackColor = false;
            this.btnRemoveComplaint.Click += new System.EventHandler(this.btnRemoveComplaint_Click);
            // 
            // lblPartyPlanDay
            // 
            this.lblPartyPlanDay.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyPlanDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lblPartyPlanDay.Location = new System.Drawing.Point(30, 53);
            this.lblPartyPlanDay.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPartyPlanDay.Name = "lblPartyPlanDay";
            this.lblPartyPlanDay.Size = new System.Drawing.Size(209, 26);
            this.lblPartyPlanDay.TabIndex = 37;
            this.lblPartyPlanDay.Text = "All the complaints sent:";
            // 
            // lbxAllComplaints
            // 
            this.lbxAllComplaints.ColumnWidth = 748;
            this.lbxAllComplaints.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAllComplaints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lbxAllComplaints.FormattingEnabled = true;
            this.lbxAllComplaints.HorizontalScrollbar = true;
            this.lbxAllComplaints.ItemHeight = 33;
            this.lbxAllComplaints.Location = new System.Drawing.Point(34, 80);
            this.lbxAllComplaints.Margin = new System.Windows.Forms.Padding(1);
            this.lbxAllComplaints.Name = "lbxAllComplaints";
            this.lbxAllComplaints.ScrollAlwaysVisible = true;
            this.lbxAllComplaints.Size = new System.Drawing.Size(461, 334);
            this.lbxAllComplaints.TabIndex = 36;
            // 
            // lblPlanParty
            // 
            this.lblPlanParty.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanParty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.lblPlanParty.Location = new System.Drawing.Point(4, 9);
            this.lblPlanParty.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPlanParty.Name = "lblPlanParty";
            this.lblPlanParty.Size = new System.Drawing.Size(397, 40);
            this.lblPlanParty.TabIndex = 35;
            this.lblPlanParty.Text = "Create and review complaints";
            // 
            // rtxCreateWarning
            // 
            this.rtxCreateWarning.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxCreateWarning.Location = new System.Drawing.Point(798, 155);
            this.rtxCreateWarning.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.rtxCreateWarning.Name = "rtxCreateWarning";
            this.rtxCreateWarning.Size = new System.Drawing.Size(404, 286);
            this.rtxCreateWarning.TabIndex = 34;
            this.rtxCreateWarning.Text = "";
            // 
            // tpAdminTechnical
            // 
            this.tpAdminTechnical.BackColor = System.Drawing.Color.Ivory;
            this.tpAdminTechnical.Controls.Add(this.btnRemoveVisit);
            this.tpAdminTechnical.Controls.Add(this.lbxAllScheduledVisits);
            this.tpAdminTechnical.Controls.Add(this.btnScheduleVisit);
            this.tpAdminTechnical.Controls.Add(this.dudVisitYear);
            this.tpAdminTechnical.Controls.Add(this.dudVisitMonth);
            this.tpAdminTechnical.Controls.Add(this.dudVisitDay);
            this.tpAdminTechnical.Controls.Add(this.lblPartyPlanYear);
            this.tpAdminTechnical.Controls.Add(this.lblPartyPlanMonth);
            this.tpAdminTechnical.Controls.Add(this.label6);
            this.tpAdminTechnical.Controls.Add(this.btnRemoveIssue);
            this.tpAdminTechnical.Controls.Add(this.label5);
            this.tpAdminTechnical.Controls.Add(this.label4);
            this.tpAdminTechnical.Controls.Add(this.lbxAllTechnicalIssues);
            this.tpAdminTechnical.Location = new System.Drawing.Point(4, 31);
            this.tpAdminTechnical.Name = "tpAdminTechnical";
            this.tpAdminTechnical.Size = new System.Drawing.Size(1242, 521);
            this.tpAdminTechnical.TabIndex = 2;
            this.tpAdminTechnical.Text = "Technical Visits";
            // 
            // btnRemoveVisit
            // 
            this.btnRemoveVisit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnRemoveVisit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveVisit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveVisit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveVisit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveVisit.Location = new System.Drawing.Point(932, 460);
            this.btnRemoveVisit.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveVisit.Name = "btnRemoveVisit";
            this.btnRemoveVisit.Size = new System.Drawing.Size(176, 53);
            this.btnRemoveVisit.TabIndex = 49;
            this.btnRemoveVisit.Text = "Remove a vist";
            this.btnRemoveVisit.UseVisualStyleBackColor = false;
            this.btnRemoveVisit.Click += new System.EventHandler(this.btnRemoveVisit_Click);
            // 
            // lbxAllScheduledVisits
            // 
            this.lbxAllScheduledVisits.ColumnWidth = 748;
            this.lbxAllScheduledVisits.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAllScheduledVisits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lbxAllScheduledVisits.FormattingEnabled = true;
            this.lbxAllScheduledVisits.HorizontalScrollbar = true;
            this.lbxAllScheduledVisits.ItemHeight = 33;
            this.lbxAllScheduledVisits.Location = new System.Drawing.Point(805, 82);
            this.lbxAllScheduledVisits.Margin = new System.Windows.Forms.Padding(1);
            this.lbxAllScheduledVisits.Name = "lbxAllScheduledVisits";
            this.lbxAllScheduledVisits.Size = new System.Drawing.Size(417, 334);
            this.lbxAllScheduledVisits.TabIndex = 48;
            // 
            // btnScheduleVisit
            // 
            this.btnScheduleVisit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnScheduleVisit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScheduleVisit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScheduleVisit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnScheduleVisit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleVisit.Location = new System.Drawing.Point(542, 460);
            this.btnScheduleVisit.Margin = new System.Windows.Forms.Padding(1);
            this.btnScheduleVisit.Name = "btnScheduleVisit";
            this.btnScheduleVisit.Size = new System.Drawing.Size(176, 53);
            this.btnScheduleVisit.TabIndex = 47;
            this.btnScheduleVisit.Text = "Schedule a visit";
            this.btnScheduleVisit.UseVisualStyleBackColor = false;
            this.btnScheduleVisit.Click += new System.EventHandler(this.btnScheduleVisit_Click);
            // 
            // dudVisitYear
            // 
            this.dudVisitYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dudVisitYear.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dudVisitYear.Items.Add("2022");
            this.dudVisitYear.Items.Add("2023");
            this.dudVisitYear.Items.Add("2024");
            this.dudVisitYear.Location = new System.Drawing.Point(542, 308);
            this.dudVisitYear.Name = "dudVisitYear";
            this.dudVisitYear.ReadOnly = true;
            this.dudVisitYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dudVisitYear.Size = new System.Drawing.Size(176, 44);
            this.dudVisitYear.TabIndex = 46;
            this.dudVisitYear.Text = "2022";
            this.dudVisitYear.Wrap = true;
            // 
            // dudVisitMonth
            // 
            this.dudVisitMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dudVisitMonth.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dudVisitMonth.Items.Add("1");
            this.dudVisitMonth.Items.Add("2");
            this.dudVisitMonth.Items.Add("3");
            this.dudVisitMonth.Items.Add("4");
            this.dudVisitMonth.Items.Add("5");
            this.dudVisitMonth.Items.Add("6");
            this.dudVisitMonth.Items.Add("7");
            this.dudVisitMonth.Items.Add("8");
            this.dudVisitMonth.Items.Add("9");
            this.dudVisitMonth.Items.Add("10");
            this.dudVisitMonth.Items.Add("11");
            this.dudVisitMonth.Items.Add("12");
            this.dudVisitMonth.Location = new System.Drawing.Point(543, 210);
            this.dudVisitMonth.Name = "dudVisitMonth";
            this.dudVisitMonth.ReadOnly = true;
            this.dudVisitMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dudVisitMonth.Size = new System.Drawing.Size(175, 44);
            this.dudVisitMonth.TabIndex = 45;
            this.dudVisitMonth.Text = "1";
            this.dudVisitMonth.Wrap = true;
            // 
            // dudVisitDay
            // 
            this.dudVisitDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dudVisitDay.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dudVisitDay.Items.Add("1");
            this.dudVisitDay.Items.Add("2");
            this.dudVisitDay.Items.Add("3");
            this.dudVisitDay.Items.Add("4");
            this.dudVisitDay.Items.Add("5");
            this.dudVisitDay.Items.Add("6");
            this.dudVisitDay.Items.Add("7");
            this.dudVisitDay.Items.Add("8");
            this.dudVisitDay.Items.Add("9");
            this.dudVisitDay.Items.Add("10");
            this.dudVisitDay.Items.Add("11");
            this.dudVisitDay.Items.Add("12");
            this.dudVisitDay.Items.Add("13");
            this.dudVisitDay.Items.Add("14");
            this.dudVisitDay.Items.Add("15");
            this.dudVisitDay.Items.Add("16");
            this.dudVisitDay.Items.Add("17");
            this.dudVisitDay.Items.Add("18");
            this.dudVisitDay.Items.Add("19");
            this.dudVisitDay.Items.Add("20");
            this.dudVisitDay.Items.Add("21");
            this.dudVisitDay.Items.Add("22");
            this.dudVisitDay.Items.Add("23");
            this.dudVisitDay.Items.Add("24");
            this.dudVisitDay.Items.Add("25");
            this.dudVisitDay.Items.Add("26");
            this.dudVisitDay.Items.Add("27");
            this.dudVisitDay.Items.Add("28");
            this.dudVisitDay.Items.Add("29");
            this.dudVisitDay.Items.Add("30");
            this.dudVisitDay.Items.Add("31");
            this.dudVisitDay.Location = new System.Drawing.Point(542, 118);
            this.dudVisitDay.Name = "dudVisitDay";
            this.dudVisitDay.ReadOnly = true;
            this.dudVisitDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dudVisitDay.Size = new System.Drawing.Size(176, 44);
            this.dudVisitDay.TabIndex = 44;
            this.dudVisitDay.Text = "1";
            this.dudVisitDay.Wrap = true;
            // 
            // lblPartyPlanYear
            // 
            this.lblPartyPlanYear.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyPlanYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lblPartyPlanYear.Location = new System.Drawing.Point(536, 273);
            this.lblPartyPlanYear.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPartyPlanYear.Name = "lblPartyPlanYear";
            this.lblPartyPlanYear.Size = new System.Drawing.Size(125, 26);
            this.lblPartyPlanYear.TabIndex = 43;
            this.lblPartyPlanYear.Text = "Select an year:";
            // 
            // lblPartyPlanMonth
            // 
            this.lblPartyPlanMonth.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyPlanMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lblPartyPlanMonth.Location = new System.Drawing.Point(538, 173);
            this.lblPartyPlanMonth.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPartyPlanMonth.Name = "lblPartyPlanMonth";
            this.lblPartyPlanMonth.Size = new System.Drawing.Size(125, 26);
            this.lblPartyPlanMonth.TabIndex = 42;
            this.lblPartyPlanMonth.Text = "Select a month:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.label6.Location = new System.Drawing.Point(536, 82);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 26);
            this.label6.TabIndex = 41;
            this.label6.Text = "Select the day:";
            // 
            // btnRemoveIssue
            // 
            this.btnRemoveIssue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnRemoveIssue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveIssue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveIssue.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveIssue.Location = new System.Drawing.Point(140, 460);
            this.btnRemoveIssue.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveIssue.Name = "btnRemoveIssue";
            this.btnRemoveIssue.Size = new System.Drawing.Size(176, 53);
            this.btnRemoveIssue.TabIndex = 40;
            this.btnRemoveIssue.Text = "Remove issue";
            this.btnRemoveIssue.UseVisualStyleBackColor = false;
            this.btnRemoveIssue.Click += new System.EventHandler(this.btnRemoveIssue_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.label5.Location = new System.Drawing.Point(22, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 26);
            this.label5.TabIndex = 39;
            this.label5.Text = "All the isseues sent:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.label4.Location = new System.Drawing.Point(1, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(442, 40);
            this.label4.TabIndex = 38;
            this.label4.Text = "View and schedule technical visits";
            // 
            // lbxAllTechnicalIssues
            // 
            this.lbxAllTechnicalIssues.ColumnWidth = 748;
            this.lbxAllTechnicalIssues.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAllTechnicalIssues.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lbxAllTechnicalIssues.FormattingEnabled = true;
            this.lbxAllTechnicalIssues.HorizontalScrollbar = true;
            this.lbxAllTechnicalIssues.ItemHeight = 33;
            this.lbxAllTechnicalIssues.Location = new System.Drawing.Point(26, 82);
            this.lbxAllTechnicalIssues.Margin = new System.Windows.Forms.Padding(1);
            this.lbxAllTechnicalIssues.Name = "lbxAllTechnicalIssues";
            this.lbxAllTechnicalIssues.Size = new System.Drawing.Size(417, 334);
            this.lbxAllTechnicalIssues.TabIndex = 37;
            // 
            // tpAdminRules
            // 
            this.tpAdminRules.BackColor = System.Drawing.Color.Ivory;
            this.tpAdminRules.Controls.Add(this.lblGuidelines);
            this.tpAdminRules.Controls.Add(this.lblRules);
            this.tpAdminRules.Controls.Add(this.rtbGuidelines);
            this.tpAdminRules.Controls.Add(this.btnSave);
            this.tpAdminRules.Controls.Add(this.rtbRules);
            this.tpAdminRules.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tpAdminRules.Location = new System.Drawing.Point(4, 31);
            this.tpAdminRules.Name = "tpAdminRules";
            this.tpAdminRules.Size = new System.Drawing.Size(1242, 521);
            this.tpAdminRules.TabIndex = 3;
            this.tpAdminRules.Text = "Rules & Guidelines";
            // 
            // lblGuidelines
            // 
            this.lblGuidelines.AutoSize = true;
            this.lblGuidelines.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuidelines.Location = new System.Drawing.Point(901, 2);
            this.lblGuidelines.Name = "lblGuidelines";
            this.lblGuidelines.Size = new System.Drawing.Size(135, 33);
            this.lblGuidelines.TabIndex = 7;
            this.lblGuidelines.Text = "Guidelines";
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.Location = new System.Drawing.Point(254, 3);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(79, 33);
            this.lblRules.TabIndex = 6;
            this.lblRules.Text = "Rules";
            // 
            // rtbGuidelines
            // 
            this.rtbGuidelines.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbGuidelines.Location = new System.Drawing.Point(708, 36);
            this.rtbGuidelines.Name = "rtbGuidelines";
            this.rtbGuidelines.Size = new System.Drawing.Size(521, 387);
            this.rtbGuidelines.TabIndex = 4;
            this.rtbGuidelines.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(398, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(467, 53);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE TO FILE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rtbRules
            // 
            this.rtbRules.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbRules.Location = new System.Drawing.Point(30, 38);
            this.rtbRules.Name = "rtbRules";
            this.rtbRules.Size = new System.Drawing.Size(521, 387);
            this.rtbRules.TabIndex = 2;
            this.rtbRules.Text = "";
            // 
            // pbProfile
            // 
            this.pbProfile.Image = ((System.Drawing.Image)(resources.GetObject("pbProfile.Image")));
            this.pbProfile.Location = new System.Drawing.Point(12, 16);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(132, 121);
            this.pbProfile.TabIndex = 1;
            this.pbProfile.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.lblTitle.Location = new System.Drawing.Point(150, 54);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(499, 60);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Welcome back, <name>";
            // 
            // btnRulesAdminTab
            // 
            this.btnRulesAdminTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRulesAdminTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRulesAdminTab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRulesAdminTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnRulesAdminTab.Location = new System.Drawing.Point(-4, 372);
            this.btnRulesAdminTab.Name = "btnRulesAdminTab";
            this.btnRulesAdminTab.Size = new System.Drawing.Size(148, 69);
            this.btnRulesAdminTab.TabIndex = 14;
            this.btnRulesAdminTab.Text = "Rules/Guidelines";
            this.btnRulesAdminTab.UseVisualStyleBackColor = false;
            this.btnRulesAdminTab.Click += new System.EventHandler(this.btnRuesAdminTab_Click);
            // 
            // btnTechnicalAdminTab
            // 
            this.btnTechnicalAdminTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnTechnicalAdminTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTechnicalAdminTab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechnicalAdminTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnTechnicalAdminTab.Location = new System.Drawing.Point(-4, 297);
            this.btnTechnicalAdminTab.Name = "btnTechnicalAdminTab";
            this.btnTechnicalAdminTab.Size = new System.Drawing.Size(148, 69);
            this.btnTechnicalAdminTab.TabIndex = 13;
            this.btnTechnicalAdminTab.Text = "Technical Visits";
            this.btnTechnicalAdminTab.UseVisualStyleBackColor = false;
            this.btnTechnicalAdminTab.Click += new System.EventHandler(this.btnTechnicalAdminTab_Click);
            // 
            // btnComplaintsAdminTab
            // 
            this.btnComplaintsAdminTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnComplaintsAdminTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComplaintsAdminTab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplaintsAdminTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnComplaintsAdminTab.Location = new System.Drawing.Point(-4, 222);
            this.btnComplaintsAdminTab.Name = "btnComplaintsAdminTab";
            this.btnComplaintsAdminTab.Size = new System.Drawing.Size(148, 69);
            this.btnComplaintsAdminTab.TabIndex = 12;
            this.btnComplaintsAdminTab.Text = "Complaints";
            this.btnComplaintsAdminTab.UseVisualStyleBackColor = false;
            this.btnComplaintsAdminTab.Click += new System.EventHandler(this.btnComplaintsAdminTab_Click);
            // 
            // btnUsersAdminTab
            // 
            this.btnUsersAdminTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUsersAdminTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsersAdminTab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsersAdminTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnUsersAdminTab.Location = new System.Drawing.Point(-4, 147);
            this.btnUsersAdminTab.Name = "btnUsersAdminTab";
            this.btnUsersAdminTab.Size = new System.Drawing.Size(148, 69);
            this.btnUsersAdminTab.TabIndex = 11;
            this.btnUsersAdminTab.Text = "Users";
            this.btnUsersAdminTab.UseVisualStyleBackColor = false;
            this.btnUsersAdminTab.Click += new System.EventHandler(this.btnUsersAdminTab_Click);
            // 
            // buttonPannelAdmin
            // 
            this.buttonPannelAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.buttonPannelAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonPannelAdmin.Location = new System.Drawing.Point(131, 147);
            this.buttonPannelAdmin.Name = "buttonPannelAdmin";
            this.buttonPannelAdmin.Size = new System.Drawing.Size(13, 69);
            this.buttonPannelAdmin.TabIndex = 7;
            // 
            // pbxLogOut
            // 
            this.pbxLogOut.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogOut.Image")));
            this.pbxLogOut.Location = new System.Drawing.Point(1333, 54);
            this.pbxLogOut.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pbxLogOut.Name = "pbxLogOut";
            this.pbxLogOut.Size = new System.Drawing.Size(63, 62);
            this.pbxLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogOut.TabIndex = 15;
            this.pbxLogOut.TabStop = false;
            this.pbxLogOut.Click += new System.EventHandler(this.pbxLogOut_Click);
            // 
            // ADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1412, 711);
            this.Controls.Add(this.pbxLogOut);
            this.Controls.Add(this.buttonPannelAdmin);
            this.Controls.Add(this.btnRulesAdminTab);
            this.Controls.Add(this.btnTechnicalAdminTab);
            this.Controls.Add(this.btnComplaintsAdminTab);
            this.Controls.Add(this.btnUsersAdminTab);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbProfile);
            this.Controls.Add(this.tcAdmin);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ADMIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ADMIN";
            this.Load += new System.EventHandler(this.ADMIN_Load);
            this.tcAdmin.ResumeLayout(false);
            this.tpAdminUsers.ResumeLayout(false);
            this.tpAdminUsers.PerformLayout();
            this.tpAdminComplaints.ResumeLayout(false);
            this.tpAdminTechnical.ResumeLayout(false);
            this.tpAdminRules.ResumeLayout(false);
            this.tpAdminRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAdmin;
        private System.Windows.Forms.TabPage tpAdminUsers;
        private System.Windows.Forms.TabPage tpAdminComplaints;
        private System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRulesAdminTab;
        private System.Windows.Forms.Button btnTechnicalAdminTab;
        private System.Windows.Forms.Button btnComplaintsAdminTab;
        private System.Windows.Forms.Button btnUsersAdminTab;
        private System.Windows.Forms.Panel buttonPannelAdmin;
        private System.Windows.Forms.TabPage tpAdminTechnical;
        private System.Windows.Forms.TabPage tpAdminRules;
        private System.Windows.Forms.PictureBox pbxLogOut;
        private System.Windows.Forms.Label lblGuidelines;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.RichTextBox rtbGuidelines;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtbRules;
        private System.Windows.Forms.RichTextBox rtxCreateWarning;
        private System.Windows.Forms.Label lblPlanParty;
        private System.Windows.Forms.ListBox lbxAllComplaints;
        private System.Windows.Forms.Label lblPartyPlanDay;
        private System.Windows.Forms.Button btnRemoveComplaint;
        private System.Windows.Forms.Button btnSendWarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxComplaintUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRemoveIssue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbxAllTechnicalIssues;
        private System.Windows.Forms.Button btnRemoveVisit;
        private System.Windows.Forms.ListBox lbxAllScheduledVisits;
        private System.Windows.Forms.Button btnScheduleVisit;
        private System.Windows.Forms.DomainUpDown dudVisitYear;
        private System.Windows.Forms.DomainUpDown dudVisitMonth;
        private System.Windows.Forms.DomainUpDown dudVisitDay;
        private System.Windows.Forms.Label lblPartyPlanYear;
        private System.Windows.Forms.Label lblPartyPlanMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbxAllUsers;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbModifyPassword;
        private System.Windows.Forms.TextBox tbModifyUsername;
    }
}