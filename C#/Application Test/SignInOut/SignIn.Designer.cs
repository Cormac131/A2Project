namespace Application_Test.SignInOut
{
    partial class SignIn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAddNewMember = new System.Windows.Forms.Button();
            this.btnSignInMember = new System.Windows.Forms.Button();
            this.lstFindMembers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMembershipType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(698, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.groupBox5.Controls.Add(this.btnAddNewMember);
            this.groupBox5.Controls.Add(this.btnSignInMember);
            this.groupBox5.Controls.Add(this.lstFindMembers);
            this.groupBox5.Controls.Add(this.btnSearch);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.cbxMembershipType);
            this.groupBox5.Location = new System.Drawing.Point(186, 184);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(339, 377);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sign In Member";
            // 
            // btnAddNewMember
            // 
            this.btnAddNewMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(203)))), ((int)(((byte)(207)))));
            this.btnAddNewMember.Location = new System.Drawing.Point(20, 331);
            this.btnAddNewMember.Name = "btnAddNewMember";
            this.btnAddNewMember.Size = new System.Drawing.Size(76, 37);
            this.btnAddNewMember.TabIndex = 6;
            this.btnAddNewMember.Text = "Add New Member";
            this.btnAddNewMember.UseVisualStyleBackColor = false;
            this.btnAddNewMember.Click += new System.EventHandler(this.btnAddNewMember_Click);
            // 
            // btnSignInMember
            // 
            this.btnSignInMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(203)))), ((int)(((byte)(207)))));
            this.btnSignInMember.Location = new System.Drawing.Point(235, 331);
            this.btnSignInMember.Name = "btnSignInMember";
            this.btnSignInMember.Size = new System.Drawing.Size(76, 37);
            this.btnSignInMember.TabIndex = 5;
            this.btnSignInMember.Text = "Sign In Member";
            this.btnSignInMember.UseVisualStyleBackColor = false;
            this.btnSignInMember.Click += new System.EventHandler(this.btnSignInMember_Click);
            // 
            // lstFindMembers
            // 
            this.lstFindMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7});
            this.lstFindMembers.FullRowSelect = true;
            this.lstFindMembers.GridLines = true;
            this.lstFindMembers.Location = new System.Drawing.Point(20, 87);
            this.lstFindMembers.MultiSelect = false;
            this.lstFindMembers.Name = "lstFindMembers";
            this.lstFindMembers.Size = new System.Drawing.Size(291, 238);
            this.lstFindMembers.TabIndex = 4;
            this.lstFindMembers.UseCompatibleStateImageBehavior = false;
            this.lstFindMembers.View = System.Windows.Forms.View.Details;
            this.lstFindMembers.SelectedIndexChanged += new System.EventHandler(this.lstFindMembers_SelectedIndexChanged);
            this.lstFindMembers.Click += new System.EventHandler(this.lstFindMembers_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 27;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Firstname";
            this.columnHeader2.Width = 58;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Surname";
            this.columnHeader3.Width = 54;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Membership Type";
            this.columnHeader7.Width = 147;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(203)))), ((int)(((byte)(207)))));
            this.btnSearch.Location = new System.Drawing.Point(236, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Membership Type:";
            // 
            // cbxMembershipType
            // 
            this.cbxMembershipType.FormattingEnabled = true;
            this.cbxMembershipType.Location = new System.Drawing.Point(124, 25);
            this.cbxMembershipType.Name = "cbxMembershipType";
            this.cbxMembershipType.Size = new System.Drawing.Size(188, 21);
            this.cbxMembershipType.TabIndex = 0;
            this.cbxMembershipType.SelectedIndexChanged += new System.EventHandler(this.cbxMembershipType_SelectedIndexChanged);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SignIn";
            this.Size = new System.Drawing.Size(724, 578);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMembershipType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lstFindMembers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnAddNewMember;
        private System.Windows.Forms.Button btnSignInMember;
    }
}
