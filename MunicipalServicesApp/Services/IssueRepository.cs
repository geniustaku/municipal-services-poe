// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    // Holds the issues reported during this run. A List is used because reports are
    // added one at a time and read back in the order they were captured.
    public class IssueRepository
    {
        private readonly List<Issue> issues = new List<Issue>();
        private int counter = 0;

        public int Count
        {
            get { return issues.Count; }
        }

        public string Add(Issue issue)
        {
            counter++;
            issue.ReferenceNumber = BuildReference(counter);
            issues.Add(issue);
            return issue.ReferenceNumber;
        }

        public IEnumerable<Issue> GetAll()
        {
            return issues;
        }

        // Reference numbers look like MSA-20260902-0003 so a resident can quote one
        // when following the report up.
        private static string BuildReference(int number)
        {
            return string.Format("MSA-{0:yyyyMMdd}-{1:D4}", DateTime.Now, number);
        }
    }
}
