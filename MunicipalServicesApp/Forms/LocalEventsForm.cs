// Municipal Services Application
// Genius Mhirizhonga  ST10541838

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

            // feedback from Part 2: the category is now typed in, not picked from a list.
            // the known categories are still offered as suggestions while typing.
            var suggestions = new AutoCompleteStringCollection();
            suggestions.AddRange(events.GetCategories().ToArray());
            txtCategory.AutoCompleteCustomSource = suggestions;

            AcceptButton = btnSearch;
            ShowEvents(events.GetAllByDate());
            lblResults.Text = "Upcoming events";
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

            List<LocalEvent> results = events.Search(txtCategory.Text, from, to);
            ShowEvents(results);

            lblResults.Text = results.Count + " event(s) found";
            if (events.LastSearchNote.Length > 0)
                lblResults.Text += "   " + events.LastSearchNote;

            RefreshRecommendations();
            RefreshRecent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategory.Clear();
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            ShowEvents(events.GetAllByDate());
            lblResults.Text = "Upcoming events";
        }

        // double click a recent search to run it again
        private void lstRecent_DoubleClick(object sender, EventArgs e)
        {
            if (lstRecent.SelectedItem == null) return;
            txtCategory.Text = lstRecent.SelectedItem.ToString();
            btnSearch.PerformClick();
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
