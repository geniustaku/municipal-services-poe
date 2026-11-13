// Municipal Services Application
// Genius Mhirizhonga  ST10541838

using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    // Binary min-heap stored in a list. The parent of index i is (i - 1) / 2 and its
    // children are 2i + 1 and 2i + 2. The smallest item (by the compare method) is
    // always at index 0, so Peek is O(1) and Push and Pop are O(log n).
    // I use it to decide which open request the municipality should attend next.
    public class MinHeap<T>
    {
        private readonly List<T> items = new List<T>();
        private readonly Comparison<T> compare;

        public MinHeap(Comparison<T> compare)
        {
            this.compare = compare;
        }

        public int Count
        {
            get { return items.Count; }
        }

        public void Push(T item)
        {
            items.Add(item);
            int i = items.Count - 1;

            // sift up while the new item is smaller than its parent
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (compare(items[i], items[parent]) >= 0) break;
                Swap(i, parent);
                i = parent;
            }
        }

        public T Peek()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("The heap is empty.");
            return items[0];
        }

        public T Pop()
        {
            T top = Peek();
            int last = items.Count - 1;
            items[0] = items[last];
            items.RemoveAt(last);

            // sift down, swapping with the smaller child each time
            int i = 0;
            while (true)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                int smallest = i;

                if (left < items.Count && compare(items[left], items[smallest]) < 0) smallest = left;
                if (right < items.Count && compare(items[right], items[smallest]) < 0) smallest = right;
                if (smallest == i) break;

                Swap(i, smallest);
                i = smallest;
            }

            return top;
        }

        private void Swap(int a, int b)
        {
            T tmp = items[a];
            items[a] = items[b];
            items[b] = tmp;
        }
    }
}
