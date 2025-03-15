using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching_LRU.Manager
{
    public class LRUManager : IManager
    {
        private int capacity;
        private int[] usage;
        private int usageCounter;
        private readonly object lockObj = new object();

        public LRUManager(int capacity)
        {
            this.capacity = capacity;
            usage = new int[capacity];
            usageCounter = 0;

            for (int i = 0; i < capacity; i++)
            {
                usage[i] = 0;
            }
        }

        public void UpdateUsage(int index)
        {
            lock (lockObj)
            {
                usage[index] = ++usageCounter; // Update access timestamp
            }
        }

        public int FindEvictionCandidate()
        {
            lock (lockObj)
            {
                int leastUsedIndex = 0;
                int minUsage = usage[0];

                for (int i = 1; i < capacity; i++)
                {
                    if (usage[i] < minUsage)
                    {
                        minUsage = usage[i];
                        leastUsedIndex = i;
                    }
                }

                return leastUsedIndex;
            }
        }
    }


}
