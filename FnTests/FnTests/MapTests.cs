﻿using System;
using System.Collections.Generic;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void ReturnWhatever()
        {
            var x = new DateTime(2012, 1, 1);
            var y = x.Map(self => new { self.Day });
            Assert.AreEqual(1, y.Day);
        }
        [TestMethod]
        public void AttribSelector()
        {
            var currentName = "Bar";
            var attribSelector = Fn.Func((Foo self) => self.Name == currentName ? "selected='selected'" : "");

            var x = new Foo { Id = 123, Name = "Bar" };
            var y = new Foo { Id = 123, Name = "Somethingelse" };

            var attrib = x.Map(attribSelector);
            Assert.AreEqual(attrib, "selected='selected'");

            var attriby = y.Map(attribSelector);
            Assert.AreEqual(attriby, "");


        }
        [TestMethod]
        public void RequestTest()
        {
            var Request = new Dictionary<string, object> { { "id", 1 }, { "foo", "bar" } };

            var request = Request.Map(self => new
                {
                    id = self["id"] ?? 0,
                    foo = self["foo"] ?? ""
                });

            Assert.AreEqual(1, request.id);
            Assert.AreEqual("bar", request.foo);

        }
        [TestMethod]
        public void RequestTestNulls()
        {
            var Request = new Dictionary<string, object> { { "id", 12 }, { "foo", null } };

            var request = Request.Map(self => new
            {
                id = self["id"] ?? 0,
                foo = self["foo"] ?? ""
            });

            Assert.AreEqual(12, request.id);
            Assert.AreEqual("", request.foo);

        }
        [TestMethod]
        public void MapToSomething()
        {
            var x = new Foo { Id = 123, Name = "Bar" };
            var y = x.Map(self => new Bar { Id = self.Id, Name = self.Name });
            Assert.AreEqual("Bar", y.Name);
        }
        [TestMethod]
        public void MapWithMapperSomething()
        {
            var foo = new Foo { Id = 123, Name = "Bar" };
            var mapFooToBar = Fn.Func((Foo self) => new Bar { Id = self.Id, Name = self.Name });
            var bar = foo.Map(mapFooToBar);
            Assert.AreEqual("Bar", bar.Name);
        }

        [TestMethod]
        public void MapWithDictionary()
        {
            var dict = new Dictionary<string, object> { { "Id", null }, { "Foo", "Bar" } };
            var bar = dict.Map(self =>
                {
                    var dictMapper = Fn.Func((string name) => self[name] ?? "");
                    return new
                    {
                        Id = dictMapper("Id"),
                        Foo = dictMapper("Foo")
                    };
                });
            Assert.AreEqual("", bar.Id);
            Assert.AreEqual("Bar", bar.Foo);
        }


        [TestMethod]
        public void MapToAnonymous()
        {
            var x = new Foo { Id = 123, Name = "Bar" };
            var y = x.Map(self => new { self.Name, self.Id });
            Assert.AreEqual("Bar", y.Name);
        }
        [TestMethod]
        public void NoSelf()
        {
            var y = this.Map(() => new { x = 1, y = 2 });
            Assert.AreEqual(1, y.x);
        }

        [TestMethod]
        public void MapMapMap()
        {
            var a = new { x = 5, y = 10 }
                .Map(_ => new { z = _.x * _.y })
                .Map(_ => new { q = _.z / 2 })
                .Map(_ => _.q);

            Assert.AreEqual(25, a);
        }
    }

    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}