using LR2.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LR2.Tests
{
    [TestClass]
    public class LcmTests
    {

        [TestMethod] public void Lcm_1_1_Returns_1() => Assert.AreEqual(1, new Lcm(1, 1).Compute());
        [TestMethod] public void Lcm_3_5_Returns_15() => Assert.AreEqual(15, new Lcm(3, 5).Compute());
        [TestMethod] public void Lcm_4_2_Returns_4() => Assert.AreEqual(4, new Lcm(4, 2).Compute());
        [TestMethod] public void Lcm_7_7_Returns_7() => Assert.AreEqual(7, new Lcm(7, 7).Compute());
        [TestMethod] public void Lcm_12_18_Returns_36() => Assert.AreEqual(36, new Lcm(12, 18).Compute());

        [TestMethod]
        public void Lcm_Bruteforce_Matches()
        {
            for (int a = 1; a <= 30; a++)
                for (int b = 1; b <= 30; b++)
                {
                    int fast = new Lcm(a, b).Compute();
                    int slow = new Lcm(a, b).ComputeBruteforce();
                    Assert.AreEqual(slow, fast, $"Расхождение на a={a}, b={b}");
                }
        }

        [TestMethod]
        public void Lcm_Zero_A_Throws()
        {
            try
            {
                new Lcm(0, 5);
                Assert.Fail("Ожидалось ArgumentOutOfRangeException для a=0");
            }
            catch (ArgumentOutOfRangeException) { /* ok */ }
        }

        [TestMethod]
        public void Lcm_Zero_B_Throws()
        {
            try
            {
                new Lcm(5, 0);
                Assert.Fail("Ожидалось ArgumentOutOfRangeException для b=0");
            }
            catch (ArgumentOutOfRangeException) { /* ok */ }
        }

        [TestMethod]
        public void Lcm_Negative_A_Throws()
        {
            try
            {
                new Lcm(-3, 5);
                Assert.Fail("Ожидалось ArgumentOutOfRangeException для a=-3");
            }
            catch (ArgumentOutOfRangeException) { /* ok */ }
        }

        [TestMethod]
        public void Lcm_Negative_B_Throws()
        {
            try
            {
                new Lcm(5, -3);
                Assert.Fail("Ожидалось ArgumentOutOfRangeException для b=-3");
            }
            catch (ArgumentOutOfRangeException) { /* ok */ }
        }


        [TestMethod]
        public void Lcm_Symmetric()
        {
            for (int a = 1; a <= 20; a++)
                for (int b = 1; b <= 20; b++)
                    Assert.AreEqual(new Lcm(a, b).Compute(), new Lcm(b, a).Compute(),
                        $"НОК не симметричен для a={a}, b={b}");
        }

        [TestMethod]
        public void Lcm_Divisible_By_Both()
        {
            for (int a = 1; a <= 20; a++)
                for (int b = 1; b <= 20; b++)
                {
                    int lcm = new Lcm(a, b).Compute();
                    Assert.AreEqual(0, lcm % a, $"НОК({a},{b}) не делится на {a}");
                    Assert.AreEqual(0, lcm % b, $"НОК({a},{b}) не делится на {b}");
                }
        }
    }
}
