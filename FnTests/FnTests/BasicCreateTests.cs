using System;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class BasicCreateTests
    {
        [TestMethod]
        public void Create_Return_String()
        {
            var result = Fn.Func(() => "result");
            Assert.IsTrue(result is Func<string>);

            var invokedResult = result();
            Assert.AreEqual("result", invokedResult);
        }
        [TestMethod]
        public void Create_One_Parameter_Return_String()
        {
            var result = Fn.Func((string indata) => indata);
            Assert.IsTrue(result is Func<string, string>);

            var invokedResult = result("result");
            Assert.AreEqual("result", invokedResult);
        }

        [TestMethod]
        public void Create_Two_Parameters_Return_String()
        {
            var result = Fn.Func((string indata1, string indata2) => indata1 + indata2);
            Assert.IsTrue(result is Func<string, string, string>);

            var invokedResult = result("re", "sult");
            Assert.AreEqual("result", invokedResult);
        }
        [TestMethod]
        public void Create_Three_Parameters_Return_String()
        {
            var result = Fn.Func((string indata1, string indata2, string indata3) => indata1 + indata2 + indata3);
            Assert.IsTrue(result is Func<string, string, string, string>);

            var invokedResult = result.Invoke("re", "su", "lt");
            Assert.AreEqual("result", invokedResult);
        }
        [TestMethod]
        public void Create_Four_Parameters_Return_String()
        {
            var result = Fn.Func((string indata1, string indata2, string indata3, string indata4) => indata1 + indata2 + indata3 + indata4);
            Assert.IsTrue(result is Func<string, string, string, string, string>);

            var invokedResult = result.Invoke("re", "su", "l", "t");
            Assert.AreEqual("result", invokedResult);
        }
        [TestMethod]
        public void FuncOnObject()
        {
            var some = "SomeString";
            var fn = some.Func(self => new { self, upper = self.ToUpper() });

            var invokedResult = fn();

            Assert.AreEqual("SOMESTRING", invokedResult.upper);
        }
        [TestMethod]
        public void FuncOnObjectNoSelft()
        {

            var fn = this.Func(() => new { x=1,y=2});

            var invokedResult = fn();

            Assert.AreEqual(1, invokedResult.x);
        }
    }
}
