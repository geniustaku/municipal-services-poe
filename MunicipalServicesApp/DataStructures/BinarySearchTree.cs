// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    // Plain binary search tree. Smaller keys go left, bigger keys go right.
    // I use it to find a request by its number when a resident tracks it.
    // There is no balancing, so if keys arrive already sorted it turns into a long
    // chain. The Tree indexes tab shows this next to the AVL and red-black trees.
    public class BinarySearchTree<TKey, TValue> : BinaryTree<TKey, TValue>
    {
        public BinarySearchTree(IComparer<TKey> comparer = null) : base(comparer)
        {
        }

        public override void Insert(TKey key, TValue value)
        {
            Count++;

            if (root == null)
            {
                root = new BinaryNode<TKey, TValue>(key, value);
                NodeCount++;
                return;
            }

            BinaryNode<TKey, TValue> node = root;
            while (true)
            {
                int c = comparer.Compare(key, node.Key);
                if (c == 0)
                {
                    node.Values.Add(value);
                    return;
                }

                if (c < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryNode<TKey, TValue>(key, value);
                        NodeCount++;
                        return;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryNode<TKey, TValue>(key, value);
                        NodeCount++;
                        return;
                    }
                    node = node.Right;
                }
            }
        }
    }
}
