using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching_LRU
{
    public class CacheEntry
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public CacheEntry(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }

}
