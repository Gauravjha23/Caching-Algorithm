using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching_LRU.Manager
{
    public interface IManager
    {
        void UpdateUsage(int index); // Updates the usage/access metadata of an entry
        int FindEvictionCandidate(); // Finds the appropriate index for eviction
    }

}
