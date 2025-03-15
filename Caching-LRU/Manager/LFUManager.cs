using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching_LRU.Manager
{
    public class LFUManager : IManager
    {
        private int capacity;
        private int[] frequency;

        public LFUManager(int capacity)
        {
            this.capacity = capacity;
            frequency = new int[capacity];

            for (int i = 0; i < capacity; i++)
            {
                frequency[i] = 0;
            }
        }

        public void UpdateUsage(int index)
        {
            frequency[index]++;
        }

        public int FindEvictionCandidate()
        {
            int leastUsedIndex = 0;
            int minFrequency = frequency[0];

            for (int i = 1; i < capacity; i++)
            {
                if (frequency[i] < minFrequency)
                {
                    minFrequency = frequency[i];
                    leastUsedIndex = i;
                }
            }

            return leastUsedIndex;
        }
    }

}
