using Caching_LRU.Manager;
using Caching_LRU;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Testing LRU Cache:");
        //ICache lruCache = new Cache(3, new LRUManager(3));
        //lruCache.Put(1, "A");
        //lruCache.Put(2, "B");
        //lruCache.Put(3, "C");
        //lruCache.Get(1); // Access key 1
        //lruCache.Put(4, "D"); // Evict key 2
        //Console.WriteLine(lruCache.Get(2)); // Output: Key not found.
        Console.WriteLine("Testing Thread-Safe Cache:");
        ICache cache = new Cache(3, new LRUManager(3));
        Console.WriteLine("===================");
        Console.WriteLine($"Cache is {cache}");
        Thread thread1 = new Thread(() => cache.Put(1, "A"));
        Thread thread2 = new Thread(() => cache.Put(2, "B"));
        Console.WriteLine($"Cache is {cache}");
        Thread thread3 = new Thread(() => Console.WriteLine(cache.Get(1)));
        Thread thread4 = new Thread(() => cache.Put(3, "C"));
        Thread thread5 = new Thread(() => cache.Put(4, "D")); // Evict least recently used

        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        thread5.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();
        thread5.Join();
        Console.WriteLine($"Cache is {cache}");

        Console.WriteLine("Testing Completed.");

        Console.WriteLine("\nTesting MRU Cache:");
        ICache mruCache = new Cache(3, new MRUManager(3));
        mruCache.Put(1, "A");
        mruCache.Put(2, "B");
        mruCache.Put(3, "C");
        mruCache.Get(3); // Access key 3
        mruCache.Put(4, "D"); // Evict key 3 (most recently used)
        Console.WriteLine(mruCache.Get(3)); // Output: Key not found.

        Console.WriteLine("\nTesting LFU Cache:");
        ICache lfuCache = new Cache(3, new LFUManager(3));
        lfuCache.Put(1, "A");
        lfuCache.Put(2, "B");
        lfuCache.Put(3, "C");
        lfuCache.Get(1); // Access key 1
        lfuCache.Get(1); // Access key 1 again
        lfuCache.Put(4, "D"); // Evict key 2 (least frequently used)
        Console.WriteLine(lfuCache.Get(2)); // Output: Key not found.

        Console.WriteLine("\nTesting FIFO Cache:");
        ICache fifoCache = new Cache(3, new FIFOManager(3));
        fifoCache.Put(1, "A");
        fifoCache.Put(2, "B");
        fifoCache.Put(3, "C");
        fifoCache.Put(4, "D"); // Evict key 1 (first-in)
        Console.WriteLine(fifoCache.Get(1)); // Output: Key not found.
    }
}
