﻿using System;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class BasicCurryTests
    {
        [TestMethod]
        public void CurryTwoToOne()
        {
            var function = Fn.Func((string a, string b) => a + b);
            var reduced = function.Func("re");

            var result = reduced("sult");
            Assert.AreEqual("result", result);

        }
        [TestMethod]
        public void CurryTwoToOneNumeric()
        {
            var function = Fn.Func((int a, int b) => a + b);
            var reduced = function.Func(1);

            var result = reduced(1);
            Assert.AreEqual(2, result);

        }
        [TestMethod]
        public void CurryTwoToOneStringAndNumeric()
        {
            var function = Fn.Func((string a, int b) => a + b);
            var reduced = function.Func("Number");

            var result = reduced(1);
            Assert.AreEqual("Number1", result);

        }
        [TestMethod]
        public void CurryThreeToOneNumeric()
        {
            var function = Fn.Func((int a, int b, int c) => a + b + c);
            var reduced = function.Func(1, 2);

            var result = reduced(3);
            Assert.AreEqual(6, result);

        }
        [TestMethod]
        public void CurryThreeToTwoToOneNumeric()
        {
            var function = Fn.Func((int a, int b, int c) => a + b + c);
            var result = function.Func(1).Func(2).Invoke(3);
            Assert.AreEqual(6, result);

        }
        [TestMethod]
        public void CurryNineToToFiveNumeric()
        {
            var function = Fn.Func((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9);
            var reducedFunction = function.Func(1, 1, 1, 1);
            var result = reducedFunction(1, 1, 1, 1, 1);
            Assert.AreEqual(9, result);

        }
        [TestMethod]
        public void CurryNineToToOneNumeric()
        {
            var function = Fn.Func((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9);
            var result = function.Func(1).Func(1).Func(1).Func(1).Func(1).Func(1).Func(1).Func(1)(1);
            Assert.AreEqual(9, result);

        }
        [TestMethod]
        public void CurryThreeToTwoNumeric()
        {
            var function = Fn.Func((int a, int b, int c) => a + b + c);
            var reduced = function.Func(1);

            var result = reduced(1, 1);
            Assert.AreEqual(3, result);

        }
        [TestMethod]
        public void CurryTwoToResult()
        {
            var function = Fn.Func((int a, int b) => a + b);
            var result = function.Func(1)(1);

            Assert.AreEqual(2, 2);

        }
    }
}
