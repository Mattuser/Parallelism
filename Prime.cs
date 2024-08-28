﻿namespace Parallelism;
public static class Prime
{
    #region V1
    public static long InRangev1(long start, long end)
    {
        long result = 0;
        for(var number = start; number < end; number ++)
        {
            if (IsPrimev1(number))
                result++;
        }

        return result;
    }

    private static bool IsPrime(long number)
    {
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (long divisor = 3; divisor < (number / 2); divisor += 2)
        {
            if(number % divisor == 0) return false;
        }

        return true;
    }

    #endregion

    #region V2
    private static long InRangeV2(long start, long end)
    {
        long result = 0;
        var lockObject = new object();

        var range = end - start;
        var numberOfThreads = (long)Environment.ProcessorCount;

        var threads = new Thread[numberOfThreads];
        var chunkSize = range / numberOfThreads;

        for (long i = 0; i < numberOfThreads; i++)
        {
            var chunkStart = start + i * chunkSize;
            var chunkEnd = (i == (numberOfThreads - 1)) ? end : chunkStart + chunkSize;

            threads[i] = new Thread(() =>
            {
                for(var number = chunkStart; number < chunkEnd; number ++)
                {
                    if(IsPrime(number))
                    {
                        lock (lockObject)
                        {
                            result++;
                        }
                    }
                }
            });

            threads[i].Start();
        }

    }

    #endregion
}
