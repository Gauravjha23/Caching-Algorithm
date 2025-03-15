using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caching_LRU.Manager;

namespace Caching_LRU
{
    public class Cache : ICache
    {
        private int capacity;
        private CacheEntry[] entries;
        private IManager manager;

        public Cache(int capacity, IManager manager)
        {
            this.capacity = capacity;
            this.entries = new CacheEntry[capacity];
            this.manager = manager;

            for (int i = 0; i < capacity; i++)
            {
                entries[i] = null;
            }
        }

        public string Get(int key)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {
                    manager.UpdateUsage(i);
                    return entries[i].Value;
                }
            }

            return "Key not found.";
        }

        public void Put(int key, string value)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {
                    entries[i].Value = value;
                    manager.UpdateUsage(i);
                    return;
                }
            }

            int emptySlot = FindEmptySlot();
            if (emptySlot == -1)
            {
                emptySlot = manager.FindEvictionCandidate();
            }

            entries[emptySlot] = new CacheEntry(key, value);
            manager.UpdateUsage(emptySlot);
        }

        private int FindEmptySlot()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (entries[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }
    }

}
