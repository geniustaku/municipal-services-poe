// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.Models
{
    public enum RequestStatus
    {
        Submitted,
        Assigned,
        InProgress,
        OnHold,
        Resolved
    }

    // one line in the history of a request
    public class StatusUpdate
    {
        public DateTime Date { get; set; }
        public RequestStatus Status { get; set; }
        public string Note { get; set; }
    }

    public class ServiceRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }
        public int Priority { get; set; }            // 1 critical, 2 high, 3 medium, 4 low
        public RequestStatus Status { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string AssignedTo { get; set; }
        public string SourceReference { get; set; }  // MSA number when it came from Report Issues
        public List<StatusUpdate> History { get; private set; }
        public List<int> WaitingOn { get; private set; }  // ids of jobs that must finish first

        public ServiceRequest()
        {
            History = new List<StatusUpdate>();
            WaitingOn = new List<int>();
            AssignedTo = "Not assigned yet";
        }

        // the unique identifier residents use to track a request
        public string Reference
        {
            get { return "SR-" + Id; }
        }

        public bool IsOpen
        {
            get { return Status != RequestStatus.Resolved; }
        }

        public int DaysOpen
        {
            get { return (int)(DateTime.Today - SubmittedOn.Date).TotalDays; }
        }

        public string PriorityText
        {
            get
            {
                switch (Priority)
                {
                    case 1: return "Critical";
                    case 2: return "High";
                    case 3: return "Medium";
                    default: return "Low";
                }
            }
        }

        public string StatusText
        {
            get { return StatusName(Status); }
        }

        public static string StatusName(RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.InProgress: return "In progress";
                case RequestStatus.OnHold: return "On hold";
                default: return status.ToString();
            }
        }

        // used by the progress bar on the status page
        public int ProgressPercent
        {
            get
            {
                switch (Status)
                {
                    case RequestStatus.Submitted: return 10;
                    case RequestStatus.Assigned: return 35;
                    case RequestStatus.OnHold: return 50;
                    case RequestStatus.InProgress: return 70;
                    default: return 100;
                }
            }
        }

        public string SubmittedText
        {
            get { return SubmittedOn.ToString("dd MMM yyyy"); }
        }
    }
}
