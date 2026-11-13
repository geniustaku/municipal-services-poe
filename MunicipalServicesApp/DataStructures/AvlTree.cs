// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    // AVL tree: a binary search tree that rebalances itself after every insert.
    // The heights of the left and right side of any node never differ by more than 1,
    // so the height stays close to log2(n). I use it for the date submitted, because
    // requests arrive in date order and a plain BST would become a long chain.
    public class AvlTree<TKey, TValue> : BinaryTree<TKey, TValue>
    {
        public AvlTree(IComparer<TKey> comparer = null) : base(comparer)
        {
        }

        // how many rotations it took to stay balanced (shown on the Tree indexes tab)
        public int Rotations { get; private set; }

        public override void Insert(TKey key, TValue value)
        {
            Count++;
            root = Insert(root, key, value);
        }

        private BinaryNode<TKey, TValue> Insert(BinaryNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null)
            {
                NodeCount++;
                return new BinaryNode<TKey, TValue>(key, value);
            }

            int c = comparer.Compare(key, node.Key);
            if (c == 0)
            {
                node.Values.Add(value);
                return node;
            }

            if (c < 0)
                node.Left = Insert(node.Left, key, value);
            else
                node.Right = Insert(node.Right, key, value);

            UpdateHeight(node);
            int balance = Balance(node);

            // left side too tall
            if (balance > 1)
            {
                if (Balance(node.Left) < 0)
                    node.Left = RotateLeft(node.Left);   // left-right case
                return RotateRight(node);                // left-left case
            }

            // right side too tall
            if (balance < -1)
            {
                if (Balance(node.Right) > 0)
                    node.Right = RotateRight(node.Right); // right-left case
                return RotateLeft(node);                  // right-right case
            }

            return node;
        }

        private static int H(BinaryNode<TKey, TValue> node)
        {
            return node == null ? 0 : node.Height;
        }

        private static void UpdateHeight(BinaryNode<TKey, TValue> node)
        {
            node.Height = 1 + Math.Max(H(node.Left), H(node.Right));
        }

        private static int Balance(BinaryNode<TKey, TValue> node)
        {
            return node == null ? 0 : H(node.Left) - H(node.Right);
        }

        private BinaryNode<TKey, TValue> RotateRight(BinaryNode<TKey, TValue> y)
        {
            Rotations++;
            BinaryNode<TKey, TValue> x = y.Left;
            y.Left = x.Right;
            x.Right = y;
            UpdateHeight(y);
            UpdateHeight(x);
            return x;
        }

        private BinaryNode<TKey, TValue> RotateLeft(BinaryNode<TKey, TValue> x)
        {
            Rotations++;
            BinaryNode<TKey, TValue> y = x.Right;
            x.Right = y.Left;
            y.Left = x;
            UpdateHeight(x);
            UpdateHeight(y);
            return y;
        }
    }
}
