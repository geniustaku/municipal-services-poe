using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.Services
{
    // Small priority queue built on a binary heap. The item with the smallest
    // priority value comes out first, which I use to pull the soonest event.
    public class PriorityQueue<T>
    {
        private readonly List<KeyValuePair<long, T>> heap = new List<KeyValuePair<long, T>>();

        public int Count
        {
            get { return heap.Count; }
        }

        public void Enqueue(long priority, T item)
        {
            heap.Add(new KeyValuePair<long, T>(priority, item));
            int i = heap.Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (heap[parent].Key <= heap[i].Key) break;
                Swap(i, parent);
                i = parent;
            }
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("The priority queue is empty.");

            T top = heap[0].Value;
            int last = heap.Count - 1;
            heap[0] = heap[last];
            heap.RemoveAt(last);

            int i = 0;
            while (true)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                int smallest = i;

                if (left < heap.Count && heap[left].Key < heap[smallest].Key) smallest = left;
                if (right < heap.Count && heap[right].Key < heap[smallest].Key) smallest = right;
                if (smallest == i) break;

                Swap(i, smallest);
                i = smallest;
            }

            return top;
        }

        private void Swap(int a, int b)
        {
            var tmp = heap[a];
            heap[a] = heap[b];
            heap[b] = tmp;
        }
    }
}
