using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching_LRU.Manager
{
    public class MRUManager : IManager
    {
        private int capacity;
        private int[] usage;
        private int usageCounter;

        public MRUManager(int capacity)
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
            usage[index] = ++usageCounter;
        }

        public int FindEvictionCandidate()
        {
            int mostUsedIndex = 0;
            int maxUsage = usage[0];

            for (int i = 1; i < capacity; i++)
            {
                if (usage[i] > maxUsage)
                {
                    maxUsage = usage[i];
                    mostUsedIndex = i;
                }
            }

            return mostUsedIndex;
        }
    }

}
