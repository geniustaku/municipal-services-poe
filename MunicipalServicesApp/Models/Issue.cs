// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.Models
{
    public class Issue
    {
        public string ReferenceNumber { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> Attachments { get; set; }
        public DateTime ReportedOn { get; set; }

        public Issue()
        {
            Attachments = new List<string>();
            ReportedOn = DateTime.Now;
        }

        public int AttachmentCount
        {
            get { return Attachments.Count; }
        }
    }
}
