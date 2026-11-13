// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    // Red-black tree, the left-leaning version described by Sedgewick.
    // Every node is red or black, the root is black, a red node never has a red child
    // and every path from the root down has the same number of black nodes. Those rules
    // keep the height under 2 x log2(n). It balances with fewer rotations than AVL,
    // which suits the area index because new areas get added as residents report.
    public class RedBlackTree<TKey, TValue> : BinaryTree<TKey, TValue>
    {
        public RedBlackTree(IComparer<TKey> comparer = null) : base(comparer)
        {
        }

        public int Rotations { get; private set; }

        public override void Insert(TKey key, TValue value)
        {
            Count++;
            root = Insert(root, key, value);
            root.IsRed = false;
        }

        private BinaryNode<TKey, TValue> Insert(BinaryNode<TKey, TValue> h, TKey key, TValue value)
        {
            if (h == null)
            {
                NodeCount++;
                return new BinaryNode<TKey, TValue>(key, value) { IsRed = true };
            }

            int c = comparer.Compare(key, h.Key);
            if (c == 0) h.Values.Add(value);
            else if (c < 0) h.Left = Insert(h.Left, key, value);
            else h.Right = Insert(h.Right, key, value);

            // fix the colour rules on the way back up
            if (IsRed(h.Right) && !IsRed(h.Left)) h = RotateLeft(h);
            if (IsRed(h.Left) && IsRed(h.Left.Left)) h = RotateRight(h);
            if (IsRed(h.Left) && IsRed(h.Right)) FlipColours(h);

            return h;
        }

        // number of black nodes on the way down to a leaf, the same on every path
        public int BlackHeight
        {
            get
            {
                int count = 0;
                for (BinaryNode<TKey, TValue> n = root; n != null; n = n.Left)
                    if (!n.IsRed) count++;
                return count;
            }
        }

        public int RedNodes
        {
            get { return CountRed(root); }
        }

        private static int CountRed(BinaryNode<TKey, TValue> node)
        {
            if (node == null) return 0;
            return (node.IsRed ? 1 : 0) + CountRed(node.Left) + CountRed(node.Right);
        }

        private static bool IsRed(BinaryNode<TKey, TValue> node)
        {
            return node != null && node.IsRed;
        }

        private BinaryNode<TKey, TValue> RotateLeft(BinaryNode<TKey, TValue> h)
        {
            Rotations++;
            BinaryNode<TKey, TValue> x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.IsRed = h.IsRed;
            h.IsRed = true;
            return x;
        }

        private BinaryNode<TKey, TValue> RotateRight(BinaryNode<TKey, TValue> h)
        {
            Rotations++;
            BinaryNode<TKey, TValue> x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.IsRed = h.IsRed;
            h.IsRed = true;
            return x;
        }

        private static void FlipColours(BinaryNode<TKey, TValue> h)
        {
            h.IsRed = true;
            h.Left.IsRed = false;
            h.Right.IsRed = false;
        }
    }
}
