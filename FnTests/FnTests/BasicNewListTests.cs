using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FnTests
{
    [TestClass]
    public class BasicNewListTests
    {
        [TestMethod]
        public void Should_Create_List_Based_On_CreatedType()
        {
            var type = Fn.Func((string name, string value) => new { name, value });
            var list = Fn.NewList(type);
            list.Add(type("one", "two"));
            list.Add(type("three", "four"));

            var countItems = list.Count;
            Assert.AreEqual(2, countItems);

            Assert.AreEqual(new { name = "one", value = "two" }, list[0]);
            Assert.AreEqual(new { name = "three", value = "four" }, list[1]);


        }
        [TestMethod]
        public void Should_Be_Able_To_Filter_A_List()
        {
            var type = Fn.Func((string name, string value) => new { name, value });
            var list = Fn.NewList(type);
            list.Add(type("one", "two"));
            list.Add(type("three", "four"));
            list.Add(type("three", "four"));

            var filteredList = list.Where(t => t.name == "three").ToList();
            var countItems = filteredList.Count;

            Assert.AreEqual(2, countItems);

            Assert.AreEqual(new { name = "three", value = "four" }, filteredList[0]);
            Assert.AreEqual(new { name = "three", value = "four" }, filteredList[1]);


        }
    }
}
