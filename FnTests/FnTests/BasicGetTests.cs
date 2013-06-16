using System;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class BasicGetTests
    {


        [TestMethod]
        public void Invoke_String()
        {
            var invokedResult = Fn.Get(() => "result");
            Assert.AreEqual("result", invokedResult);
        }
        [TestMethod]
        public void Invoke_Simple_Calculation()
        {
            var invokedResult = Fn.Get(() => 1 + 2);
            Assert.AreEqual(3, invokedResult);
        }
        [TestMethod]
        public void Invoke_Anonymous_Type()
        {
            var invokedResult = Fn.Get(() => new { x = 1, y = 2 });
            Assert.AreEqual(new { x = 1, y = 2 }, invokedResult);
        }
        [TestMethod]
        public void Invoke_Calculated_Anonymous_Type()
        {
            var invokedResult = Fn.Get(() =>
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
