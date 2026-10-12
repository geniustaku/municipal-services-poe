using System;

namespace MunicipalServicesApp.Models
{
    public class LocalEvent
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }

        public string DateText
        {
            get { return Date.ToString("ddd, dd MMM yyyy"); }
        }
    }
}
