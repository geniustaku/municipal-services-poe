// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.Services;

namespace MunicipalServicesApp.Forms
{
    public partial class ReportIssuesForm : Form
    {
        private readonly IssueRepository repository;
        private readonly EngagementTracker engagement = new EngagementTracker();
        private readonly List<string> attachedFiles = new List<string>();

        public ReportIssuesForm(IssueRepository repository)
        {
            InitializeComponent();
            this.repository = repository;

            cboCategory.Items.AddRange(new object[]
            {
                "Sanitation",
                "Roads and Potholes",
                "Water and Utilities",
                "Electricity",
                "Refuse Removal",
                "Public Safety",
                "Parks and Public Spaces",
                "Other"
            });

            AcceptButton = btnSubmit;
            UpdateEngagement();
        }

        // Every input on the form reports back here so the progress bar and the message
        // stay in step with what the resident has actually filled in.
        private void Input_Changed(object sender, EventArgs e)
        {
            UpdateEngagement();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            int added = 0;
            foreach (string path in openFileDialog.FileNames)
            {
                if (!attachedFiles.Contains(path))
                {
                    attachedFiles.Add(path);
                    added++;
                }
            }

            if (added == 0)
            {
                MessageBox.Show(this,
                    "Those files are already attached to this report.",
                    "Already attached",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            ShowAttachments();
            UpdateEngagement();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Issue issue = BuildIssue();

            if (!engagement.IsReadyToSubmit(issue))
            {
                MessageBox.Show(this,
                    "Please fill in the location, choose a category and describe the issue before submitting.",
                    "Some details are missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                FocusFirstEmptyField();
                return;
            }

            string reference = repository.Add(issue);

            MessageBox.Show(this,
                "Thank you. Your report has been logged." + Environment.NewLine + Environment.NewLine
                    + "Reference number: " + reference + Environment.NewLine
                    + "Category: " + issue.Category + Environment.NewLine
                    + "Location: " + issue.Location + Environment.NewLine + Environment.NewLine
                    + "Please keep the reference number so you can follow the report up.",
                "Report submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (HasUnsavedInput())
            {
                DialogResult answer = MessageBox.Show(this,
                    "This report has not been submitted yet. Leave the page and lose it?",
                    "Report not submitted",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer == DialogResult.No)
                {
                    return;
                }
            }

            Close();
        }

        private Issue BuildIssue()
        {
            Issue issue = new Issue();
            issue.Location = txtLocation.Text.Trim();
            issue.Category = cboCategory.SelectedItem == null ? string.Empty : cboCategory.SelectedItem.ToString();
            issue.Description = rtbDescription.Text.Trim();
            issue.Attachments.AddRange(attachedFiles);
            return issue;
        }

        private void UpdateEngagement()
        {
            string category = cboCategory.SelectedItem == null ? string.Empty : cboCategory.SelectedItem.ToString();

            int progress = engagement.CalculateProgress(
                txtLocation.Text,
                category,
                rtbDescription.Text,
                attachedFiles.Count);

            if (progress > EngagementTracker.MaxProgress)
            {
                progress = EngagementTracker.MaxProgress;
            }

            prgCompletion.Value = progress;
            lblEngagement.Text = engagement.GetMessage(progress, repository.Count);
        }

        private void ShowAttachments()
        {
            if (attachedFiles.Count == 0)
            {
                lblAttachments.Text = "No files attached. Images and documents are both accepted.";
                return;
            }

            if (attachedFiles.Count == 1)
            {
                lblAttachments.Text = "Attached: " + Path.GetFileName(attachedFiles[0]);
                return;
            }

            lblAttachments.Text = attachedFiles.Count + " files attached, including "
                + Path.GetFileName(attachedFiles[0]);
        }

        private void FocusFirstEmptyField()
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                txtLocation.Focus();
            }
            else if (cboCategory.SelectedItem == null)
            {
                cboCategory.Focus();
            }
            else
            {
                rtbDescription.Focus();
            }
        }

        private bool HasUnsavedInput()
        {
            return !string.IsNullOrWhiteSpace(txtLocation.Text)
                || cboCategory.SelectedItem != null
                || !string.IsNullOrWhiteSpace(rtbDescription.Text)
                || attachedFiles.Count > 0;
        }

        private void ClearForm()
        {
            txtLocation.Clear();
            cboCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            attachedFiles.Clear();

            ShowAttachments();
            UpdateEngagement();
            txtLocation.Focus();
        }
    }
}
