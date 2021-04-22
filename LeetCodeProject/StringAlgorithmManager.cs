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

        // 344. 反转字符串
        // https://leetcode-cn.com/problems/reverse-string/
        public static void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            while(left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }

        public static void ShowLog()
        {
            //125. 验证回文串
            //string testStr = "A man, a plan, a canal: Panama";
            //Console.WriteLine(IsPalindrome(testStr));

            //344. 反转字符串
            char[] testChars = new char[]{ 'h','e','l','l','o' };
            ReverseString(testChars);
            Console.WriteLine(string.Concat<char>(testChars));
        }
    }
}
