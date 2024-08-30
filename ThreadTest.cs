namespace Parallelism;
public class ThreadTest
{
    public static void V1(int start, int end)
    {
        var range = end - start;
        var numberOfThreads = (long)Environment.ProcessorCount;
        var lockObject = new object();

        var threads = new Thread[numberOfThreads];
        var chunkSize = range / numberOfThreads;

        for (int i = 0; i < numberOfThreads; i++)
        {
            var chunkStart = start + i * chunkSize;
            var chunkEnd = (i == (numberOfThreads - 1)) ? end : chunkStart + chunkSize;

            threads[i] = new Thread(() =>
            {
                for (var number = chunkStart; number < chunkEnd; number++)
                {
                    Console.WriteLine(chunkEnd);
                }

            });

            threads[i].Start();
        }

    }

    public static void V1_2(int start, int end)
    {
        var range = end - start;
        var numberOfThreads = (long)Environment.ProcessorCount;
        var results = new long[numberOfThreads];

        var threads = new Thread[numberOfThreads];
        var chunkSize = range / numberOfThreads;

        for (int i = 0; i < numberOfThreads; i++)
        {
            var chunkStart = start + i * chunkSize;
            var chunkEnd = (i == (numberOfThreads - 1)) ? end : chunkStart + chunkSize;
            var current = i;

            
            threads[i] = new Thread(() =>
            {
                Console.WriteLine(i);
                results[current] = 0;
             
                for (var number = chunkStart; number < chunkEnd; number++)
                {
                    //Console.WriteLine(threads[results[current]]);
                    results[current]++;
                }

            });

            threads[i].Start();
        }

    }

    public static void V1_3(int start, int end)
    {
        var numberOfThreads = (long)Environment.ProcessorCount;
        var threads = new Thread[numberOfThreads];
        

        for (int i = 0; i < numberOfThreads; i++)
        {
            var current = i;

            if (i == 12)
                Console.WriteLine("opa");

            threads[i] = new Thread(() =>
            {
                Console.WriteLine(threads[current]);
            });

            threads[i].Start();
        }

    }
}
