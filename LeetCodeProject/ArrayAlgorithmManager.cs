//数组管理类 这里将做一些数组相关的LeetCode算法题
namespace LeetCodeProject
{
    public static class ArrayAlgorithmManager
    {
        //26. 删除排序数组中的重复项
        //https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/
        private static int RemoveDuplicates(int[] nums)
        {
            int len = nums.Length;
            //避免数组越界
            if(len<=0)
            {
                return 0;
            }
            int replaceIndex = 0;//替换的数组索引 默认第一个
            int curValue = nums[0];//初始化当前值
            for (int i = 1; i < len; i++)
            {
                //只有不同的情况下 做替换操作
                if (!nums[i].Equals(curValue))
                {
                    replaceIndex++;
                    nums[replaceIndex] = nums[i]; 
                }
                //保持当前值为对比后的值
                curValue = nums[i];
            }
            //之所以加一 因为默认索引从0开始 而长度指实际数量
            return replaceIndex + 1;
        }


        public static void ShowLog()
        {
            //26实例测试
            //int[] testArray = new int[]{1,2,2,3,3,3,5};
            //int arrayLen = RemoveDuplicates(testArray);
            //Console.WriteLine(arrayLen);
        }
    }
}
