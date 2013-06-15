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
            var function = Fn.Create((string a,string b)=>a+b);
            var reduced = function.CInvoke("re");

            var result = reduced("sult");
            Assert.AreEqual("result",result);

        }
        [TestMethod]
        public void CurryTwoToOneNumeric()
        {
            var function = Fn.Create((int a, int b) => a + b);
            var reduced = function.CInvoke(1);

            var result = reduced(1);
            Assert.AreEqual(2,result);

        }
        [TestMethod]
        public void CurryTwoToOneStringAndNumeric()
        {
            var function = Fn.Create((string a, int b) => a + b);
            var reduced = function.CInvoke("Number");

            var result = reduced(1);
            Assert.AreEqual("Number1", result);

        }
        [TestMethod]
        public void CurryThreeToOneNumeric()
        {
            var function = Fn.Create((int a, int b, int c) => a + b + c);
            var reduced = function.CInvoke(1,2);

            var result = reduced(3);
            Assert.AreEqual(6, result);

        }
        [TestMethod]
        public void CurryThreeToTwoNumeric()
        {
            var function = Fn.Create((int a, int b, int c) => a + b + c);
            var reduced = function.CInvoke(1);

            var result = reduced(1,1);
            Assert.AreEqual(3, result);

        }
        [TestMethod]
        public void CurryTwoToResult()
        {
            var function = Fn.Create((int a, int b) => a + b);
            var result = function.CInvoke(1,1);

            Assert.AreEqual(2, 2);

        }    
    }
}
