// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    // Works out how complete a report is and what the user should be told next.
    // This is the engagement strategy: the resident can always see how far they are
    // and what is still missing, instead of filling in a form with no response.
    public class EngagementTracker
    {
        public const int MaxProgress = 100;

        private const int LocationWeight = 25;
        private const int CategoryWeight = 25;
        private const int DescriptionWeight = 35;
        private const int AttachmentWeight = 15;

        // A description only counts once there is enough of it to be useful to the
        // municipal team that has to act on the report.
        private const int UsefulDescriptionLength = 20;

        public int CalculateProgress(string location, string category, string description, int attachmentCount)
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(location))
            {
                progress += LocationWeight;
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                progress += CategoryWeight;
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                if (description.Trim().Length >= UsefulDescriptionLength)
                {
                    progress += DescriptionWeight;
                }
                else
                {
                    progress += DescriptionWeight / 2;
                }
            }

            if (attachmentCount > 0)
            {
                progress += AttachmentWeight;
            }

            return progress;
        }

        public string GetMessage(int progress, int reportsThisSession)
        {
            if (progress == 0)
            {
                return "Start by telling us where the problem is.";
            }

            if (progress < 50)
            {
                return "Good start. Choosing a category helps us send this to the right department.";
            }

            if (progress < MaxProgress)
            {
                return "Almost there. A photo or document makes it much easier for the team to act.";
            }

            if (reportsThisSession == 0)
            {
                return "This report is complete and ready to submit. Thank you for taking the time.";
            }

            return string.Format(
                "This report is complete. You have reported {0} {1} today.",
                reportsThisSession + 1,
                reportsThisSession + 1 == 1 ? "issue" : "issues");
        }

        public bool IsReadyToSubmit(Issue issue)
        {
            return !string.IsNullOrWhiteSpace(issue.Location)
                && !string.IsNullOrWhiteSpace(issue.Category)
                && !string.IsNullOrWhiteSpace(issue.Description);
        }
    }
}
