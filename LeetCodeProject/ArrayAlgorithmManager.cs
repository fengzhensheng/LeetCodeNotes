//数组管理类 这里将做一些数组相关的LeetCode算法题
using System;
using System.Text;

namespace LeetCodeProject
{
    public static class ArrayAlgorithmManager
    {
        //打印数组
        private static void PrintArray(int[] arr)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i] + " ");
            }
            Console.WriteLine(sb.ToString());
        }

        //26. 删除排序数组中的重复项
        //https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/
        /// <summary>
        /// 用i,j指针来遍历数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        private static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 0)
                return 0;

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (!nums[i].Equals(nums[j]))
                {
                    nums[++i] = nums[j];
                }
            }
            return i + 1;
        }

        //122. 买卖股票的最佳时机 II
        //https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/
        /// <summary>
        /// 这道题只要把利润差进行相加即可
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            int total = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int delta = prices[i] - prices[i - 1];
                if (delta > 0)
                {
                    total += delta;
                }
            }
            return total;
        }

        //136. 只出现一次的数字
        //https://leetcode-cn.com/problems/single-number/
        public static int SingleNumber(int[] nums)
        {
            int t = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                t ^= nums[i];
            }
            return t;
        }

        //189. 旋转数组
        //https://leetcode-cn.com/problems/rotate-array/
        /// <summary>
        /// 这里做法是通过一个个替换的方式，直到走完一圈退出
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public static void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            k %= len;
            int count = 0;
            for(int i= 0; count < len; i++)
            {
                int curIndex = i;
                int curvalue = nums[curIndex];
                do
                {
                    int next = (curIndex + k) % len;
                    int temp = nums[next];
                    nums[next] = curvalue;
                    curvalue = temp;
                    curIndex = next;
                    count++;
                } while (curIndex != i);
            }
        }

        public static void ShowLog()
        {
            //26. 删除排序数组中的重复项
            //int[] testArray = new int[] { 1, 2, 2, 3, 3, 3, 5 };
            //int arrayLen = RemoveDuplicates(testArray);
            //Console.WriteLine(arrayLen);

            //122. 买卖股票的最佳时机 II
            //int[] testArray = new int[] {1, 9, 6, 9, 1, 7, 1, 1, 5, 9, 9, 9};
            //int arrayLen = MaxProfit(testArray);
            //Console.WriteLine(arrayLen);

            //136. 只出现一次的数字
            //int[] testArray = new int[] { 4, 1, 2, 1, 2 };
            //int arrayLen = SingleNumber(testArray);
            //Console.WriteLine(arrayLen);

            //189. 旋转数组
            //int[] testArray = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //Rotate(testArray, 3);
            //PrintArray(testArray);

        }
    }
}
