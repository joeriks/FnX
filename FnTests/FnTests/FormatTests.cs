using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnTests
{
    [TestClass]
    public class FormatTests
    {
        //[TestMethod]
        //public void Should_Format_Basic()
        //{
        //    var obj = new { header = "Some header", text = "Lorem ipsum" };
        //    var tmpl = new { header = "<h1>{0}</h1>", text = "<div>{0}</div>" };

        //    var result = FnX.MapFormat(obj, tmpl);

        //}

        [TestMethod]
        public void Should_Format_Inference_Basic()
        {
            var obj = new { header = "Some header", text = "Lorem ipsum" };

            var rsult = string.Concat(
                string.Format("<h1>{0}</h1>", obj.header),
                string.Format("<div>{0}</div>", obj.text)
            );

            Assert.AreEqual(rsult, "<h1>Some header</h1><div>Lorem ipsum</div>");

        }

        public Func<T, string> fmt<T>(string tag)
        {
            return new Func<T, string>(s =>
            {
                return string.Format("<{0}>{1}</{0}>", tag, s);
            });
        }

        [TestMethod]
        public void NicerFormatTests()
        {
            var obj = new { header = "Some header", text = "Lorem ipsum", footer = "end." };

            var header = fmt<string>("h1");
            var div = fmt<string>("div");

            var section = new Func<string, string, string, string>((h, t, f) =>
            {
                return string.Concat(
                    header(h),
                    div(t),
                    div(f)
                );
            });


            var rsult = section(obj.header, obj.text, obj.footer);

            Assert.AreEqual(rsult, "<h1>Some header</h1><div>Lorem ipsum</div><div>end.</div>");

        }

        public Func<T, string> composed<T>(T defaultValues, Func<T, string> composer)
        {
            return composer;
        }

        [TestMethod]
        public void ComposedFormatTests()
        {
            var obj = new { header = "Some header", text = "Lorem ipsum", footer = "end." };

            var header = fmt<string>("h1");
            var div = fmt<string>("div");

            var section = composed(new {header="",text="",footer=""}, c =>
            {
                return string.Concat(
                    header(c.header),
                    div(c.text),
                    div(c.footer)
                );
            });

            var page = string.Concat(
                section(obj),
                section(new {header = "head", text = "body", footer = "foot"})
            );

            var rsult = section(obj);

            Assert.AreEqual(page, "<h1>Some header</h1><div>Lorem ipsum</div><div>end.</div><h1>head</h1><div>body</div><div>foot</div>");

        }

        //protected delegate string fmtxD<T>(T obj, params Func<T, string>[] select);

        //public fmtxD<T> fmtx<T>(T obj)
        //{

        //    // create a function that takes a object
        //    // and 

        //    return null;
        //}

        

        //[TestMethod]
        //public void EvenNicerFormatTests()
        //{
        //    var obj = new { header = "Some header", text = "Lorem ipsum", footer = "end." };

        //    var fmtt = fmtx(
        //        new {
        //            header=fmt<string>("h1"), 
        //            text=fmt<string>("div"),
        //            footer=fmt<string>("p")
        //        });

        //    var rsult = fmtt(obj,
        //        _ => _.header(obj.header), 
        //        _ => _.text(obj.text), 
        //        _ => _.footer(obj.footer));

        //    Assert.AreEqual(rsult, "<h1>Some header</h1><div>Lorem ipsum</div><div>end.</div>");

        //}
    }
}
