using System;
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
            var function = Fn.New((string a,string b)=>a+b);
            var reduced = function.New("re");

            var result = reduced("sult");
            Assert.AreEqual("result",result);

        }
        [TestMethod]
        public void CurryTwoToOneNumeric()
        {
            var function = Fn.New((int a, int b) => a + b);
            var reduced = function.New(1);

            var result = reduced(1);
            Assert.AreEqual(2,result);

        }
        [TestMethod]
        public void CurryTwoToOneStringAndNumeric()
        {
            var function = Fn.New((string a, int b) => a + b);
            var reduced = function.New("Number");

            var result = reduced(1);
            Assert.AreEqual("Number1", result);

        }
        [TestMethod]
        public void CurryThreeToOneNumeric()
        {
            var function = Fn.New((int a, int b, int c) => a + b + c);
            var reduced = function.New(1,2);

            var result = reduced(3);
            Assert.AreEqual(6, result);

        }
        [TestMethod]
        public void CurryThreeToTwoToOneNumeric()
        {
            var function = Fn.New((int a, int b, int c) => a + b + c);
            var result = function.New(1).New(2).Invoke(3);
            Assert.AreEqual(6, result);

        }
        [TestMethod]
        public void CurryNineToToOneNumeric()
        {
            var function = Fn.New((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9);
            var result = function.New(1).New(1).New(1).New(1).New(1).New(1).New(1).New(1)(1);
            Assert.AreEqual(9, result);

        }
        [TestMethod]
        public void CurryThreeToTwoNumeric()
        {
            var function = Fn.New((int a, int b, int c) => a + b + c);
            var reduced = function.New(1);

            var result = reduced(1,1);
            Assert.AreEqual(3, result);

        }
        [TestMethod]
        public void CurryTwoToResult()
        {
            var function = Fn.New((int a, int b) => a + b);
            var result = function.New(1)(1);

            Assert.AreEqual(2, 2);

        }    
    }
}
