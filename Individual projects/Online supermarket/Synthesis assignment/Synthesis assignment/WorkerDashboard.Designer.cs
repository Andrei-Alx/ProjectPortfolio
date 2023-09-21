namespace Synthesis_assignment
{
    partial class WorkerDashboard
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
			this.tpDashboard = new System.Windows.Forms.TabControl();
			this.tpCustomerAndProduct = new System.Windows.Forms.TabPage();
			this.lblProductStatus = new System.Windows.Forms.Label();
			this.cbProductStatus = new System.Windows.Forms.ComboBox();
			this.btnViewAll = new System.Windows.Forms.Button();
			this.lblID = new System.Windows.Forms.Label();
			this.tbId = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbProductUnit = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbProductSubCategory = new System.Windows.Forms.ComboBox();
			this.lblImage = new System.Windows.Forms.Label();
			this.tbImage = new System.Windows.Forms.TextBox();
			this.btnModifyProductData = new System.Windows.Forms.Button();
			this.btnSetStatus = new System.Windows.Forms.Button();
			this.lbProductDisplay = new System.Windows.Forms.ListBox();
			this.lblProductCategory = new System.Windows.Forms.Label();
			this.cbProductCategory = new System.Windows.Forms.ComboBox();
			this.lblProductPrice = new System.Windows.Forms.Label();
			this.tbProductPrice = new System.Windows.Forms.TextBox();
			this.lblProductName = new System.Windows.Forms.Label();
			this.tbProductName = new System.Windows.Forms.TextBox();
			this.btnAddProduct = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.tpOrders = new System.Windows.Forms.TabPage();
			this.cbOrderStatus = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.lblOrderStatus = new System.Windows.Forms.Label();
			this.lblOrderId = new System.Windows.Forms.Label();
			this.lblOrders = new System.Windows.Forms.Label();
			this.tbOrderId = new System.Windows.Forms.TextBox();
			this.lbOrdersToBeShipped = new System.Windows.Forms.ListBox();
			this.lbOrders = new System.Windows.Forms.ListBox();
			this.tpCategories = new System.Windows.Forms.TabPage();
			this.btnLogOut = new System.Windows.Forms.Button();
			this.tpDashboard.SuspendLayout();
			this.tpCustomerAndProduct.SuspendLayout();
			this.tpOrders.SuspendLayout();
			this.SuspendLayout();
			// 
			// tpDashboard
			// 
			this.tpDashboard.Controls.Add(this.tpCustomerAndProduct);
			this.tpDashboard.Controls.Add(this.tpOrders);
			this.tpDashboard.Controls.Add(this.tpCategories);
			this.tpDashboard.Location = new System.Drawing.Point(17, 56);
			this.tpDashboard.Name = "tpDashboard";
			this.tpDashboard.SelectedIndex = 0;
			this.tpDashboard.Size = new System.Drawing.Size(1544, 847);
			this.tpDashboard.TabIndex = 2;
			// 
			// tpCustomerAndProduct
			// 
			this.tpCustomerAndProduct.BackColor = System.Drawing.Color.Ivory;
			this.tpCustomerAndProduct.Controls.Add(this.lblProductStatus);
			this.tpCustomerAndProduct.Controls.Add(this.cbProductStatus);
			this.tpCustomerAndProduct.Controls.Add(this.btnViewAll);
			this.tpCustomerAndProduct.Controls.Add(this.lblID);
			this.tpCustomerAndProduct.Controls.Add(this.tbId);
			this.tpCustomerAndProduct.Controls.Add(this.label2);
			this.tpCustomerAndProduct.Controls.Add(this.cbProductUnit);
			this.tpCustomerAndProduct.Controls.Add(this.label1);
			this.tpCustomerAndProduct.Controls.Add(this.cbProductSubCategory);
			this.tpCustomerAndProduct.Controls.Add(this.lblImage);
			this.tpCustomerAndProduct.Controls.Add(this.tbImage);
			this.tpCustomerAndProduct.Controls.Add(this.btnModifyProductData);
			this.tpCustomerAndProduct.Controls.Add(this.btnSetStatus);
			this.tpCustomerAndProduct.Controls.Add(this.lbProductDisplay);
			this.tpCustomerAndProduct.Controls.Add(this.lblProductCategory);
			this.tpCustomerAndProduct.Controls.Add(this.cbProductCategory);
			this.tpCustomerAndProduct.Controls.Add(this.lblProductPrice);
			this.tpCustomerAndProduct.Controls.Add(this.tbProductPrice);
			this.tpCustomerAndProduct.Controls.Add(this.lblProductName);
			this.tpCustomerAndProduct.Controls.Add(this.tbProductName);
			this.tpCustomerAndProduct.Controls.Add(this.btnAddProduct);
			this.tpCustomerAndProduct.Controls.Add(this.lblTitle);
			this.tpCustomerAndProduct.Location = new System.Drawing.Point(4, 34);
			this.tpCustomerAndProduct.Name = "tpCustomerAndProduct";
			this.tpCustomerAndProduct.Padding = new System.Windows.Forms.Padding(3);
			this.tpCustomerAndProduct.Size = new System.Drawing.Size(1536, 809);
			this.tpCustomerAndProduct.TabIndex = 0;
			this.tpCustomerAndProduct.Text = "Product manager";
			// 
			// lblProductStatus
			// 
			this.lblProductStatus.AutoSize = true;
			this.lblProductStatus.Location = new System.Drawing.Point(6, 431);
			this.lblProductStatus.Name = "lblProductStatus";
			this.lblProductStatus.Size = new System.Drawing.Size(60, 25);
			this.lblProductStatus.TabIndex = 70;
			this.lblProductStatus.Text = "Status";
			// 
			// cbProductStatus
			// 
			this.cbProductStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProductStatus.FormattingEnabled = true;
			this.cbProductStatus.Location = new System.Drawing.Point(129, 427);
			this.cbProductStatus.Name = "cbProductStatus";
			this.cbProductStatus.Size = new System.Drawing.Size(175, 33);
			this.cbProductStatus.TabIndex = 69;
			// 
			// btnViewAll
			// 
			this.btnViewAll.Location = new System.Drawing.Point(6, 621);
			this.btnViewAll.Name = "btnViewAll";
			this.btnViewAll.Size = new System.Drawing.Size(298, 41);
			this.btnViewAll.TabIndex = 68;
			this.btnViewAll.Text = "View all products";
			this.btnViewAll.UseVisualStyleBackColor = true;
			this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
			// 
			// lblID
			// 
			this.lblID.AutoSize = true;
			this.lblID.Location = new System.Drawing.Point(6, 113);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(28, 25);
			this.lblID.TabIndex = 67;
			this.lblID.Text = "Id";
			// 
			// tbId
			// 
			this.tbId.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbId.Location = new System.Drawing.Point(129, 109);
			this.tbId.Name = "tbId";
			this.tbId.Size = new System.Drawing.Size(175, 29);
			this.tbId.TabIndex = 66;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 376);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 25);
			this.label2.TabIndex = 65;
			this.label2.Text = "Unit";
			// 
			// cbProductUnit
			// 
			this.cbProductUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProductUnit.FormattingEnabled = true;
			this.cbProductUnit.Location = new System.Drawing.Point(129, 372);
			this.cbProductUnit.Name = "cbProductUnit";
			this.cbProductUnit.Size = new System.Drawing.Size(175, 33);
			this.cbProductUnit.TabIndex = 64;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 316);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 25);
			this.label1.TabIndex = 63;
			this.label1.Text = "Sub Category";
			// 
			// cbProductSubCategory
			// 
			this.cbProductSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProductSubCategory.FormattingEnabled = true;
			this.cbProductSubCategory.Location = new System.Drawing.Point(129, 317);
			this.cbProductSubCategory.Name = "cbProductSubCategory";
			this.cbProductSubCategory.Size = new System.Drawing.Size(175, 33);
			this.cbProductSubCategory.TabIndex = 62;
			// 
			// lblImage
			// 
			this.lblImage.AutoSize = true;
			this.lblImage.Location = new System.Drawing.Point(6, 484);
			this.lblImage.Name = "lblImage";
			this.lblImage.Size = new System.Drawing.Size(62, 25);
			this.lblImage.TabIndex = 61;
			this.lblImage.Text = "Image";
			// 
			// tbImage
			// 
			this.tbImage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbImage.Location = new System.Drawing.Point(129, 478);
			this.tbImage.Name = "tbImage";
			this.tbImage.Size = new System.Drawing.Size(175, 29);
			this.tbImage.TabIndex = 60;
			// 
			// btnModifyProductData
			// 
			this.btnModifyProductData.Location = new System.Drawing.Point(6, 575);
			this.btnModifyProductData.Name = "btnModifyProductData";
			this.btnModifyProductData.Size = new System.Drawing.Size(298, 41);
			this.btnModifyProductData.TabIndex = 31;
			this.btnModifyProductData.Text = "Modify product data";
			this.btnModifyProductData.UseVisualStyleBackColor = true;
			this.btnModifyProductData.Click += new System.EventHandler(this.btnModifyProductData_Click);
			// 
			// btnSetStatus
			// 
			this.btnSetStatus.Location = new System.Drawing.Point(6, 667);
			this.btnSetStatus.Name = "btnSetStatus";
			this.btnSetStatus.Size = new System.Drawing.Size(298, 41);
			this.btnSetStatus.TabIndex = 20;
			this.btnSetStatus.Text = "Set product status\r\n";
			this.btnSetStatus.UseVisualStyleBackColor = true;
			this.btnSetStatus.Click += new System.EventHandler(this.btnSetStatus_Click);
			// 
			// lbProductDisplay
			// 
			this.lbProductDisplay.FormattingEnabled = true;
			this.lbProductDisplay.HorizontalScrollbar = true;
			this.lbProductDisplay.ItemHeight = 25;
			this.lbProductDisplay.Location = new System.Drawing.Point(542, 67);
			this.lbProductDisplay.Name = "lbProductDisplay";
			this.lbProductDisplay.Size = new System.Drawing.Size(973, 679);
			this.lbProductDisplay.TabIndex = 12;
			this.lbProductDisplay.SelectedIndexChanged += new System.EventHandler(this.lbProductDisplay_SelectedIndexChanged);
			// 
			// lblProductCategory
			// 
			this.lblProductCategory.AutoSize = true;
			this.lblProductCategory.Location = new System.Drawing.Point(6, 260);
			this.lblProductCategory.Name = "lblProductCategory";
			this.lblProductCategory.Size = new System.Drawing.Size(84, 25);
			this.lblProductCategory.TabIndex = 7;
			this.lblProductCategory.Text = "Category";
			// 
			// cbProductCategory
			// 
			this.cbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProductCategory.FormattingEnabled = true;
			this.cbProductCategory.Location = new System.Drawing.Point(129, 260);
			this.cbProductCategory.Name = "cbProductCategory";
			this.cbProductCategory.Size = new System.Drawing.Size(175, 33);
			this.cbProductCategory.TabIndex = 6;
			this.cbProductCategory.SelectedIndexChanged += new System.EventHandler(this.cbProductCategory_SelectedIndexChanged);
			// 
			// lblProductPrice
			// 
			this.lblProductPrice.AutoSize = true;
			this.lblProductPrice.Location = new System.Drawing.Point(6, 211);
			this.lblProductPrice.Name = "lblProductPrice";
			this.lblProductPrice.Size = new System.Drawing.Size(49, 25);
			this.lblProductPrice.TabIndex = 5;
			this.lblProductPrice.Text = "Price";
			// 
			// tbProductPrice
			// 
			this.tbProductPrice.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbProductPrice.Location = new System.Drawing.Point(129, 211);
			this.tbProductPrice.Name = "tbProductPrice";
			this.tbProductPrice.Size = new System.Drawing.Size(175, 29);
			this.tbProductPrice.TabIndex = 4;
			// 
			// lblProductName
			// 
			this.lblProductName.AutoSize = true;
			this.lblProductName.Location = new System.Drawing.Point(6, 160);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(59, 25);
			this.lblProductName.TabIndex = 3;
			this.lblProductName.Text = "Name";
			// 
			// tbProductName
			// 
			this.tbProductName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbProductName.Location = new System.Drawing.Point(129, 160);
			this.tbProductName.Name = "tbProductName";
			this.tbProductName.Size = new System.Drawing.Size(175, 29);
			this.tbProductName.TabIndex = 2;
			// 
			// btnAddProduct
			// 
			this.btnAddProduct.Location = new System.Drawing.Point(6, 529);
			this.btnAddProduct.Name = "btnAddProduct";
			this.btnAddProduct.Size = new System.Drawing.Size(298, 41);
			this.btnAddProduct.TabIndex = 1;
			this.btnAddProduct.Text = "Add product";
			this.btnAddProduct.UseVisualStyleBackColor = true;
			this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblTitle.Location = new System.Drawing.Point(6, 67);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(272, 25);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Add a new product or edit one";
			// 
			// tpOrders
			// 
			this.tpOrders.BackColor = System.Drawing.Color.Ivory;
			this.tpOrders.Controls.Add(this.cbOrderStatus);
			this.tpOrders.Controls.Add(this.button2);
			this.tpOrders.Controls.Add(this.label10);
			this.tpOrders.Controls.Add(this.textBox7);
			this.tpOrders.Controls.Add(this.lblOrderStatus);
			this.tpOrders.Controls.Add(this.lblOrderId);
			this.tpOrders.Controls.Add(this.lblOrders);
			this.tpOrders.Controls.Add(this.tbOrderId);
			this.tpOrders.Controls.Add(this.lbOrdersToBeShipped);
			this.tpOrders.Controls.Add(this.lbOrders);
			this.tpOrders.Location = new System.Drawing.Point(4, 34);
			this.tpOrders.Name = "tpOrders";
			this.tpOrders.Padding = new System.Windows.Forms.Padding(3);
			this.tpOrders.Size = new System.Drawing.Size(1536, 809);
			this.tpOrders.TabIndex = 1;
			this.tpOrders.Text = "Order manager";
			// 
			// cbOrderStatus
			// 
			this.cbOrderStatus.FormattingEnabled = true;
			this.cbOrderStatus.Location = new System.Drawing.Point(122, 177);
			this.cbOrderStatus.Name = "cbOrderStatus";
			this.cbOrderStatus.Size = new System.Drawing.Size(199, 33);
			this.cbOrderStatus.TabIndex = 10;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 308);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(317, 61);
			this.button2.TabIndex = 9;
			this.button2.Text = "Update order status";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label10.Location = new System.Drawing.Point(12, 252);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(99, 25);
			this.label10.TabIndex = 8;
			this.label10.Text = "Order total";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(122, 246);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(201, 31);
			this.textBox7.TabIndex = 7;
			// 
			// lblOrderStatus
			// 
			this.lblOrderStatus.AutoSize = true;
			this.lblOrderStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblOrderStatus.Location = new System.Drawing.Point(12, 183);
			this.lblOrderStatus.Name = "lblOrderStatus";
			this.lblOrderStatus.Size = new System.Drawing.Size(110, 25);
			this.lblOrderStatus.TabIndex = 6;
			this.lblOrderStatus.Text = "Order status";
			// 
			// lblOrderId
			// 
			this.lblOrderId.AutoSize = true;
			this.lblOrderId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblOrderId.Location = new System.Drawing.Point(12, 111);
			this.lblOrderId.Name = "lblOrderId";
			this.lblOrderId.Size = new System.Drawing.Size(78, 25);
			this.lblOrderId.TabIndex = 4;
			this.lblOrderId.Text = "Order id";
			// 
			// lblOrders
			// 
			this.lblOrders.AutoSize = true;
			this.lblOrders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblOrders.Location = new System.Drawing.Point(107, 39);
			this.lblOrders.Name = "lblOrders";
			this.lblOrders.Size = new System.Drawing.Size(178, 25);
			this.lblOrders.TabIndex = 3;
			this.lblOrders.Text = "Order management";
			// 
			// tbOrderId
			// 
			this.tbOrderId.Location = new System.Drawing.Point(122, 105);
			this.tbOrderId.Name = "tbOrderId";
			this.tbOrderId.Size = new System.Drawing.Size(201, 31);
			this.tbOrderId.TabIndex = 2;
			// 
			// lbOrdersToBeShipped
			// 
			this.lbOrdersToBeShipped.FormattingEnabled = true;
			this.lbOrdersToBeShipped.ItemHeight = 25;
			this.lbOrdersToBeShipped.Location = new System.Drawing.Point(1010, 6);
			this.lbOrdersToBeShipped.Name = "lbOrdersToBeShipped";
			this.lbOrdersToBeShipped.Size = new System.Drawing.Size(504, 804);
			this.lbOrdersToBeShipped.TabIndex = 1;
			// 
			// lbOrders
			// 
			this.lbOrders.FormattingEnabled = true;
			this.lbOrders.ItemHeight = 25;
			this.lbOrders.Location = new System.Drawing.Point(500, 6);
			this.lbOrders.Name = "lbOrders";
			this.lbOrders.Size = new System.Drawing.Size(504, 804);
			this.lbOrders.TabIndex = 0;
			// 
			// tpCategories
			// 
			this.tpCategories.BackColor = System.Drawing.Color.Ivory;
			this.tpCategories.Location = new System.Drawing.Point(4, 34);
			this.tpCategories.Name = "tpCategories";
			this.tpCategories.Padding = new System.Windows.Forms.Padding(3);
			this.tpCategories.Size = new System.Drawing.Size(1536, 809);
			this.tpCategories.TabIndex = 2;
			this.tpCategories.Text = "Category manager";
			// 
			// btnLogOut
			// 
			this.btnLogOut.Location = new System.Drawing.Point(1376, 12);
			this.btnLogOut.Name = "btnLogOut";
			this.btnLogOut.Size = new System.Drawing.Size(185, 38);
			this.btnLogOut.TabIndex = 46;
			this.btnLogOut.Text = "Log Out";
			this.btnLogOut.UseVisualStyleBackColor = true;
			this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
			// 
			// WorkerDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Ivory;
			this.ClientSize = new System.Drawing.Size(1578, 944);
			this.Controls.Add(this.btnLogOut);
			this.Controls.Add(this.tpDashboard);
			this.Name = "WorkerDashboard";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.WorkerDashboard_Load);
			this.tpDashboard.ResumeLayout(false);
			this.tpCustomerAndProduct.ResumeLayout(false);
			this.tpCustomerAndProduct.PerformLayout();
			this.tpOrders.ResumeLayout(false);
			this.tpOrders.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private TabControl tpDashboard;
        private TabPage tpCustomerAndProduct;
        private Label lblImage;
        private TextBox tbImage;
        private Button btnModifyProductData;
        private Button btnSetStatus;
        private Label lblProductCategory;
        private ComboBox cbProductCategory;
        private Label lblProductPrice;
        private TextBox tbProductPrice;
        private Label lblProductName;
        private TextBox tbProductName;
        private Button btnAddProduct;
        private Label lblTitle;
        private TabPage tpOrders;
        private ComboBox cbOrderStatus;
        private Button button2;
        private Label label10;
        private TextBox textBox7;
        private Label lblOrderStatus;
        private Label lblOrderId;
        private Label lblOrders;
        private TextBox tbOrderId;
        private ListBox lbOrdersToBeShipped;
        private ListBox lbOrders;
        private Button btnLogOut;
        private ListBox lbProductDisplay;
        private Label label2;
        private ComboBox cbProductUnit;
        private Label label1;
        private ComboBox cbProductSubCategory;
        private Label lblID;
        private TextBox tbId;
        private Button btnViewAll;
        private Label lblProductStatus;
        private ComboBox cbProductStatus;
        private TabPage tpCategories;
    }
}