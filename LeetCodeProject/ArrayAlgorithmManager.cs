//数组管理类 这里将做一些数组相关的LeetCode算法题
using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCodeProject
{
    public static class ArrayAlgorithmManager
    {
        //打印数组
        private static void PrintArray(int[] arr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
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
            for (int i = 1; i < nums.Length; i++)
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
            for (int i = 0; count < len; i++)
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

        //217. 存在重复元素
        //https://leetcode-cn.com/problems/contains-duplicate/
        /// <summary>
        /// //先做排序 后做比较
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate1(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return false;
            }

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i].Equals(nums[i + 1]))
                {
                    return true;
                }
            }
            return false;
        }

        //用哈希集来做
        public static bool ContainsDuplicate2(int[] nums)
        {
            HashSet<int> hashMap = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!hashMap.Add(nums[i]))
                {
                    return true;
                }
            }
            return false;
        }

        //350. 两个数组的交集 II
        //https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/
        /// <summary>
        /// 双指针处理
        /// </summary>
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> finalList = new List<int>();
            //判空处理
            if (nums1 == null || nums1.Length == 0 || nums2 == null || nums2.Length == 0)
            {
                return finalList.ToArray();
            }
            Array.Sort(nums1);
            Array.Sort(nums2);

            //判断界限
            if(nums1[0] > nums2[nums2.Length-1] || nums2[0] > nums1[nums1.Length - 1])
            {
                return finalList.ToArray();
            }

            int i = 0, j = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if(nums1[i] == nums2[j])
                {
                    finalList.Add(nums1[i]);
                    i++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
            }
            return finalList.ToArray();
        }

        //66. 加一
        //https://leetcode-cn.com/problems/plus-one/
        /// <summary>
        /// 使用数组本身进行求解 这里考虑从最后开始添加值
        /// 添加时注意进位情况 输入[0,9]->[1,0];[9,9]->[1,0,0]
        /// </summary>
        public static int[] PlusOne(int[] digits)
        {
            for(int i = digits.Length - 1; i >= 0; i--)
            {
                if(digits[i] != 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            //走到这里证明数组值全为9 此时数组数据已全部赋值为0 所以构造一个新数组前面加个1即可
            int[] newArr = new int[digits.Length + 1];
            newArr[0] = 1;
            return newArr;
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

            //217. 存在重复元素
            //int[] testArray = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            //Console.WriteLine(ContainsDuplicate1(testArray));
            //Console.WriteLine(ContainsDuplicate2(testArray));

            //350. 两个数组的交集 II
            //int[] test1Array = new int[] { 1, 2, 2, 1 };
            //int[] test2Array = new int[] { 2, 2 };
            //var finalArr = Intersect(test1Array, test2Array);
            //PrintArray(finalArr);

            //66. 加一
            //int[] testArr = new int[] { 9, 9, 9 };
            //PrintArray(PlusOne(testArr));
        }
    }
}
