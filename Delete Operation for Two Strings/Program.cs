using System.Linq;
using System.Collections.Generic;
using System;

namespace Delete_Operation_for_Two_Strings
{
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      int count = s.MinDistance("sea", "ate");
      Console.WriteLine(count);
    }
  }

  public class Solution
  {
    public int MinDistance(string word1, string word2)
    {
      var LCS_Length = LongestCommonSubsequence(word1, word2);

      int word1_unmatched = word1.Length - LCS_Length;
      int word2_unmatched = word2.Length - LCS_Length;

      return word1_unmatched + word2_unmatched;
    }

    // FInd the longest common subsequence first
    // example - sea and eat, so the longest common subsequence is 1 which is e
    // example - leetcode and etco, so the longest common subsequence is 4 which is "etco"
    // LCS is in two string defined as where char in both the string are same and should be in same order no need to be substring can be after at any place
    // if we calculate the LCS then we got the common chars in both string , after that we can substract the not matching chars from both str1 and str2
    // And finally addition of these two would be our final result
    private int LongestCommonSubsequence(string word1, string word2)
    {
      int row = word2.Length + 1;
      int column = word1.Length + 1;

      var dp = new int[row][];
      for (int i = row - 1; i >= 0; i--)
      {
        dp[i] = new int[column];
        for (int j = column - 1; j >= 0; j--)
        {
          if (i == row - 1 || j == column - 1)
          {
            continue;
          }
          if (word2[i] == word1[j])
          {
            dp[i][j] = 1 + dp[i + 1][j + 1];
          }
          else
          {

            dp[i][j] = Math.Max(dp[i][j + 1], dp[i + 1][j]);
          }
        }
      }

      return dp[0][0];
    }
  }
}
