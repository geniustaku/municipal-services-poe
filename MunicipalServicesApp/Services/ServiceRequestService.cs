// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MunicipalServicesApp.DataStructures;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Services
{
    // Everything the Service Request Status page needs. Each request is stored once in
    // a list, then indexed by the structures that make each feature fast:
    //   binary search tree  - request number, for tracking one request
    //   AVL tree            - date submitted, for date order and date ranges
    //   red-black tree      - area, for filtering by where the problem is
    //   basic tree          - department > category > request, for the browse view
    //   min-heap            - priority then age, for what to attend next
    //   graph (directed)    - which jobs wait on other jobs, searched with BFS and DFS
    //   graph (undirected)  - roads between areas, minimum spanning tree for the crew route
    public class ServiceRequestService
    {
        public const string Depot = "Municipal Depot";

        private readonly List<ServiceRequest> all = new List<ServiceRequest>();
        private readonly BinarySearchTree<int, ServiceRequest> byId = new BinarySearchTree<int, ServiceRequest>();
        private readonly AvlTree<DateTime, ServiceRequest> byDate = new AvlTree<DateTime, ServiceRequest>();
        private readonly RedBlackTree<string, ServiceRequest> byArea =
            new RedBlackTree<string, ServiceRequest>(StringComparer.OrdinalIgnoreCase);
        private readonly BasicTree<ServiceRequest> departments = new BasicTree<ServiceRequest>("All departments");
        private readonly Graph dependencies = new Graph(true);
        private readonly Graph roads = new Graph(false);

        // Part 1 reference numbers (MSA-...) mapped to the request number they became
        private readonly Dictionary<string, int> fromIssues =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private int nextId = 1021;

        public ServiceRequestService()
        {
            LoadSampleRequests();
            LoadRoads();
        }

        public int Count
        {
            get { return all.Count; }
        }

        public TreeNode<ServiceRequest> DepartmentTree
        {
            get { return departments.Root; }
        }

        private void Add(ServiceRequest r)
        {
            all.Add(r);
            byId.Insert(r.Id, r);
            byDate.Insert(r.SubmittedOn, r);
            byArea.Insert(r.Area, r);
            departments.Add(r, r.Reference + "  " + r.Title, r.Department, r.Category);
            dependencies.AddVertex(r.Reference);
        }

        // ---------------- loading ----------------

        private void Seed(int id, string title, string department, string category, string area,
            int priority, RequestStatus status, int daysAgo, string team, params int[] waitsOn)
        {
            var r = new ServiceRequest
            {
                Id = id,
                Title = title,
                Department = department,
                Category = category,
                Area = area,
                Priority = priority,
                Status = status,
                SubmittedOn = DateTime.Today.AddDays(-daysAgo).AddHours(7 + id % 9).AddMinutes(id * 7 % 60)
            };
            r.WaitingOn.AddRange(waitsOn);

            // build a believable history from the current status
            r.History.Add(new StatusUpdate { Date = r.SubmittedOn, Status = RequestStatus.Submitted, Note = "Request received" });
            if (status != RequestStatus.Submitted)
            {
                r.AssignedTo = team;
                r.History.Add(new StatusUpdate { Date = r.SubmittedOn.AddHours(4), Status = RequestStatus.Assigned, Note = "Assigned to " + team });
            }
            if (status == RequestStatus.InProgress || status == RequestStatus.Resolved)
                r.History.Add(new StatusUpdate { Date = r.SubmittedOn.AddDays(1), Status = RequestStatus.InProgress, Note = "Team on site" });
            if (status == RequestStatus.OnHold)
            {
                string waitNote = waitsOn.Length == 0 ? "Waiting for parts"
                    : "Waiting for " + string.Join(" and ", waitsOn.Select(w => "SR-" + w)) + " to be finished first";
                r.History.Add(new StatusUpdate { Date = r.SubmittedOn.AddDays(1), Status = RequestStatus.OnHold, Note = waitNote });
            }
            if (status == RequestStatus.Resolved)
                r.History.Add(new StatusUpdate { Date = r.SubmittedOn.AddDays(Math.Min(daysAgo, 3)), Status = RequestStatus.Resolved, Note = "Work completed and checked" });

            Add(r);
        }

        private void LoadSampleRequests()
        {
            const string water = "Water and Sanitation", roadsDept = "Roads and Transport",
                power = "Electricity", waste = "Waste Management", parks = "Parks and Recreation";

            // loaded per department, so the request numbers do not arrive in sorted order
            Seed(1003, "Burst water main on Church Street", water, "Burst pipe", "Sunnyside", 1, RequestStatus.InProgress, 6, "Water Team B");
            Seed(1011, "No water supply since this morning", water, "Water supply", "Mamelodi East", 1, RequestStatus.Assigned, 1, "Water Team A");
            Seed(1007, "Blocked sewer drain outside the clinic", water, "Sewer", "Atteridgeville", 2, RequestStatus.InProgress, 9, "Water Team C");
            Seed(1015, "Leaking water meter at house 21", water, "Water meter", "Brooklyn", 4, RequestStatus.Submitted, 1, "");
            Seed(1019, "Low water pressure in townhouse complex", water, "Water supply", "Centurion", 3, RequestStatus.OnHold, 14, "Water Team B", 1003);

            Seed(1001, "Large pothole on Duncan Street", roadsDept, "Potholes", "Hatfield", 2, RequestStatus.Resolved, 21, "Roads Crew 1");
            Seed(1008, "Resurface Church Street after pipe repair", roadsDept, "Road surface", "Sunnyside", 3, RequestStatus.OnHold, 5, "Roads Crew 2", 1003, 1010);
            Seed(1012, "Traffic light out at Atterbury Road", roadsDept, "Traffic lights", "Lynnwood", 1, RequestStatus.Assigned, 1, "Roads Crew 3", 1005);
            Seed(1016, "Faded pedestrian crossing near the school", roadsDept, "Road markings", "Arcadia", 3, RequestStatus.Submitted, 3, "");
            Seed(1020, "Damaged stormwater grid", roadsDept, "Stormwater", "Soshanguve", 2, RequestStatus.InProgress, 8, "Roads Crew 1");

            Seed(1009, "Stolen cable at Lynnwood substation", power, "Cable theft", "Lynnwood", 1, RequestStatus.InProgress, 4, "Electrical Team A");
            Seed(1005, "Substation fault on the Lynnwood feeder", power, "Outage", "Lynnwood", 1, RequestStatus.OnHold, 2, "Electrical Team A", 1009);
            Seed(1002, "Street lights out on Park Street", power, "Street lights", "Arcadia", 3, RequestStatus.Resolved, 18, "Electrical Team B");
            Seed(1014, "Prepaid meter not accepting tokens", power, "Meters", "Soshanguve", 3, RequestStatus.Submitted, 2, "");
            Seed(1018, "Street light flickering on Lenchen Avenue", power, "Street lights", "Centurion", 4, RequestStatus.Submitted, 6, "");

            Seed(1004, "Refuse not collected for two weeks", waste, "Refuse collection", "Atteridgeville", 2, RequestStatus.Assigned, 10, "Waste Unit 1");
            Seed(1010, "Illegal dumping next to the park", waste, "Illegal dumping", "Sunnyside", 2, RequestStatus.InProgress, 7, "Waste Unit 2");
            Seed(1017, "Overflowing public bins at the taxi rank", waste, "Bins", "Hatfield", 3, RequestStatus.Resolved, 12, "Waste Unit 1");

            Seed(1006, "Fallen tree blocking the walkway", parks, "Trees", "Brooklyn", 2, RequestStatus.Resolved, 15, "Parks Team");
            Seed(1013, "Broken swings at the play park", parks, "Play equipment", "Arcadia", 4, RequestStatus.Submitted, 11, "");

            // the "waits on" links between jobs
            foreach (ServiceRequest r in all)
                foreach (int id in r.WaitingOn)
                    dependencies.AddEdge(r.Reference, "SR-" + id);
        }

        // roads between the depot and the areas, distances in km
        private void LoadRoads()
        {
            roads.AddEdge(Depot, "Arcadia", 3);
            roads.AddEdge(Depot, "Sunnyside", 4);
            roads.AddEdge(Depot, "Atteridgeville", 14);
            roads.AddEdge(Depot, "Centurion", 16);
            roads.AddEdge(Depot, "Soshanguve", 28);
            roads.AddEdge("Arcadia", "Sunnyside", 2);
            roads.AddEdge("Arcadia", "Hatfield", 3);
            roads.AddEdge("Arcadia", "Mamelodi East", 19);
            roads.AddEdge("Hatfield", "Brooklyn", 2);
            roads.AddEdge("Hatfield", "Lynnwood", 5);
            roads.AddEdge("Sunnyside", "Brooklyn", 4);
            roads.AddEdge("Brooklyn", "Lynnwood", 4);
            roads.AddEdge("Brooklyn", "Centurion", 14);
            roads.AddEdge("Lynnwood", "Mamelodi East", 17);
            roads.AddEdge("Atteridgeville", "Centurion", 18);
            roads.AddEdge("Soshanguve", "Atteridgeville", 26);
            roads.AddEdge("Soshanguve", "Mamelodi East", 30);
        }

        // Issues reported on the Report Issues page (Part 1) become service requests,
        // so a resident can follow up the report they just made.
        public int ImportIssues(IssueRepository repository)
        {
            int added = 0;
            foreach (Issue issue in repository.GetAll())
            {
                if (fromIssues.ContainsKey(issue.ReferenceNumber)) continue;

                string text = (issue.Description ?? "").Trim();
                var r = new ServiceRequest
                {
                    Id = nextId++,
                    Title = text.Length > 45 ? text.Substring(0, 45).TrimEnd() + "..." : text,
                    Category = issue.Category,
                    Department = DepartmentFor(issue.Category),
                    Area = string.IsNullOrWhiteSpace(issue.Location) ? "Unknown area" : issue.Location.Trim(),
                    Priority = 3,
                    Status = RequestStatus.Submitted,
                    SubmittedOn = issue.ReportedOn,
                    SourceReference = issue.ReferenceNumber
                };
                r.History.Add(new StatusUpdate { Date = issue.ReportedOn, Status = RequestStatus.Submitted, Note = "Reported on the Report Issues page as " + issue.ReferenceNumber });

                Add(r);
                fromIssues[issue.ReferenceNumber] = r.Id;
                added++;
            }
            return added;
        }

        private static string DepartmentFor(string category)
        {
            switch (category)
            {
                case "Sanitation":
                case "Water and Utilities": return "Water and Sanitation";
                case "Roads and Potholes": return "Roads and Transport";
                case "Electricity": return "Electricity";
                case "Refuse Removal": return "Waste Management";
                case "Parks and Public Spaces": return "Parks and Recreation";
                case "Public Safety": return "Community Safety";
                default: return "General Enquiries";
            }
        }

        // ---------------- tracking and searching ----------------

        // Accepts SR-1007, sr1007, 1007 or the MSA number from Report Issues.
        public ServiceRequest Track(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            string value = text.Trim().ToUpperInvariant();

            int fromIssue;
            if (fromIssues.TryGetValue(value, out fromIssue))
                return byId.Find(fromIssue).FirstOrDefault();

            if (value.StartsWith("SR")) value = value.Substring(2).TrimStart('-', ' ');

            int id;
            if (!int.TryParse(value, out id)) return null;
            return byId.Find(id).FirstOrDefault();   // binary search tree lookup
        }

        // newest first, straight from the AVL tree in reverse
        public List<ServiceRequest> GetAll()
        {
            List<ServiceRequest> list = byDate.InOrder();
            list.Reverse();
            return list;
        }

        public List<ServiceRequest> Search(string status, string areaText, string categoryText, DateTime? from, DateTime? to)
        {
            // 1. date range from the AVL tree (or everything in date order)
            List<ServiceRequest> results;
            if (from.HasValue || to.HasValue)
            {
                DateTime start = from.HasValue ? from.Value.Date : DateTime.MinValue;
                DateTime end = to.HasValue ? to.Value.Date.AddDays(1).AddTicks(-1) : DateTime.MaxValue;
                results = byDate.Range(start, end);
            }
            else
            {
                results = byDate.InOrder();
            }

            // 2. area: exact name uses the red-black tree, otherwise any area containing the text
            if (!string.IsNullOrWhiteSpace(areaText))
            {
                string term = areaText.Trim();
                List<ServiceRequest> inArea = byArea.Find(term);
                if (inArea.Count == 0)
                    inArea = byArea.InOrder().Where(r => r.Area.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                var ids = new HashSet<int>(inArea.Select(r => r.Id));
                results = results.Where(r => ids.Contains(r.Id)).ToList();
            }

            // 3. category is free text, several words can be separated by commas
            if (!string.IsNullOrWhiteSpace(categoryText))
            {
                string[] terms = categoryText.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => t.Trim()).Where(t => t.Length > 0).ToArray();
                results = results.Where(r => terms.Any(t =>
                    r.Category.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r.Department.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r.Title.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
            }

            // 4. status
            if (!string.IsNullOrEmpty(status) && status != "All statuses")
                results = results.Where(r => r.StatusText == status).ToList();

            results.Reverse();
            return results;
        }

        public List<string> GetAreas()
        {
            return byArea.KeysInOrder();
        }

        public List<string> GetCategoryWords()
        {
            return all.Select(r => r.Category).Concat(all.Select(r => r.Department))
                .Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList();
        }

        // ---------------- heap ----------------

        // open requests in the order they should be attended: most urgent priority first,
        // and for the same priority the one that has waited longest
        public List<ServiceRequest> NextToAttend(int max)
        {
            var heap = new MinHeap<ServiceRequest>((a, b) =>
            {
                int byPriority = a.Priority.CompareTo(b.Priority);
                return byPriority != 0 ? byPriority : a.SubmittedOn.CompareTo(b.SubmittedOn);
            });

            foreach (ServiceRequest r in all)
                if (r.IsOpen) heap.Push(r);

            var list = new List<ServiceRequest>();
            while (heap.Count > 0 && list.Count < max)
                list.Add(heap.Pop());
            return list;
        }

        public int OpenCount
        {
            get { return all.Count(r => r.IsOpen); }
        }

        // ---------------- dependency graph ----------------

        // every job this request waits on, with how many steps away it is (BFS)
        public List<KeyValuePair<ServiceRequest, int>> WaitingOn(ServiceRequest request)
        {
            var list = new List<KeyValuePair<ServiceRequest, int>>();
            foreach (var pair in dependencies.BreadthFirst(request.Reference))
            {
                if (pair.Value == 0) continue;   // the request itself
                ServiceRequest r = Track(pair.Key);
                if (r != null) list.Add(new KeyValuePair<ServiceRequest, int>(r, pair.Value));
            }
            return list;
        }

        // jobs that cannot finish until this one is done
        public List<ServiceRequest> Blocking(ServiceRequest request)
        {
            return all.Where(r => r.WaitingOn.Contains(request.Id)).OrderBy(r => r.Id).ToList();
        }

        // safe order to do the linked jobs in (topological sort with DFS)
        public List<ServiceRequest> LinkedWorkOrder()
        {
            var linked = new HashSet<int>(all.Where(r => r.WaitingOn.Count > 0).SelectMany(r => r.WaitingOn.Concat(new[] { r.Id })));
            return dependencies.TopologicalOrder()
                .Select(Track)
                .Where(r => r != null && r.IsOpen && linked.Contains(r.Id))
                .ToList();
        }

        // ---------------- road graph and MST ----------------

        public List<GraphEdge> RouteTree()
        {
            return roads.MinimumSpanningTree();
        }

        public double TotalRoadKm
        {
            get
            {
                double total = 0;
                foreach (string v in roads.Vertices)
                    foreach (GraphEdge e in roads.EdgesFrom(v))
                        total += e.Weight;
                return total / 2;
            }
        }

        public int RoadCount
        {
            get { return roads.EdgeCount; }
        }

        // visiting order from the depot along the MST roads (DFS)
        public List<string> RouteOrder()
        {
            var tree = new Graph(false);
            foreach (GraphEdge e in RouteTree())
                tree.AddEdge(e.From, e.To, e.Weight);
            return tree.DepthFirst(Depot);
        }

        public int OpenInArea(string area)
        {
            return byArea.Find(area).Count(r => r.IsOpen);
        }

        // ---------------- tree statistics ----------------

        public string TreeReport()
        {
            var sb = new StringBuilder();
            int n = byId.NodeCount;
            int best = (int)Math.Ceiling(Math.Log(n + 1, 2));

            // same request numbers inserted in sorted order, the worst case for a plain BST
            var sortedBst = new BinarySearchTree<int, ServiceRequest>();
            foreach (ServiceRequest r in byId.InOrder()) sortedBst.Insert(r.Id, r);

            sb.AppendLine("Binary search tree   key: request number");
            sb.AppendLine("  nodes " + n + ", height " + byId.Height + "   (best possible height for " + n + " keys is " + best + ")");
            sb.AppendLine("  same numbers added in sorted order: height " + sortedBst.Height + ", it becomes a chain");
            sb.AppendLine("  level order: " + string.Join("  |  ", byId.LevelOrderKeys().Select(l => string.Join(" ", l))));
            sb.AppendLine();
            // in real use requests come in oldest first, so compare both trees with that order
            var plainDates = new BinarySearchTree<DateTime, ServiceRequest>();
            var avlDates = new AvlTree<DateTime, ServiceRequest>();
            foreach (ServiceRequest r in byDate.InOrder())
            {
                plainDates.Insert(r.SubmittedOn, r);
                avlDates.Insert(r.SubmittedOn, r);
            }

            sb.AppendLine("AVL tree             key: date and time submitted");
            sb.AppendLine("  nodes " + byDate.NodeCount + ", height " + byDate.Height + ", rotations while loading " + byDate.Rotations);
            sb.AppendLine("  added oldest first, the way requests really come in: plain BST height " + plainDates.Height
                + ", AVL height " + avlDates.Height + " after " + avlDates.Rotations + " rotations");
            sb.AppendLine();
            sb.AppendLine("Red-black tree       key: area");
            sb.AppendLine("  nodes " + byArea.NodeCount + " areas holding " + byArea.Count + " requests, height " + byArea.Height
                + ", black height " + byArea.BlackHeight + ", red nodes " + byArea.RedNodes + ", rotations " + byArea.Rotations);
            sb.AppendLine("  areas in order: " + string.Join(", ", byArea.KeysInOrder()));
            sb.AppendLine();
            sb.AppendLine("Basic tree           department > category > request, depth " + departments.Depth
                + ", " + departments.Root.Children.Count + " departments");
            return sb.ToString();
        }
    }
}
