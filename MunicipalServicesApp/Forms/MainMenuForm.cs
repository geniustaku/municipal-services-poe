// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Windows.Forms;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class MainMenuForm : Form
    {
        // One repository is shared with the reporting form so that reports stay in
        // memory while the application is open.
        private readonly IssueRepository repository = new IssueRepository();

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            using (ReportIssuesForm form = new ReportIssuesForm(repository))
            {
                form.ShowDialog(this);
            }

            UpdateStatus();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            using (LocalEventsForm form = new LocalEventsForm())
            {
                form.ShowDialog(this);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateStatus()
        {
            if (repository.Count == 0)
            {
                lblStatus.Text = "No issues reported yet.";
            }
            else if (repository.Count == 1)
            {
                lblStatus.Text = "1 issue reported in this session.";
            }
            else
            {
                lblStatus.Text = repository.Count + " issues reported in this session.";
            }
        }
    }
}
