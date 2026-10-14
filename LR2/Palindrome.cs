using System;
using System.Text;

namespace LR2.Core
{
    public class Palindrome
    {
        public string Value { get; }

        public Palindrome(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool IsPalindrome()
        {
            var sb = new StringBuilder(Value.Length);
            foreach (char c in Value)
            {
                if (char.IsLetterOrDigit(c))
                    sb.Append(char.ToLowerInvariant(c));
            }

            string s = sb.ToString();
            int i = 0, j = s.Length - 1;
            while (i < j)
            {
                if (s[i] != s[j]) return false;
                i++;
                j--;
            }
            return true;
        }
    }
}
