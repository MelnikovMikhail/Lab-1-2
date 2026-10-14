using LR2.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LR2.Tests
{
    [TestClass]
    public class PalindromeTests
    {
        [TestMethod] public void Palindrome_Level_True() => Assert.IsTrue(new Palindrome("level").IsPalindrome());
        [TestMethod] public void Palindrome_Hello_False() => Assert.IsFalse(new Palindrome("hello").IsPalindrome());
        [TestMethod] public void Palindrome_Empty_True() => Assert.IsTrue(new Palindrome("").IsPalindrome());
        [TestMethod] public void Palindrome_OneChar_True() => Assert.IsTrue(new Palindrome("a").IsPalindrome());

        [TestMethod]
        public void Palindrome_MixedCase_True() =>
            Assert.IsTrue(new Palindrome("RaceCar").IsPalindrome());

        [TestMethod]
        public void Palindrome_Russian_True() =>
            Assert.IsTrue(new Palindrome("А роза упала на лапу Азора").IsPalindrome());

        [TestMethod]
        public void Palindrome_Sentence_True() =>
            Assert.IsTrue(new Palindrome("A man, a plan, a canal: Panama").IsPalindrome());

        [TestMethod] public void Palindrome_12321_True() => Assert.IsTrue(new Palindrome("12321").IsPalindrome());
        [TestMethod] public void Palindrome_12345_False() => Assert.IsFalse(new Palindrome("12345").IsPalindrome());

        [TestMethod]
        public void Palindrome_Null_Throws()
        {
            try
            {
                new Palindrome(null);
                Assert.Fail("Ожидалось ArgumentNullException для null");
            }
            catch (ArgumentNullException) { /* ok */ }
        }

        [TestMethod]
        public void Palindrome_Reversed_Same_Result()
        {
            string[] samples = { "level", "hello", "RaceCar", "12321" };
            foreach (var s in samples)
            {
                char[] arr = s.ToCharArray();
                Array.Reverse(arr);
                string rev = new string(arr);
                Assert.AreEqual(
                    new Palindrome(s).IsPalindrome(),
                    new Palindrome(rev).IsPalindrome(),
                    $"Расхождение для s=\"{s}\"");
            }
        }
    }
}
