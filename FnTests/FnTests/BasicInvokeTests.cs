using System;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class BasicInvokeTests
    {


        [TestMethod]
        public void Invoke_String()
        {
            var invokedResult = Fn.Invoke(() => "result");
            Assert.AreEqual("result", invokedResult);
        }
        [TestMethod]
        public void Invoke_Simple_Calculation()
        {
            var invokedResult = Fn.Invoke(() => 1 + 2);
            Assert.AreEqual(3, invokedResult);
        }
        [TestMethod]
        public void Invoke_Anonymous_Type()
        {
            var invokedResult = Fn.Invoke(() => new { x = 1, y = 2 });
            Assert.AreEqual(new { x = 1, y = 2 }, invokedResult);
        }
        [TestMethod]
        public void Invoke_Calculated_Anonymous_Type()
        {
            var invokedResult = Fn.Invoke(() =>
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
