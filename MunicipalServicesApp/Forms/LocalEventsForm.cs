using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class LocalEventsForm : Form
    {
        private readonly EventService events = new EventService();

        public LocalEventsForm()
        {
            InitializeComponent();

            cboCategory.Items.Add("All categories");
            foreach (string c in events.GetCategories())
                cboCategory.Items.Add(c);
            cboCategory.SelectedIndex = 0;

            ShowEvents(events.GetAllByDate());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string category = cboCategory.SelectedItem.ToString();
            DateTime? from = dtpFrom.Checked ? dtpFrom.Value : (DateTime?)null;
            DateTime? to = dtpTo.Checked ? dtpTo.Value : (DateTime?)null;

            if (from.HasValue && to.HasValue && from.Value.Date > to.Value.Date)
            {
                MessageBox.Show(this, "The From date is after the To date.", "Check the dates",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<LocalEvent> results = events.Search(category, from, to);
            ShowEvents(results);
            lblResults.Text = results.Count + " event(s) found";

            RefreshRecommendations();
            RefreshRecent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboCategory.SelectedIndex = 0;
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            ShowEvents(events.GetAllByDate());
            lblResults.Text = "Upcoming events";
        }

        private void ShowEvents(List<LocalEvent> list)
        {
            lstEvents.Items.Clear();
            foreach (LocalEvent ev in list)
            {
                var item = new ListViewItem(ev.DateText);
                item.SubItems.Add(ev.Title);
                item.SubItems.Add(ev.Category);
                item.SubItems.Add(ev.Venue);
                item.Tag = ev;
                lstEvents.Items.Add(item);
            }
        }

        private void RefreshRecommendations()
        {
            lstRecommend.Items.Clear();
            List<LocalEvent> recs = events.GetRecommendations(5);

            if (recs.Count == 0)
            {
                lstRecommend.Items.Add("Search a category to get");
                lstRecommend.Items.Add("recommendations.");
                return;
            }

            foreach (LocalEvent ev in recs)
                lstRecommend.Items.Add(ev.Title + "  -  " + ev.DateText);
        }

        private void RefreshRecent()
        {
            lstRecent.Items.Clear();
            foreach (string term in events.GetRecentSearches(5))
                lstRecent.Items.Add(term);
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItems.Count == 0) return;

            LocalEvent ev = (LocalEvent)lstEvents.SelectedItems[0].Tag;
            lblDetail.Text = ev.Title + "   (" + ev.Category + ")" + Environment.NewLine
                + ev.DateText + "  at  " + ev.Venue + Environment.NewLine
                + ev.Description;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
