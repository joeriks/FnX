using System;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class BasicActionTests
    {
        [TestMethod]
        public void Create_Return_String()
        {
            var foo = "foo";
            var bar = "";
            foo.Action(f =>
            {
                bar = f;
            });
            Assert.AreEqual(foo,bar);

            

        }


        
    
    }
}
