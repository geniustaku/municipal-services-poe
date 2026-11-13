// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    // One node in my binary trees. More than one request can share a key (two requests
    // on the same day, or in the same area) so each node keeps a list of values.
    public class BinaryNode<TKey, TValue>
    {
        public TKey Key;
        public List<TValue> Values = new List<TValue>();
        public BinaryNode<TKey, TValue> Left;
        public BinaryNode<TKey, TValue> Right;
        public int Height = 1;      // only used by the AVL tree
        public bool IsRed = true;   // only used by the red-black tree

        public BinaryNode(TKey key, TValue value)
        {
            Key = key;
            Values.Add(value);
        }
    }

    // The base binary tree. Every node has at most two children. This class has the
    // parts all my trees share: the root, the height, search and the traversals.
    // The BST, AVL and red-black trees only change how a new key is inserted.
    public abstract class BinaryTree<TKey, TValue>
    {
        protected BinaryNode<TKey, TValue> root;
        protected readonly IComparer<TKey> comparer;

        protected BinaryTree(IComparer<TKey> comparer)
        {
            this.comparer = comparer ?? Comparer<TKey>.Default;
        }

        public int Count { get; protected set; }      // values stored
        public int NodeCount { get; protected set; }  // distinct keys

        public abstract void Insert(TKey key, TValue value);

        public int Height
        {
            get { return HeightOf(root); }
        }

        private static int HeightOf(BinaryNode<TKey, TValue> node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(HeightOf(node.Left), HeightOf(node.Right));
        }

        // search is the same in all three trees because they all keep left < node < right,
        // so each step throws away half of what is left (when the tree is balanced)
        public List<TValue> Find(TKey key)
        {
            BinaryNode<TKey, TValue> node = root;
            while (node != null)
            {
                int c = comparer.Compare(key, node.Key);
                if (c == 0) return new List<TValue>(node.Values);
                node = c < 0 ? node.Left : node.Right;
            }
            return new List<TValue>();
        }

        // in-order (left, node, right) gives the values sorted by key
        public List<TValue> InOrder()
        {
            var result = new List<TValue>();
            InOrder(root, result);
            return result;
        }

        private static void InOrder(BinaryNode<TKey, TValue> node, List<TValue> result)
        {
            if (node == null) return;
            InOrder(node.Left, result);
            result.AddRange(node.Values);
            InOrder(node.Right, result);
        }

        public List<TKey> KeysInOrder()
        {
            var keys = new List<TKey>();
            KeysInOrder(root, keys);
            return keys;
        }

        private static void KeysInOrder(BinaryNode<TKey, TValue> node, List<TKey> keys)
        {
            if (node == null) return;
            KeysInOrder(node.Left, keys);
            keys.Add(node.Key);
            KeysInOrder(node.Right, keys);
        }

        // pre-order (node, left, right), shows the shape of the tree from the root down
        public List<TKey> PreOrderKeys()
        {
            var keys = new List<TKey>();
            var stack = new Stack<BinaryNode<TKey, TValue>>();
            if (root != null) stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                keys.Add(node.Key);
                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }
            return keys;
        }

        // level by level (breadth first) with a queue, used on the Tree indexes tab
        public List<List<TKey>> LevelOrderKeys()
        {
            var levels = new List<List<TKey>>();
            var queue = new Queue<BinaryNode<TKey, TValue>>();
            if (root != null) queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                var level = new List<TKey>();
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node.Key);
                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
                levels.Add(level);
            }
            return levels;
        }

        // every value with a key from "from" to "to". branches that cannot hold a match
        // are skipped, so a date range does not have to look at every request.
        public List<TValue> Range(TKey from, TKey to)
        {
            var result = new List<TValue>();
            Range(root, from, to, result);
            return result;
        }

        private void Range(BinaryNode<TKey, TValue> node, TKey from, TKey to, List<TValue> result)
        {
            if (node == null) return;
            int cFrom = comparer.Compare(from, node.Key);
            int cTo = comparer.Compare(to, node.Key);

            if (cFrom < 0) Range(node.Left, from, to, result);
            if (cFrom <= 0 && cTo >= 0) result.AddRange(node.Values);
            if (cTo > 0) Range(node.Right, from, to, result);
        }
    }
}
