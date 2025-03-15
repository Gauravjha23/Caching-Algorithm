using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching_LRU.Manager
{
    public class FIFOManager : IManager
    {
        private int capacity;
        private int[] insertionOrder;
        private int counter;

        public FIFOManager(int capacity)
        {
            this.capacity = capacity;
            insertionOrder = new int[capacity];
            counter = 0;

            for (int i = 0; i < capacity; i++)
            {
                insertionOrder[i] = -1;
            }
        }

        public void UpdateUsage(int index)
        {
            insertionOrder[index] = counter++;
        }

        public int FindEvictionCandidate()
        {
            int oldestIndex = 0;
            int oldestValue = insertionOrder[0];

            for (int i = 1; i < capacity; i++)
            {
                if (insertionOrder[i] < oldestValue)
                {
                    oldestValue = insertionOrder[i];
                    oldestIndex = i;
                }
            }

            return oldestIndex;
        }
    }

}
