using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[][] intervals = { new int[] {1, 3}, new int[] {2, 6}, new int[] {8, 10}, new int[] {15, 18} };
        var mergedIntervals = MergeIntervals(intervals);
        Console.WriteLine("[" + string.Join(", ", mergedIntervals.Select(i => "[" + string.Join(",", i) + "]")) + "]");

        int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
        int target = 8;
        var combinations = CombinationSum2(candidates, target);
        Console.WriteLine("[" + string.Join(", ", combinations.Select(c => "[" + string.Join(",", c) + "]")) + "]");

        int n = 16;
        Console.WriteLine(IsPowerOfFour(n));

        int[] jobDifficulty = { 6, 5, 4, 3, 2, 1 };
        int d = 2;
        Console.WriteLine(MinDifficulty(jobDifficulty, d));
    }

    static int[][] MergeIntervals(int[][] intervals)
    {
        if (intervals.Length == 0) return new int[0][];
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        List<int[]> merged = new List<int[]>();
        foreach (var interval in intervals)
        {
            if (merged.Count == 0 || merged.Last()[1] < interval[0])
                merged.Add(interval);
            else
                merged.Last()[1] = Math.Max(merged.Last()[1], interval[1]);
        }
        return merged.ToArray();
    }

    static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        List<IList<int>> result = new List<IList<int>>();
        Backtrack(candidates, target, 0, new List<int>(), result);
        return result;
    }

    static void Backtrack(int[] candidates, int target, int start, List<int> tempList, List<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(tempList));
            return;
        }
        for (int i = start; i < candidates.Length; i++)
        {
            if (i > start && candidates[i] == candidates[i - 1]) continue;
            if (candidates[i] > target) break;
            tempList.Add(candidates[i]);
            Backtrack(candidates, target - candidates[i], i + 1, tempList, result);
            tempList.RemoveAt(tempList.Count - 1);
        }
    }

    static bool IsPowerOfFour(int n)
    {
        if (n <= 0) return false;
        while (n % 4 == 0)
            n /= 4;
        return n == 1;
    }

    static int MinDifficulty(int[] jobDifficulty, int d)
    {
        int n = jobDifficulty.Length;
        if (n < d) return -1;
        int[,] dp = new int[d + 1, n + 1];
        for (int i = 0; i <= d; i++)
            for (int j = 0; j <= n; j++)
                dp[i, j] = int.MaxValue / 2;
        dp[0, 0] = 0;
        for (int i = 1; i <= d; i++)
        {
            for (int j = i; j <= n; j++)
            {
                int maxJob = 0;
                for (int k = j; k >= i; k--)
                {
                    maxJob = Math.Max(maxJob, jobDifficulty[k - 1]);
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 1, k - 1] + maxJob);
                }
            }
        }
        return dp[d, n];
    }
}
