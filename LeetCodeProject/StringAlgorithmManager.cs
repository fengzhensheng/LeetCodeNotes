//字符串管理类
using System;

namespace LeetCodeProject
{
    public static class StringAlgorithmManager
    {
        //125. 验证回文串
        //https://leetcode-cn.com/problems/valid-palindrome/
        public static bool IsPalindrome(string s)
        {
            if (s.Length <= 1)
                return true;
            int left = 0;
            int right = s.Length - 1;
            while(left < right)
            {
                while(left < right && !Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while(left < right && !Char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                if (!Char.ToLower(s[left]).Equals(Char.ToLower(s[right])))
                    return false;

                left++;
                right--;
            }
            return true;
        }

        public static void ShowLog()
        {
            //125. 验证回文串
            //string testStr = "A man, a plan, a canal: Panama";
            //Console.WriteLine(IsPalindrome(testStr));
        }
    }
}
