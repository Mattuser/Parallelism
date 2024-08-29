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
}
