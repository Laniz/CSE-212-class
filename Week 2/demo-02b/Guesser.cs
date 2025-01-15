using System.Diagnostics;

namespace demo_02b;

public static class Guesser {
    public static void Run() {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}", "n", "lazy-count", "lazy-time", "smart-count", "smart-time");
        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}", "----------");

        var random = new Random();
        for (int n = 1; n <= 100_000_002; n += 10_000_000) {
            var answer = random.Next(1, n);
            int count1 = GuessLazy(1, n, answer);
            int count2 = GuessSmart(1, n, answer);
            double time1 = Time(() => GuessLazy(1, n, answer), 15);
            double time2 = Time(() => GuessSmart(1, n, answer), 15);
            Console.WriteLine("{0,15}{1,15}{2,15:0.00000}{3,15}{4,15:0.00000}", n, count1, time1, count2, time2);
        }
    }

    private static int GuessLazy(int minNumber, int maxNumber, int answer) {
        var count = 0;
        for (var guess = minNumber; guess <= maxNumber; guess++) {
            count++;
            if (guess == answer)
                return count;
        }

        return count;
    }

    private static int GuessSmart(int minNumber, int maxNumber, int answer) {
        var guess = (maxNumber + minNumber) / 2;

        if (guess == answer)
            return 1;
        if (guess > answer)
            return 1 + GuessSmart(minNumber, guess - 1, answer);

        return 1 + GuessSmart(guess + 1, maxNumber, answer);
    }

    private static double Time(Action executeAlgorithm, int times) {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i) {
            executeAlgorithm();
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }
}