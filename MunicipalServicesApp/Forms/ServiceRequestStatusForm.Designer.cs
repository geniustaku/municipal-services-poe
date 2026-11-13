namespace MunicipalServicesApp.Forms
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.GroupBox grpTrack;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.TextBox txtTrack;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.ListView lstRequests;
        private System.Windows.Forms.ColumnHeader colRef;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colArea;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colSubmitted;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.ProgressBar prgStatus;
        private System.Windows.Forms.Label lblStage;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblLinksTitle;
        private System.Windows.Forms.ListBox lstLinks;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabNext;
        private System.Windows.Forms.TabPage tabDepartments;
        private System.Windows.Forms.TabPage tabRoute;
        private System.Windows.Forms.TabPage tabTrees;
        private System.Windows.Forms.ListView lstNext;
        private System.Windows.Forms.ColumnHeader colNextRank;
        private System.Windows.Forms.ColumnHeader colNextRef;
        private System.Windows.Forms.ColumnHeader colNextTitle;
        private System.Windows.Forms.ColumnHeader colNextPriority;
        private System.Windows.Forms.ColumnHeader colNextDays;
        private System.Windows.Forms.ColumnHeader colNextStatus;
        private System.Windows.Forms.Label lblWorkOrderTitle;
        private System.Windows.Forms.ListBox lstWorkOrder;
        private System.Windows.Forms.TreeView tvDepartments;
        private System.Windows.Forms.Label lblDeptInfo;
        private System.Windows.Forms.ListView lstRoute;
        private System.Windows.Forms.ColumnHeader colRouteFrom;
        private System.Windows.Forms.ColumnHeader colRouteTo;
        private System.Windows.Forms.ColumnHeader colRouteKm;
        private System.Windows.Forms.ColumnHeader colRouteOpen;
        private System.Windows.Forms.Label lblRouteInfo;
        private System.Windows.Forms.TextBox txtTrees;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Drawing.Color navy = System.Drawing.Color.FromArgb(31, 58, 95);
            System.Drawing.Font normal = new System.Drawing.Font("Segoe UI", 9F);

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.grpTrack = new System.Windows.Forms.GroupBox();
            this.lblTrack = new System.Windows.Forms.Label();
            this.txtTrack = new System.Windows.Forms.TextBox();
            this.btnTrack = new System.Windows.Forms.Button();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.lstRequests = new System.Windows.Forms.ListView();
            this.colRef = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.colArea = new System.Windows.Forms.ColumnHeader();
            this.colPriority = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colSubmitted = new System.Windows.Forms.ColumnHeader();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblRef = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.lblStage = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.lblLinksTitle = new System.Windows.Forms.Label();
            this.lstLinks = new System.Windows.Forms.ListBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabNext = new System.Windows.Forms.TabPage();
            this.tabDepartments = new System.Windows.Forms.TabPage();
            this.tabRoute = new System.Windows.Forms.TabPage();
            this.tabTrees = new System.Windows.Forms.TabPage();
            this.lstNext = new System.Windows.Forms.ListView();
            this.colNextRank = new System.Windows.Forms.ColumnHeader();
            this.colNextRef = new System.Windows.Forms.ColumnHeader();
            this.colNextTitle = new System.Windows.Forms.ColumnHeader();
            this.colNextPriority = new System.Windows.Forms.ColumnHeader();
            this.colNextDays = new System.Windows.Forms.ColumnHeader();
            this.colNextStatus = new System.Windows.Forms.ColumnHeader();
            this.lblWorkOrderTitle = new System.Windows.Forms.Label();
            this.lstWorkOrder = new System.Windows.Forms.ListBox();
            this.tvDepartments = new System.Windows.Forms.TreeView();
            this.lblDeptInfo = new System.Windows.Forms.Label();
            this.lstRoute = new System.Windows.Forms.ListView();
            this.colRouteFrom = new System.Windows.Forms.ColumnHeader();
            this.colRouteTo = new System.Windows.Forms.ColumnHeader();
            this.colRouteKm = new System.Windows.Forms.ColumnHeader();
            this.colRouteOpen = new System.Windows.Forms.ColumnHeader();
            this.lblRouteInfo = new System.Windows.Forms.Label();
            this.txtTrees = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpTrack.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabNext.SuspendLayout();
            this.tabDepartments.SuspendLayout();
            this.tabRoute.SuspendLayout();
            this.tabTrees.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = navy;
            this.pnlHeader.Controls.Add(this.lblSummary);
            this.pnlHeader.Controls.Add(this.lblSub);
            this.pnlHeader.Controls.Add(this.lblHeading);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 64);
            //
            // lblHeading
            //
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(22, 12);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Text = "Service Request Status";
            //
            // lblSub
            //
            this.lblSub.AutoSize = true;
            this.lblSub.Font = normal;
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(200, 212, 228);
            this.lblSub.Location = new System.Drawing.Point(24, 42);
            this.lblSub.Name = "lblSub";
            this.lblSub.Text = "Track a request with its reference number and see what the municipality is working on";
            //
            // lblSummary
            //
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.White;
            this.lblSummary.Location = new System.Drawing.Point(780, 22);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(400, 22);
            this.lblSummary.Text = "0 requests";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // grpTrack
            //
            this.grpTrack.Controls.Add(this.lblTrack);
            this.grpTrack.Controls.Add(this.txtTrack);
            this.grpTrack.Controls.Add(this.btnTrack);
            this.grpTrack.Font = normal;
            this.grpTrack.Location = new System.Drawing.Point(16, 76);
            this.grpTrack.Name = "grpTrack";
            this.grpTrack.Size = new System.Drawing.Size(320, 84);
            this.grpTrack.TabIndex = 0;
            this.grpTrack.TabStop = false;
            this.grpTrack.Text = "Track a request";
            //
            // lblTrack
            //
            this.lblTrack.AutoSize = true;
            this.lblTrack.Location = new System.Drawing.Point(14, 24);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Text = "Reference number, e.g. SR-1012 or MSA-...";
            //
            // txtTrack
            //
            this.txtTrack.Location = new System.Drawing.Point(16, 44);
            this.txtTrack.Name = "txtTrack";
            this.txtTrack.Size = new System.Drawing.Size(200, 23);
            this.txtTrack.TabIndex = 0;
            //
            // btnTrack
            //
            this.btnTrack.BackColor = navy;
            this.btnTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrack.ForeColor = System.Drawing.Color.White;
            this.btnTrack.Location = new System.Drawing.Point(224, 43);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(82, 26);
            this.btnTrack.TabIndex = 1;
            this.btnTrack.Text = "Track";
            this.btnTrack.UseVisualStyleBackColor = false;
            this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);
            //
            // grpFilter
            //
            this.grpFilter.Controls.Add(this.lblStatus);
            this.grpFilter.Controls.Add(this.cboStatus);
            this.grpFilter.Controls.Add(this.lblArea);
            this.grpFilter.Controls.Add(this.txtArea);
            this.grpFilter.Controls.Add(this.lblCategory);
            this.grpFilter.Controls.Add(this.txtCategory);
            this.grpFilter.Controls.Add(this.lblFrom);
            this.grpFilter.Controls.Add(this.dtpFrom);
            this.grpFilter.Controls.Add(this.lblTo);
            this.grpFilter.Controls.Add(this.dtpTo);
            this.grpFilter.Controls.Add(this.btnSearch);
            this.grpFilter.Controls.Add(this.btnClear);
            this.grpFilter.Font = normal;
            this.grpFilter.Location = new System.Drawing.Point(346, 76);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(838, 84);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter requests";
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(14, 24);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";
            //
            // cboStatus
            //
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new System.Drawing.Point(16, 44);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(120, 23);
            this.cboStatus.TabIndex = 0;
            //
            // lblArea
            //
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(144, 24);
            this.lblArea.Name = "lblArea";
            this.lblArea.Text = "Area (type any)";
            //
            // txtArea
            //
            this.txtArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtArea.Location = new System.Drawing.Point(146, 44);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(140, 23);
            this.txtArea.TabIndex = 1;
            //
            // lblCategory
            //
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(294, 24);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Category (type any)";
            //
            // txtCategory
            //
            this.txtCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCategory.Location = new System.Drawing.Point(296, 44);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(150, 23);
            this.txtCategory.TabIndex = 2;
            //
            // lblFrom
            //
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(454, 24);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Text = "Submitted from";
            //
            // dtpFrom
            //
            this.dtpFrom.Checked = false;
            this.dtpFrom.CustomFormat = "dd MMM yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(456, 44);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(120, 23);
            this.dtpFrom.TabIndex = 3;
            //
            // lblTo
            //
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(584, 24);
            this.lblTo.Name = "lblTo";
            this.lblTo.Text = "To";
            //
            // dtpTo
            //
            this.dtpTo.Checked = false;
            this.dtpTo.CustomFormat = "dd MMM yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(586, 44);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(120, 23);
            this.dtpTo.TabIndex = 4;
            //
            // btnSearch
            //
            this.btnSearch.BackColor = navy;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(714, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 26);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(774, 43);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 26);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // lblResults
            //
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblResults.Location = new System.Drawing.Point(16, 170);
            this.lblResults.Name = "lblResults";
            this.lblResults.Text = "All requests, newest first";
            //
            // lstRequests
            //
            this.lstRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colRef, this.colTitle, this.colCategory, this.colArea, this.colPriority, this.colStatus, this.colSubmitted });
            this.lstRequests.Font = normal;
            this.lstRequests.FullRowSelect = true;
            this.lstRequests.GridLines = true;
            this.lstRequests.HideSelection = false;
            this.lstRequests.Location = new System.Drawing.Point(16, 192);
            this.lstRequests.MultiSelect = false;
            this.lstRequests.Name = "lstRequests";
            this.lstRequests.Size = new System.Drawing.Size(770, 320);
            this.lstRequests.TabIndex = 2;
            this.lstRequests.UseCompatibleStateImageBehavior = false;
            this.lstRequests.View = System.Windows.Forms.View.Details;
            this.lstRequests.SelectedIndexChanged += new System.EventHandler(this.lstRequests_SelectedIndexChanged);
            this.colRef.Text = "Reference";
            this.colRef.Width = 72;
            this.colTitle.Text = "Request";
            this.colTitle.Width = 236;
            this.colCategory.Text = "Category";
            this.colCategory.Width = 110;
            this.colArea.Text = "Area";
            this.colArea.Width = 100;
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 64;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 80;
            this.colSubmitted.Text = "Submitted";
            this.colSubmitted.Width = 86;
            //
            // grpDetail
            //
            this.grpDetail.Controls.Add(this.lblRef);
            this.grpDetail.Controls.Add(this.lblDetail);
            this.grpDetail.Controls.Add(this.prgStatus);
            this.grpDetail.Controls.Add(this.lblStage);
            this.grpDetail.Controls.Add(this.lblHistoryTitle);
            this.grpDetail.Controls.Add(this.lstHistory);
            this.grpDetail.Controls.Add(this.lblLinksTitle);
            this.grpDetail.Controls.Add(this.lstLinks);
            this.grpDetail.Font = normal;
            this.grpDetail.Location = new System.Drawing.Point(796, 166);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(388, 346);
            this.grpDetail.TabIndex = 3;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Request details";
            //
            // lblRef
            //
            this.lblRef.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblRef.ForeColor = navy;
            this.lblRef.Location = new System.Drawing.Point(12, 22);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(364, 22);
            this.lblRef.Text = "Select or track a request";
            //
            // lblDetail
            //
            this.lblDetail.Location = new System.Drawing.Point(12, 46);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(364, 82);
            this.lblDetail.Text = "Click a request in the list, or type its reference number in Track a request.";
            //
            // prgStatus
            //
            this.prgStatus.Location = new System.Drawing.Point(12, 132);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(364, 16);
            //
            // lblStage
            //
            this.lblStage.Location = new System.Drawing.Point(12, 150);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(364, 18);
            this.lblStage.Text = "Submitted > Assigned > In progress > Resolved";
            //
            // lblHistoryTitle
            //
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.Location = new System.Drawing.Point(12, 172);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Text = "History";
            //
            // lstHistory
            //
            this.lstHistory.HorizontalScrollbar = true;
            this.lstHistory.IntegralHeight = false;
            this.lstHistory.Location = new System.Drawing.Point(12, 190);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(364, 70);
            //
            // lblLinksTitle
            //
            this.lblLinksTitle.AutoSize = true;
            this.lblLinksTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLinksTitle.Location = new System.Drawing.Point(12, 264);
            this.lblLinksTitle.Name = "lblLinksTitle";
            this.lblLinksTitle.Text = "Linked jobs";
            //
            // lstLinks
            //
            this.lstLinks.HorizontalScrollbar = true;
            this.lstLinks.IntegralHeight = false;
            this.lstLinks.Location = new System.Drawing.Point(12, 282);
            this.lstLinks.Name = "lstLinks";
            this.lstLinks.Size = new System.Drawing.Size(364, 54);
            //
            // tabs
            //
            this.tabs.Controls.Add(this.tabNext);
            this.tabs.Controls.Add(this.tabDepartments);
            this.tabs.Controls.Add(this.tabRoute);
            this.tabs.Controls.Add(this.tabTrees);
            this.tabs.Font = normal;
            this.tabs.Location = new System.Drawing.Point(16, 522);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1168, 190);
            this.tabs.TabIndex = 4;
            //
            // tabNext
            //
            this.tabNext.Controls.Add(this.lstNext);
            this.tabNext.Controls.Add(this.lblWorkOrderTitle);
            this.tabNext.Controls.Add(this.lstWorkOrder);
            this.tabNext.Location = new System.Drawing.Point(4, 24);
            this.tabNext.Name = "tabNext";
            this.tabNext.Padding = new System.Windows.Forms.Padding(6);
            this.tabNext.Size = new System.Drawing.Size(1160, 162);
            this.tabNext.Text = "Next to attend";
            this.tabNext.UseVisualStyleBackColor = true;
            //
            // lstNext
            //
            this.lstNext.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colNextRank, this.colNextRef, this.colNextTitle, this.colNextPriority, this.colNextDays, this.colNextStatus });
            this.lstNext.FullRowSelect = true;
            this.lstNext.GridLines = true;
            this.lstNext.HideSelection = false;
            this.lstNext.Location = new System.Drawing.Point(8, 8);
            this.lstNext.MultiSelect = false;
            this.lstNext.Name = "lstNext";
            this.lstNext.Size = new System.Drawing.Size(720, 146);
            this.lstNext.UseCompatibleStateImageBehavior = false;
            this.lstNext.View = System.Windows.Forms.View.Details;
            this.lstNext.SelectedIndexChanged += new System.EventHandler(this.lstNext_SelectedIndexChanged);
            this.colNextRank.Text = "#";
            this.colNextRank.Width = 34;
            this.colNextRef.Text = "Reference";
            this.colNextRef.Width = 76;
            this.colNextTitle.Text = "Request";
            this.colNextTitle.Width = 300;
            this.colNextPriority.Text = "Priority";
            this.colNextPriority.Width = 80;
            this.colNextDays.Text = "Days open";
            this.colNextDays.Width = 80;
            this.colNextStatus.Text = "Status";
            this.colNextStatus.Width = 120;
            //
            // lblWorkOrderTitle
            //
            this.lblWorkOrderTitle.AutoSize = true;
            this.lblWorkOrderTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWorkOrderTitle.Location = new System.Drawing.Point(740, 8);
            this.lblWorkOrderTitle.Name = "lblWorkOrderTitle";
            this.lblWorkOrderTitle.Text = "Order to do linked jobs in";
            //
            // lstWorkOrder
            //
            this.lstWorkOrder.IntegralHeight = false;
            this.lstWorkOrder.Location = new System.Drawing.Point(742, 28);
            this.lstWorkOrder.Name = "lstWorkOrder";
            this.lstWorkOrder.Size = new System.Drawing.Size(408, 126);
            //
            // tabDepartments
            //
            this.tabDepartments.Controls.Add(this.tvDepartments);
            this.tabDepartments.Controls.Add(this.lblDeptInfo);
            this.tabDepartments.Location = new System.Drawing.Point(4, 24);
            this.tabDepartments.Name = "tabDepartments";
            this.tabDepartments.Padding = new System.Windows.Forms.Padding(6);
            this.tabDepartments.Size = new System.Drawing.Size(1160, 162);
            this.tabDepartments.Text = "By department";
            this.tabDepartments.UseVisualStyleBackColor = true;
            //
            // tvDepartments
            //
            this.tvDepartments.HideSelection = false;
            this.tvDepartments.Location = new System.Drawing.Point(8, 8);
            this.tvDepartments.Name = "tvDepartments";
            this.tvDepartments.Size = new System.Drawing.Size(620, 146);
            this.tvDepartments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDepartments_AfterSelect);
            //
            // lblDeptInfo
            //
            this.lblDeptInfo.Location = new System.Drawing.Point(640, 8);
            this.lblDeptInfo.Name = "lblDeptInfo";
            this.lblDeptInfo.Size = new System.Drawing.Size(510, 146);
            this.lblDeptInfo.Text = "Open a department to see its categories and requests.";
            //
            // tabRoute
            //
            this.tabRoute.Controls.Add(this.lstRoute);
            this.tabRoute.Controls.Add(this.lblRouteInfo);
            this.tabRoute.Location = new System.Drawing.Point(4, 24);
            this.tabRoute.Name = "tabRoute";
            this.tabRoute.Padding = new System.Windows.Forms.Padding(6);
            this.tabRoute.Size = new System.Drawing.Size(1160, 162);
            this.tabRoute.Text = "Crew route";
            this.tabRoute.UseVisualStyleBackColor = true;
            //
            // lstRoute
            //
            this.lstRoute.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colRouteFrom, this.colRouteTo, this.colRouteKm, this.colRouteOpen });
            this.lstRoute.FullRowSelect = true;
            this.lstRoute.GridLines = true;
            this.lstRoute.Location = new System.Drawing.Point(8, 8);
            this.lstRoute.Name = "lstRoute";
            this.lstRoute.Size = new System.Drawing.Size(560, 146);
            this.lstRoute.UseCompatibleStateImageBehavior = false;
            this.lstRoute.View = System.Windows.Forms.View.Details;
            this.colRouteFrom.Text = "From";
            this.colRouteFrom.Width = 160;
            this.colRouteTo.Text = "To";
            this.colRouteTo.Width = 160;
            this.colRouteKm.Text = "Distance";
            this.colRouteKm.Width = 90;
            this.colRouteOpen.Text = "Open requests at To";
            this.colRouteOpen.Width = 130;
            //
            // lblRouteInfo
            //
            this.lblRouteInfo.Location = new System.Drawing.Point(580, 8);
            this.lblRouteInfo.Name = "lblRouteInfo";
            this.lblRouteInfo.Size = new System.Drawing.Size(570, 146);
            //
            // tabTrees
            //
            this.tabTrees.Controls.Add(this.txtTrees);
            this.tabTrees.Location = new System.Drawing.Point(4, 24);
            this.tabTrees.Name = "tabTrees";
            this.tabTrees.Padding = new System.Windows.Forms.Padding(6);
            this.tabTrees.Size = new System.Drawing.Size(1160, 162);
            this.tabTrees.Text = "Tree indexes";
            this.tabTrees.UseVisualStyleBackColor = true;
            //
            // txtTrees
            //
            this.txtTrees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrees.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtTrees.Multiline = true;
            this.txtTrees.Name = "txtTrees";
            this.txtTrees.ReadOnly = true;
            this.txtTrees.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTrees.WordWrap = false;
            //
            // btnBack
            //
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnBack.Location = new System.Drawing.Point(1064, 720);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 30);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back to menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // ServiceRequestStatusForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1200, 758);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.lstRequests);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpTrack);
            this.Controls.Add(this.pnlHeader);
            this.Font = normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ServiceRequestStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service Request Status";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpTrack.ResumeLayout(false);
            this.grpTrack.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.tabNext.ResumeLayout(false);
            this.tabNext.PerformLayout();
            this.tabDepartments.ResumeLayout(false);
            this.tabRoute.ResumeLayout(false);
            this.tabTrees.ResumeLayout(false);
            this.tabTrees.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
