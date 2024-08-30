using Parallelism;
using System.Diagnostics;

var sw = new Stopwatch();

//sw.Start();
//var result = Prime.InRangeV2_1(200, 800000);
//sw.Stop();

//Console.WriteLine($"{result} prime numbers found in " +
//    $"{sw.ElapsedMilliseconds / 1000} seconds " +
//    $"({Environment.ProcessorCount} processors).");


ThreadTest.V1_2(1, 10);