using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = nums[0];
            int m = nums[1];

            HashSet<int> nums1 = new HashSet<int>();
            HashSet<int> nums2 = new HashSet<int>();
            HashSet<int> commonSet = new HashSet<int>();


            for (int i = 0; i < n + m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i >= n)
                {
                    nums2.Add(num);
                    continue;
                }
                nums1.Add(num);
            }

            foreach (var item in nums1)
            {
                if (nums2.Contains(item))
                {
                    commonSet.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", commonSet));
        }
    }
}
