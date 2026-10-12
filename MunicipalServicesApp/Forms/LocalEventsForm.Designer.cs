namespace MunicipalServicesApp.Forms
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.ListView lstEvents;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colCat;
        private System.Windows.Forms.ColumnHeader colVenue;
        private System.Windows.Forms.GroupBox grpRecommend;
        private System.Windows.Forms.ListBox lstRecommend;
        private System.Windows.Forms.GroupBox grpRecent;
        private System.Windows.Forms.ListBox lstRecent;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.lstEvents = new System.Windows.Forms.ListView();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colCat = new System.Windows.Forms.ColumnHeader();
            this.colVenue = new System.Windows.Forms.ColumnHeader();
            this.grpRecommend = new System.Windows.Forms.GroupBox();
            this.lstRecommend = new System.Windows.Forms.ListBox();
            this.grpRecent = new System.Windows.Forms.GroupBox();
            this.lstRecent = new System.Windows.Forms.ListBox();
            this.lblDetail = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpRecommend.SuspendLayout();
            this.grpRecent.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.pnlHeader.Controls.Add(this.lblSub);
            this.pnlHeader.Controls.Add(this.lblHeading);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 64);
            this.pnlHeader.TabIndex = 0;
            //
            // lblHeading
            //
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(22, 12);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(329, 28);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Local Events and Announcements";
            //
            // lblSub
            //
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.lblSub.Location = new System.Drawing.Point(24, 42);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(300, 15);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Find what is happening in your municipality";
            //
            // grpSearch
            //
            this.grpSearch.Controls.Add(this.lblCat);
            this.grpSearch.Controls.Add(this.cboCategory);
            this.grpSearch.Controls.Add(this.lblFrom);
            this.grpSearch.Controls.Add(this.dtpFrom);
            this.grpSearch.Controls.Add(this.lblTo);
            this.grpSearch.Controls.Add(this.dtpTo);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.btnClear);
            this.grpSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpSearch.Location = new System.Drawing.Point(16, 76);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(852, 84);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search events";
            //
            // lblCat
            //
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(16, 24);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(55, 15);
            this.lblCat.TabIndex = 0;
            this.lblCat.Text = "Category";
            //
            // cboCategory
            //
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Location = new System.Drawing.Point(16, 44);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(210, 23);
            this.cboCategory.TabIndex = 1;
            //
            // lblFrom
            //
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(248, 24);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 15);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            //
            // dtpFrom
            //
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(248, 44);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(150, 23);
            this.dtpFrom.TabIndex = 3;
            //
            // lblTo
            //
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(416, 24);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 15);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To";
            //
            // dtpTo
            //
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(416, 44);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(150, 23);
            this.dtpTo.TabIndex = 5;
            //
            // btnSearch
            //
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(588, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 27);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(712, 42);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 27);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Show all";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // lblResults
            //
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblResults.Location = new System.Drawing.Point(16, 170);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(100, 17);
            this.lblResults.TabIndex = 2;
            this.lblResults.Text = "Upcoming events";
            //
            // lstEvents
            //
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colDate, this.colTitle, this.colCat, this.colVenue});
            this.lstEvents.FullRowSelect = true;
            this.lstEvents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstEvents.HideSelection = false;
            this.lstEvents.Location = new System.Drawing.Point(16, 192);
            this.lstEvents.MultiSelect = false;
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(560, 236);
            this.lstEvents.TabIndex = 3;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            //
            // colDate
            //
            this.colDate.Text = "Date";
            this.colDate.Width = 130;
            //
            // colTitle
            //
            this.colTitle.Text = "Event";
            this.colTitle.Width = 200;
            //
            // colCat
            //
            this.colCat.Text = "Category";
            this.colCat.Width = 110;
            //
            // colVenue
            //
            this.colVenue.Text = "Venue";
            this.colVenue.Width = 115;
            //
            // grpRecommend
            //
            this.grpRecommend.Controls.Add(this.lstRecommend);
            this.grpRecommend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpRecommend.Location = new System.Drawing.Point(588, 170);
            this.grpRecommend.Name = "grpRecommend";
            this.grpRecommend.Size = new System.Drawing.Size(280, 140);
            this.grpRecommend.TabIndex = 4;
            this.grpRecommend.TabStop = false;
            this.grpRecommend.Text = "Recommended for you";
            //
            // lstRecommend
            //
            this.lstRecommend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRecommend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstRecommend.FormattingEnabled = true;
            this.lstRecommend.ItemHeight = 15;
            this.lstRecommend.Location = new System.Drawing.Point(12, 24);
            this.lstRecommend.Name = "lstRecommend";
            this.lstRecommend.Size = new System.Drawing.Size(256, 105);
            this.lstRecommend.TabIndex = 0;
            //
            // grpRecent
            //
            this.grpRecent.Controls.Add(this.lstRecent);
            this.grpRecent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpRecent.Location = new System.Drawing.Point(588, 320);
            this.grpRecent.Name = "grpRecent";
            this.grpRecent.Size = new System.Drawing.Size(280, 108);
            this.grpRecent.TabIndex = 5;
            this.grpRecent.TabStop = false;
            this.grpRecent.Text = "Recent searches";
            //
            // lstRecent
            //
            this.lstRecent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRecent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstRecent.FormattingEnabled = true;
            this.lstRecent.ItemHeight = 15;
            this.lstRecent.Location = new System.Drawing.Point(12, 24);
            this.lstRecent.Name = "lstRecent";
            this.lstRecent.Size = new System.Drawing.Size(256, 75);
            this.lstRecent.TabIndex = 0;
            //
            // lblDetail
            //
            this.lblDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(65)))), ((int)(((byte)(72)))));
            this.lblDetail.Location = new System.Drawing.Point(16, 440);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Padding = new System.Windows.Forms.Padding(8);
            this.lblDetail.Size = new System.Drawing.Size(560, 70);
            this.lblDetail.TabIndex = 6;
            this.lblDetail.Text = "Select an event to see the details here.";
            //
            // btnBack
            //
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnBack.Location = new System.Drawing.Point(588, 440);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(280, 34);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // LocalEventsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 526);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.grpRecent);
            this.Controls.Add(this.grpRecommend);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(900, 565);
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Events and Announcements";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpRecommend.ResumeLayout(false);
            this.grpRecent.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
