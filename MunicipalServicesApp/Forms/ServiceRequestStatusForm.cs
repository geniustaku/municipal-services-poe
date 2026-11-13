// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.DataStructures;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class ServiceRequestStatusForm : Form
    {
        private readonly ServiceRequestService service = new ServiceRequestService();

        public ServiceRequestStatusForm(IssueRepository repository)
        {
            InitializeComponent();

            // anything reported on the Report Issues page this session can be tracked here
            int imported = service.ImportIssues(repository);

            cboStatus.Items.Add("All statuses");
            foreach (RequestStatus s in Enum.GetValues(typeof(RequestStatus)))
                cboStatus.Items.Add(ServiceRequest.StatusName(s));
            cboStatus.SelectedIndex = 0;

            // area and category are typed in, with suggestions from the data
            var areas = new AutoCompleteStringCollection();
            areas.AddRange(service.GetAreas().ToArray());
            txtArea.AutoCompleteCustomSource = areas;

            var categories = new AutoCompleteStringCollection();
            categories.AddRange(service.GetCategoryWords().ToArray());
            txtCategory.AutoCompleteCustomSource = categories;

            AcceptButton = btnTrack;

            ShowRequests(service.GetAll());
            lblResults.Text = "All requests, newest first";
            if (imported > 0)
                lblResults.Text += "   (" + imported + " from Report Issues this session)";

            lblSummary.Text = service.Count + " requests   |   " + service.OpenCount + " open";

            LoadNextToAttend();
            LoadDepartments();
            LoadRoute();
            txtTrees.Text = service.TreeReport();
        }

        // ---------------- tracking and filtering ----------------

        private void btnTrack_Click(object sender, EventArgs e)
        {
            ServiceRequest r = service.Track(txtTrack.Text);
            if (r == null)
            {
                MessageBox.Show(this, "No request found for \"" + txtTrack.Text.Trim() + "\".\n\n" +
                    "Reference numbers look like SR-1012. You can also use the MSA number you got on the Report Issues page.",
                    "Request not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowRequests(new List<ServiceRequest> { r });
            lblResults.Text = "Tracking " + r.Reference;
            lstRequests.Items[0].Selected = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? from = dtpFrom.Checked ? dtpFrom.Value : (DateTime?)null;
            DateTime? to = dtpTo.Checked ? dtpTo.Value : (DateTime?)null;

            if (from.HasValue && to.HasValue && from.Value.Date > to.Value.Date)
            {
                MessageBox.Show(this, "The From date is after the To date.", "Check the dates",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ServiceRequest> results = service.Search(cboStatus.SelectedItem.ToString(),
                txtArea.Text, txtCategory.Text, from, to);
            ShowRequests(results);
            lblResults.Text = results.Count + " request(s) found";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTrack.Clear();
            txtArea.Clear();
            txtCategory.Clear();
            cboStatus.SelectedIndex = 0;
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            ShowRequests(service.GetAll());
            lblResults.Text = "All requests, newest first";
        }

        private void ShowRequests(List<ServiceRequest> list)
        {
            lstRequests.BeginUpdate();
            lstRequests.Items.Clear();
            foreach (ServiceRequest r in list)
            {
                var item = new ListViewItem(r.Reference);
                item.SubItems.Add(r.Title);
                item.SubItems.Add(r.Category);
                item.SubItems.Add(r.Area);
                item.SubItems.Add(r.PriorityText);
                item.SubItems.Add(r.StatusText);
                item.SubItems.Add(r.SubmittedText);
                item.Tag = r;
                if (r.Status == RequestStatus.Resolved)
                    item.ForeColor = System.Drawing.Color.Gray;
                else if (r.Priority == 1)
                    item.ForeColor = System.Drawing.Color.FromArgb(170, 30, 30);
                lstRequests.Items.Add(item);
            }
            lstRequests.EndUpdate();
        }

        // ---------------- details ----------------

        private void lstRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRequests.SelectedItems.Count == 0) return;
            ShowDetail((ServiceRequest)lstRequests.SelectedItems[0].Tag);
        }

        private void lstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNext.SelectedItems.Count == 0) return;
            ShowDetail((ServiceRequest)lstNext.SelectedItems[0].Tag);
        }

        private void ShowDetail(ServiceRequest r)
        {
            lblRef.Text = r.Reference + "   " + r.StatusText;
            lblDetail.Text = r.Title + Environment.NewLine
                + r.Department + ", " + r.Category + Environment.NewLine
                + "Area: " + r.Area + "     Priority: " + r.PriorityText + Environment.NewLine
                + "Submitted " + r.SubmittedOn.ToString("dd MMM yyyy HH:mm") + ", open " + r.DaysOpen + " day(s)" + Environment.NewLine
                + "Assigned to: " + r.AssignedTo
                + (r.SourceReference != null ? Environment.NewLine + "Your report number: " + r.SourceReference : "");

            prgStatus.Value = r.ProgressPercent;
            lblStage.Text = r.Status == RequestStatus.OnHold
                ? "On hold, waiting on another job (see Linked jobs)"
                : "Submitted > Assigned > In progress > Resolved   (" + r.ProgressPercent + "%)";

            lstHistory.Items.Clear();
            foreach (StatusUpdate u in r.History.OrderByDescending(h => h.Date))
                lstHistory.Items.Add(u.Date.ToString("dd MMM HH:mm") + "   " + ServiceRequest.StatusName(u.Status) + "   " + u.Note);

            // graph: what this job waits on (BFS) and what is waiting on it
            lstLinks.Items.Clear();
            foreach (var pair in service.WaitingOn(r))
                lstLinks.Items.Add((pair.Value == 1 ? "Waits on " : "Then also on ") + pair.Key.Reference
                    + "  " + pair.Key.Title + "  (" + pair.Key.StatusText + ")");
            foreach (ServiceRequest b in service.Blocking(r))
                lstLinks.Items.Add("Holding up " + b.Reference + "  " + b.Title);
            if (lstLinks.Items.Count == 0)
                lstLinks.Items.Add("Not linked to any other job");
        }

        // ---------------- tabs ----------------

        private void LoadNextToAttend()
        {
            lstNext.Items.Clear();
            int rank = 1;
            foreach (ServiceRequest r in service.NextToAttend(10))
            {
                var item = new ListViewItem(rank.ToString());
                item.SubItems.Add(r.Reference);
                item.SubItems.Add(r.Title);
                item.SubItems.Add(r.PriorityText);
                item.SubItems.Add(r.DaysOpen.ToString());
                item.SubItems.Add(r.StatusText);
                item.Tag = r;
                lstNext.Items.Add(item);
                rank++;
            }

            lstWorkOrder.Items.Clear();
            int step = 1;
            foreach (ServiceRequest r in service.LinkedWorkOrder())
            {
                lstWorkOrder.Items.Add(step + ".  " + r.Reference + "  " + r.Title);
                step++;
            }
        }

        private void LoadDepartments()
        {
            tvDepartments.Nodes.Clear();
            TreeNode<ServiceRequest> root = service.DepartmentTree;
            TreeNode top = tvDepartments.Nodes.Add(root.Name + "  (" + service.Count + ")");
            AddChildren(top, root);
            top.Expand();
        }

        // copies my basic tree into the Windows TreeView, one level at a time
        private void AddChildren(TreeNode viewNode, TreeNode<ServiceRequest> node)
        {
            foreach (TreeNode<ServiceRequest> child in node.Children)
            {
                string text = child.Name;
                if (!child.IsLeaf)
                {
                    List<ServiceRequest> items = child.Items();
                    text += "  (" + items.Count + ", " + items.Count(r => r.IsOpen) + " open)";
                }
                else
                {
                    text += "  [" + child.Item.StatusText + "]";
                }

                TreeNode added = viewNode.Nodes.Add(text);
                added.Tag = child;
                AddChildren(added, child);
            }
        }

        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node.Tag as TreeNode<ServiceRequest>;
            if (node == null) return;

            if (node.IsLeaf)
            {
                ShowDetail(node.Item);
                lblDeptInfo.Text = node.Item.Reference + " is shown under Request details above.";
                return;
            }

            List<ServiceRequest> items = node.Items();
            lblDeptInfo.Text = node.Name + Environment.NewLine
                + items.Count + " request(s), " + items.Count(r => r.IsOpen) + " open, "
                + items.Count(r => r.Priority == 1 && r.IsOpen) + " critical" + Environment.NewLine + Environment.NewLine
                + string.Join(Environment.NewLine, items.Where(r => r.IsOpen).OrderBy(r => r.Priority)
                    .Select(r => r.Reference + "  " + r.PriorityText + "  " + r.Title));
        }

        private void LoadRoute()
        {
            lstRoute.Items.Clear();
            List<GraphEdge> tree = service.RouteTree();
            double total = 0;

            foreach (GraphEdge edge in tree)
            {
                var item = new ListViewItem(edge.From);
                item.SubItems.Add(edge.To);
                item.SubItems.Add(edge.Weight + " km");
                item.SubItems.Add(service.OpenInArea(edge.To).ToString());
                lstRoute.Items.Add(item);
                total += edge.Weight;
            }

            lblRouteInfo.Text = "Roads that link the depot to every area with the least distance (minimum spanning tree)."
                + Environment.NewLine + Environment.NewLine
                + tree.Count + " roads, " + total + " km in total, out of " + service.RoadCount + " roads ("
                + service.TotalRoadKm + " km) in the road graph." + Environment.NewLine + Environment.NewLine
                + "Visiting order from the depot (depth first):" + Environment.NewLine
                + string.Join(" > ", service.RouteOrder());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
