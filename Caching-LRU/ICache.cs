using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching_LRU
{
    public interface ICache
    {
        string Get(int key); // Retrieve a value by key
        void Put(int key, string value); // Insert or update a key-value pair
    }

}
