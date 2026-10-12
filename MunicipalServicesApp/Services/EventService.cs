using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    // Holds the events and all the lookups the Local Events page needs.
    // Uses a sorted dictionary for date order, a dictionary for category lookup,
    // sets for the unique categories and dates, a queue of upcoming events, and a
    // stack of recent searches. Recommendations come from the search history.
    public class EventService
    {
        private readonly SortedDictionary<DateTime, List<LocalEvent>> byDate =
            new SortedDictionary<DateTime, List<LocalEvent>>();

        private readonly Dictionary<string, List<LocalEvent>> byCategory =
            new Dictionary<string, List<LocalEvent>>(StringComparer.OrdinalIgnoreCase);

        private readonly HashSet<string> categories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private readonly HashSet<DateTime> dates = new HashSet<DateTime>();

        private readonly Queue<LocalEvent> upcoming = new Queue<LocalEvent>();

        private readonly Stack<string> recentSearches = new Stack<string>();

        // how many times each category has been searched, used for recommendations
        private readonly Dictionary<string, int> searchCounts =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        public EventService()
        {
            LoadSampleEvents();
        }

        private void Add(LocalEvent e)
        {
            if (!byDate.ContainsKey(e.Date))
                byDate[e.Date] = new List<LocalEvent>();
            byDate[e.Date].Add(e);

            if (!byCategory.ContainsKey(e.Category))
                byCategory[e.Category] = new List<LocalEvent>();
            byCategory[e.Category].Add(e);

            categories.Add(e.Category);
            dates.Add(e.Date);
        }

        private void LoadSampleEvents()
        {
            DateTime today = DateTime.Today;

            Add(new LocalEvent { Title = "Ward 5 Community Meeting", Category = "Community", Date = today.AddDays(2), Venue = "Civic Hall", Description = "Monthly meeting to discuss ward matters and service delivery." });
            Add(new LocalEvent { Title = "Water Outage Notice", Category = "Announcement", Date = today.AddDays(1), Venue = "Zone 3", Description = "Planned maintenance, water off from 08:00 to 14:00." });
            Add(new LocalEvent { Title = "Youth Soccer Tournament", Category = "Sports", Date = today.AddDays(6), Venue = "Municipal Stadium", Description = "Under 17 district knockout rounds." });
            Add(new LocalEvent { Title = "Small Business Workshop", Category = "Workshop", Date = today.AddDays(4), Venue = "Library Hall", Description = "Free session on registering and running a small business." });
            Add(new LocalEvent { Title = "Refuse Collection Change", Category = "Announcement", Date = today.AddDays(3), Venue = "Whole municipality", Description = "Collection day moves from Monday to Wednesday." });
            Add(new LocalEvent { Title = "Heritage Day Festival", Category = "Community", Date = today.AddDays(9), Venue = "Town Square", Description = "Music, food stalls and cultural performances." });
            Add(new LocalEvent { Title = "Road Safety Awareness", Category = "Workshop", Date = today.AddDays(7), Venue = "Community Centre", Description = "Talk for learner and new drivers." });
            Add(new LocalEvent { Title = "Senior Citizens Fun Walk", Category = "Sports", Date = today.AddDays(5), Venue = "Riverside Park", Description = "5km walk with refreshments provided." });
            Add(new LocalEvent { Title = "Load Shedding Schedule", Category = "Announcement", Date = today.AddDays(1), Venue = "Whole municipality", Description = "Updated schedule for the coming week." });
            Add(new LocalEvent { Title = "Clinic Vaccination Drive", Category = "Community", Date = today.AddDays(8), Venue = "Local Clinic", Description = "Free flu vaccinations for residents." });

            // build the upcoming queue in date order using the sorted dictionary
            foreach (var pair in byDate)
                foreach (var e in pair.Value)
                    upcoming.Enqueue(e);
        }

        // all events, already in date order because of the sorted dictionary
        public List<LocalEvent> GetAllByDate()
        {
            var result = new List<LocalEvent>();
            foreach (var pair in byDate)
                result.AddRange(pair.Value);
            return result;
        }

        public List<string> GetCategories()
        {
            var list = categories.ToList();
            list.Sort();
            return list;
        }

        public List<DateTime> GetDates()
        {
            var list = dates.ToList();
            list.Sort();
            return list;
        }

        // the search used by the page, records what was searched for recommendations
        public List<LocalEvent> Search(string category, DateTime? from, DateTime? to)
        {
            if (!string.IsNullOrWhiteSpace(category) && category != "All categories")
            {
                recentSearches.Push(category);
                if (searchCounts.ContainsKey(category))
                    searchCounts[category]++;
                else
                    searchCounts[category] = 1;
            }

            IEnumerable<LocalEvent> results;

            if (!string.IsNullOrWhiteSpace(category) && category != "All categories"
                && byCategory.ContainsKey(category))
            {
                results = byCategory[category];
            }
            else
            {
                results = GetAllByDate();
            }

            if (from.HasValue)
                results = results.Where(e => e.Date >= from.Value.Date);
            if (to.HasValue)
                results = results.Where(e => e.Date <= to.Value.Date);

            return results.OrderBy(e => e.Date).ToList();
        }

        // last few searches, newest first (straight from the stack)
        public List<string> GetRecentSearches(int max)
        {
            return recentSearches.Take(max).ToList();
        }

        // recommend soonest events from the categories the user searches most.
        // a priority queue orders them by date so the nearest events come first.
        public List<LocalEvent> GetRecommendations(int max)
        {
            if (searchCounts.Count == 0)
                return new List<LocalEvent>();

            int topCount = searchCounts.Values.Max();
            var favourite = searchCounts
                .Where(p => p.Value == topCount)
                .Select(p => p.Key)
                .ToList();

            var pq = new PriorityQueue<LocalEvent>();
            DateTime today = DateTime.Today;

            foreach (var cat in favourite)
            {
                if (!byCategory.ContainsKey(cat)) continue;
                foreach (var e in byCategory[cat])
                {
                    if (e.Date >= today)
                        pq.Enqueue(e.Date.Ticks, e);
                }
            }

            var picks = new List<LocalEvent>();
            while (pq.Count > 0 && picks.Count < max)
                picks.Add(pq.Dequeue());

            return picks;
        }
    }
}
