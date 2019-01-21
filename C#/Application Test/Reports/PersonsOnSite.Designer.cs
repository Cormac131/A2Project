namespace Application_Test.Reports
{
    partial class PersonsOnSite
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonsOnSite));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.signInBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studio2_Systems_DBDataSet2 = new Application_Test.Studio2_Systems_DBDataSet2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.signInTableAdapter = new Application_Test.Studio2_Systems_DBDataSet2TableAdapters.SignInTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.signInBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studio2_Systems_DBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // signInBindingSource
            // 
            this.signInBindingSource.DataMember = "SignIn";
            this.signInBindingSource.DataSource = this.studio2_Systems_DBDataSet2;
            // 
            // studio2_Systems_DBDataSet2
            // 
            this.studio2_Systems_DBDataSet2.DataSetName = "Studio2_Systems_DBDataSet2";
            this.studio2_Systems_DBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(698, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Member";
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.signInBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Application_Test.Reports.PersonsOnSite.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 181);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(698, 413);
            this.reportViewer1.TabIndex = 16;
            // 
            // signInTableAdapter
            // 
            this.signInTableAdapter.ClearBeforeFill = true;
            // 
            // PersonsOnSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PersonsOnSite";
            this.Size = new System.Drawing.Size(724, 604);
            this.Load += new System.EventHandler(this.PersonsOnSite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.signInBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studio2_Systems_DBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource signInBindingSource;
        private Studio2_Systems_DBDataSet2 studio2_Systems_DBDataSet2;
        private Studio2_Systems_DBDataSet2TableAdapters.SignInTableAdapter signInTableAdapter;
    }
}
