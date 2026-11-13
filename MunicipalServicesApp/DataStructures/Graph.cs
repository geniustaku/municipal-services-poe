// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp.DataStructures
{
    public class GraphEdge
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Weight { get; set; }
    }

    // Graph stored as an adjacency list (each vertex keeps a list of its edges).
    // I use it twice:
    //   directed   - request A "waits on" request B (dependencies between jobs)
    //   undirected - roads between the depot and the areas, weighted in km
    public class Graph
    {
        private readonly Dictionary<string, List<GraphEdge>> adjacency =
            new Dictionary<string, List<GraphEdge>>(StringComparer.OrdinalIgnoreCase);

        private readonly bool directed;

        public Graph(bool directed)
        {
            this.directed = directed;
        }

        public int VertexCount
        {
            get { return adjacency.Count; }
        }

        public int EdgeCount
        {
            get
            {
                int total = adjacency.Values.Sum(list => list.Count);
                return directed ? total : total / 2;
            }
        }

        public IEnumerable<string> Vertices
        {
            get { return adjacency.Keys; }
        }

        public void AddVertex(string vertex)
        {
            if (!adjacency.ContainsKey(vertex))
                adjacency[vertex] = new List<GraphEdge>();
        }

        public void AddEdge(string from, string to, double weight = 1)
        {
            AddVertex(from);
            AddVertex(to);
            adjacency[from].Add(new GraphEdge { From = from, To = to, Weight = weight });
            if (!directed)
                adjacency[to].Add(new GraphEdge { From = to, To = from, Weight = weight });
        }

        public List<GraphEdge> EdgesFrom(string vertex)
        {
            List<GraphEdge> list;
            return adjacency.TryGetValue(vertex, out list) ? list : new List<GraphEdge>();
        }

        // Breadth first search with a queue. Returns every vertex that can be reached
        // and how many steps away it is, nearest first. For a request this gives the
        // jobs it waits on directly (1 step) and indirectly (2 or more steps).
        public List<KeyValuePair<string, int>> BreadthFirst(string start)
        {
            var result = new List<KeyValuePair<string, int>>();
            if (!adjacency.ContainsKey(start)) return result;

            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { start };
            var queue = new Queue<KeyValuePair<string, int>>();
            queue.Enqueue(new KeyValuePair<string, int>(start, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current);

                foreach (GraphEdge edge in adjacency[current.Key])
                {
                    if (visited.Add(edge.To))
                        queue.Enqueue(new KeyValuePair<string, int>(edge.To, current.Value + 1));
                }
            }
            return result;
        }

        // Depth first search with a stack. Used to give a visiting order for the
        // crew route, going as deep as possible down one road before coming back.
        public List<string> DepthFirst(string start)
        {
            var order = new List<string>();
            if (!adjacency.ContainsKey(start)) return order;

            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var stack = new Stack<string>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                string vertex = stack.Pop();
                if (!visited.Add(vertex)) continue;
                order.Add(vertex);

                // push the furthest road first so the nearest one is visited first
                foreach (GraphEdge edge in adjacency[vertex].OrderByDescending(e => e.Weight))
                    if (!visited.Contains(edge.To))
                        stack.Push(edge.To);
            }
            return order;
        }

        // Work order for a directed "waits on" graph, also done with depth first search.
        // A job is only added after everything it waits on, so the list is a safe order
        // to do the work in (a topological sort).
        public List<string> TopologicalOrder()
        {
            var order = new List<string>();
            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (string vertex in adjacency.Keys.OrderBy(v => v))
                Visit(vertex, visited, order);

            return order;
        }

        private void Visit(string vertex, HashSet<string> visited, List<string> order)
        {
            if (!visited.Add(vertex)) return;
            foreach (GraphEdge edge in adjacency[vertex])
                Visit(edge.To, visited, order);
            order.Add(vertex);
        }

        // Minimum spanning tree with Kruskal's algorithm. Sort all roads by distance and
        // keep a road only if it joins two parts that are not connected yet (checked with
        // a disjoint set). The result links every area with the least total distance.
        public List<GraphEdge> MinimumSpanningTree()
        {
            var tree = new List<GraphEdge>();
            var sets = new DisjointSet(adjacency.Keys);

            var edges = adjacency.Values
                .SelectMany(list => list)
                .Where(e => string.Compare(e.From, e.To, StringComparison.OrdinalIgnoreCase) < 0)
                .OrderBy(e => e.Weight)
                .ToList();

            foreach (GraphEdge edge in edges)
            {
                if (sets.Union(edge.From, edge.To))
                    tree.Add(edge);
                if (tree.Count == adjacency.Count - 1) break;
            }
            return tree;
        }

        // union-find with path compression, used by Kruskal to spot cycles quickly
        private class DisjointSet
        {
            private readonly Dictionary<string, string> parent =
                new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            private readonly Dictionary<string, int> rank =
                new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            public DisjointSet(IEnumerable<string> items)
            {
                foreach (string item in items)
                {
                    parent[item] = item;
                    rank[item] = 0;
                }
            }

            public string Find(string item)
            {
                if (!string.Equals(parent[item], item, StringComparison.OrdinalIgnoreCase))
                    parent[item] = Find(parent[item]);
                return parent[item];
            }

            // returns false when both are already in the same set (the edge would make a cycle)
            public bool Union(string a, string b)
            {
                string ra = Find(a);
                string rb = Find(b);
                if (string.Equals(ra, rb, StringComparison.OrdinalIgnoreCase)) return false;

                if (rank[ra] < rank[rb]) parent[ra] = rb;
                else if (rank[ra] > rank[rb]) parent[rb] = ra;
                else
                {
                    parent[rb] = ra;
                    rank[ra]++;
                }
                return true;
            }
        }
    }
}
