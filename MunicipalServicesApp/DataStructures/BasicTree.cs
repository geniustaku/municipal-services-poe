// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    // A node in a general (basic) tree. Unlike a binary tree a node can have any number
    // of children. Group nodes only have a name, the leaves also hold an item.
    public class TreeNode<T>
    {
        public string Name { get; private set; }
        public T Item { get; private set; }
        public TreeNode<T> Parent { get; private set; }
        public List<TreeNode<T>> Children { get; private set; }

        public TreeNode(string name, T item, TreeNode<T> parent)
        {
            Name = name;
            Item = item;
            Parent = parent;
            Children = new List<TreeNode<T>>();
        }

        public bool IsLeaf
        {
            get { return Children.Count == 0; }
        }

        public TreeNode<T> FindChild(string name)
        {
            foreach (TreeNode<T> child in Children)
                if (string.Equals(child.Name, name, StringComparison.OrdinalIgnoreCase))
                    return child;
            return null;
        }

        public TreeNode<T> AddChild(string name, T item)
        {
            var child = new TreeNode<T>(name, item, this);
            Children.Add(child);
            return child;
        }

        // every item stored under this node (depth first)
        public List<T> Items()
        {
            var result = new List<T>();
            Collect(this, result);
            return result;
        }

        private static void Collect(TreeNode<T> node, List<T> result)
        {
            if (node.IsLeaf && node.Parent != null)
                result.Add(node.Item);
            foreach (TreeNode<T> child in node.Children)
                Collect(child, result);
        }
    }

    // General tree used for the municipal structure: department, then category,
    // then the requests themselves. It matches how the municipality is organised.
    public class BasicTree<T>
    {
        public TreeNode<T> Root { get; private set; }

        public BasicTree(string rootName)
        {
            Root = new TreeNode<T>(rootName, default(T), null);
        }

        // adds the item under the given path, creating group nodes that are missing
        public void Add(T item, string itemName, params string[] path)
        {
            TreeNode<T> node = Root;
            foreach (string part in path)
            {
                TreeNode<T> next = node.FindChild(part);
                if (next == null)
                    next = node.AddChild(part, default(T));
                node = next;
            }
            node.AddChild(itemName, item);
        }

        public int Depth
        {
            get { return DepthOf(Root); }
        }

        private static int DepthOf(TreeNode<T> node)
        {
            int deepest = 0;
            foreach (TreeNode<T> child in node.Children)
                deepest = Math.Max(deepest, DepthOf(child));
            return deepest + 1;
        }
    }
}
