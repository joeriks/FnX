using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class SelectIfTests
    {
        [TestMethod]
        public void SelectIfTestWithContinueProperty()
        {
            var indata = new { name = "some" };

            var validate = Fn.Func(() => true);
            var update = Fn.Func(() => false);
            var send = Fn.Func(() => true);

            var complete = indata
                .Select(validate)
                .SelectIf(update)
                .SelectIf(send);

            Assert.IsFalse(complete);

        }

        [TestMethod]
        public void SelectIf_ContinueOnNoHits()
        {

            var increaseTriesAndReturnEmpty = Fn.Func(() =>
            {
                return new List<string>();
            });

            var increaseTriesAndReturnNull = Fn.Func(() =>
            {
                return default(List<string>);
            });

            var increaseTriesAndReturn = Fn.Func((string returnvalue) =>
            {
                return Fn.Func(() => new List<string>() { returnvalue });
            });

            var isEmpty = Fn.Func((List<string> self) => !self.Any());

            var result = Fn.Select(increaseTriesAndReturnEmpty) //1
                        .SelectIf(isEmpty, increaseTriesAndReturnEmpty) //2
                        .SelectIf(isEmpty, increaseTriesAndReturn("yes")) //3
                        .SelectIf(isEmpty, increaseTriesAndReturn("no")) //4
                        .SelectIf(isEmpty, increaseTriesAndReturn("no")); //5

            Assert.AreEqual("yes", result[0]);

            var isNotNull = Fn.Func((List<string> self) => self == null || !self.Any());

            var result2 = Fn.Select(increaseTriesAndReturnNull) // null 1
            .SelectIf(isNotNull, increaseTriesAndReturnEmpty) //2
            .SelectIf(isNotNull, increaseTriesAndReturn("yes")) //3
            .SelectIf(isNotNull, increaseTriesAndReturn("no")) //4
            .SelectIf(isNotNull, increaseTriesAndReturn("no")); //5

            Assert.AreEqual("yes", result2[0]);


            var result3 = Fn.Select(increaseTriesAndReturnNull) // null 1
            .SelectIfEmpty(increaseTriesAndReturnNull) //2
            .SelectIfEmpty(increaseTriesAndReturnEmpty) //3
            .SelectIfEmpty(increaseTriesAndReturn("yes")) //4
            .SelectIfEmpty(increaseTriesAndReturn("no")); //5

            Assert.AreEqual("yes", result3.ToArray()[0]);


            var result4 = Fn.Select(increaseTriesAndReturnNull) // null 1
            .SelectIfEmpty(increaseTriesAndReturnNull) //2
            .SelectIfEmpty(increaseTriesAndReturnEmpty) //3
            .SelectIfEmptyAnd(self => false, increaseTriesAndReturn("no")) //4
            .SelectIfEmpty(increaseTriesAndReturn("yes")); //5

            Assert.AreEqual("yes", result4.ToArray()[0]);


        }

        [TestMethod]
        public void SelectIf_With_Anonymous_Type()
        {

            var foo = new { name = "Foo" };
            var bar = new { name = "Bar" };

            var isFoo = Fn.FuncFromAnonymous(new { name = "" }, self => self.name == "Foo");

            var result1 = foo.Select(isFoo);
            var result2 = bar.Select(isFoo);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);

        }

        [TestMethod]
        public void SelectIfBasicTest()
        {
            var indata = 1;

            var x = Fn.Select(() => indata > 0)
                .SelectIf(() => indata < 2)
                .SelectIf(() => indata != 1)
                .SelectIf(() => { throw new Exception("Will never execute"); });

            Assert.IsFalse(x);

        }
        [TestMethod]
        public void SelectIfBasicTestRegularSyntax()
        {
            var indata = 1;

            var x = (indata > 0) &&
                    (indata < 2) &&
                    (indata != 1) &&
                    new Func<bool>(() => { throw new Exception("Will never execute"); })();

            Assert.IsFalse(x);

        }

        [TestMethod]
        public void SelectIfTestWithChangingIntegerValue()
        {
            var indata = 1;

            var condition = Fn.Func((int i) => (i < 2));

            var x = indata.Select(self => self + 1)
                .SelectIf(condition, self => self + 1)
                .SelectIf(condition, self => self + 1);

            Assert.AreEqual(2, x);

        }


    }
}
