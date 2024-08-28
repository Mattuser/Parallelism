using Parallelism;
using System.Diagnostics;

var sw = new Stopwatch();

sw.Start();
var result = Prime.InRangev1(200, 800000);
sw.Stop();

Console.WriteLine($"{result} prime numbers found in {sw.ElapsedMilliseconds / 1000} seconds ({Environment.ProcessorCount} processors).");
