using System;
using System.ComponentModel;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class BasicInvokeTests
    {

        [TestMethod]
        public void ActionTest()
        {
            var some = false;
            {
                some = true;
            }
            Assert.IsTrue(some);
        }

        [TestMethod]
        public void CapsulateTest()
        {
            var some = false;

            {
                var invisible = 0;
                some = true;
            }

            // cannot resolve symbol: invisible = 1;

            Assert.IsTrue(some);
        }


        [TestMethod]
        public void Invoke_String()
        {
            var invokedResult = Fn.Select(() => "result");
            Assert.AreEqual("result", invokedResult);
        }
        [TestMethod]
        public void Invoke_Simple_Calculation()
        {
            var invokedResult = Fn.Select(() => 1 + 2);
            Assert.AreEqual(3, invokedResult);
        }
        [TestMethod]
        public void Invoke_Anonymous_Type()
        {
            var invokedResult = Fn.Select(() => new { x = 1, y = 2 });
            Assert.AreEqual(new { x = 1, y = 2 }, invokedResult);
        }
        [TestMethod]
        public void Invoke_Anonymous_Type_With_Attribute()
        {
            var invokedResult = Fn.Select(() => new { x = 1, y = 2 });
            Assert.AreEqual(new { x = 1, y = 2 }, invokedResult);
        }
        [TestMethod]
        public void Invoke_Calculated_Anonymous_Type()
        {
            var invokedResult = Fn.Select(() =>
                {
                    var x = 1;
                    var y = 2;
                    var result = x + y;
                    return new { x, y, result };
                });
            Assert.AreEqual(new { x = 1, y = 2, result = 3 }, invokedResult);
        }
    }
}
