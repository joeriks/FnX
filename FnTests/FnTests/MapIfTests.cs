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
    public class MapIfTests
    {
        [TestMethod]
        public void SelectIfTestWithContinueProperty()
        {
            var indata = new { name = "some" };

            var validate = Fn.Func(() => true);
            var update = Fn.Func(() => false);
            var send = Fn.Func(() => true);

            var complete = indata
                .Map(validate)
                .MapIf(update)
                .MapIf(send);

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

            var result = Fn.Map(increaseTriesAndReturnEmpty) //1
                        .MapIf(isEmpty, increaseTriesAndReturnEmpty) //2
                        .MapIf(isEmpty, increaseTriesAndReturn("yes")) //3
                        .MapIf(isEmpty, increaseTriesAndReturn("no")) //4
                        .MapIf(isEmpty, increaseTriesAndReturn("no")); //5

            Assert.AreEqual("yes", result[0]);

            var isNotNull = Fn.Func((List<string> self) => self == null || !self.Any());

            var result2 = Fn.Map(increaseTriesAndReturnNull) // null 1
            .MapIf(isNotNull, increaseTriesAndReturnEmpty) //2
            .MapIf(isNotNull, increaseTriesAndReturn("yes")) //3
            .MapIf(isNotNull, increaseTriesAndReturn("no")) //4
            .MapIf(isNotNull, increaseTriesAndReturn("no")); //5

            Assert.AreEqual("yes", result2[0]);


            var result3 = Fn.Map(increaseTriesAndReturnNull) // null 1
            .MapIfEmpty(increaseTriesAndReturnNull) //2
            .MapIfEmpty(increaseTriesAndReturnEmpty) //3
            .MapIfEmpty(increaseTriesAndReturn("yes")) //4
            .MapIfEmpty(increaseTriesAndReturn("no")); //5

            Assert.AreEqual("yes", result3.ToArray()[0]);


            var result4 = Fn.Map(increaseTriesAndReturnNull) // null 1
            .MapIfEmpty(increaseTriesAndReturnNull) //2
            .MapIfEmpty(increaseTriesAndReturnEmpty) //3
            .MapIfEmptyAnd(self => false, increaseTriesAndReturn("no")) //4
            .MapIfEmpty(increaseTriesAndReturn("yes")); //5

            Assert.AreEqual("yes", result4.ToArray()[0]);


        }

        [TestMethod]
        public void SelectIf_With_Anonymous_Type()
        {

            var foo = new { name = "Foo" };
            var bar = new { name = "Bar" };

            var isFoo = Fn.FuncFromAnonymous(new { name = "" }, self => self.name == "Foo");

            var result1 = foo.Map(isFoo);
            var result2 = bar.Map(isFoo);

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);

        }

        [TestMethod]
        public void SelectIfBasicTest()
        {
            var indata = 1;

            var x = Fn.Map(() => indata > 0)
                .MapIf(() => indata < 2)
                .MapIf(() => indata != 1)
                .MapIf(() => { throw new Exception("Will never execute"); });

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

            var x = indata.Map(self => self + 1)
                .MapIf(condition, self => self + 1)
                .MapIf(condition, self => self + 1);

            Assert.AreEqual(2, x);

        }


    }
}
