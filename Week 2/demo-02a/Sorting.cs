using System.Diagnostics;

namespace demo_02a;

public static class Sorting {
    public static void Run() {
        Console.WriteLine("{0,15}{1,15}{2,15}", "n", "count", "time");
        Console.WriteLine("{0,15}{0,15}{0,15}", "----------");

        for (int n = 0; n <= 20000; n += 2000) {
            int[] testData = BuildRandomArray(n);
            int count = Sort(testData);
            double time = Time(() => Sort(testData), 5);
            Console.WriteLine("{0,15}{1,15}{2,15:0.00000}", n, count, time);
        }
    }

    private static int Sort(int[] data) {
        var count = 0; // This is used to count loop iterations for analysis purposes
        for (var sortPos = data.Length - 1; sortPos >= 0; --sortPos) {
            var maxSwapPos = 0;
            for (var swapPos = 1; swapPos <= sortPos; ++swapPos) {
                count += 1;
                if (data[swapPos] > data[maxSwapPos])
                    maxSwapPos = swapPos;
            }

            (data[maxSwapPos], data[sortPos]) = (data[sortPos], data[maxSwapPos]);
        }

        return count;
    }

    private static int[] BuildRandomArray(int n) {
        var random = new Random();
        var result = new int[n];
        for (var i = 0; i < result.Length; i++) {
            result[i] = random.Next(1, 100);
        }

        return result;
    }

    private static double Time(Action executeAlgorithm, int times) {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i) {
            executeAlgorithm(); // Calls the action passed in to this method
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }
}