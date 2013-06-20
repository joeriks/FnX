using System;
using System.Collections.Generic;
using System.Text;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class RecursiveTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var rootNode = new Node
                {
                    Name = "root",
                    Children = new List<Node>()
                        {
                            new Node
                                {
                                    Name = "branch 1",
                                    Children = new List<Node>
                                        {
                                            new Node
                                                {
                                                    Name = "1.1"
                                                },
                                            new Node
                                                {
                                                    Name = "1.2"
                                                },
                                            new Node
                                                {
                                                    Name = "1.3"
                                                }
                                        }
                                },
                            new Node
                                {
                                    Name = "branch 2",
                                    Children = new List<Node>
                                        {
                                            new Node
                                                {
                                                    Name = "2.1"
                                                },
                                            new Node
                                                {
                                                    Name = "2.2"
                                                },
                                            new Node
                                                {
                                                    Name = "2.3"
                                                }
                                        }
                                },
                            new Node
                                {
                                    Name = "branch 3",
                                    Children = new List<Node>
                                        {
                                            new Node
                                                {
                                                    Name = "3.1"
                                                },
                                            new Node
                                                {
                                                    Name = "3.2"
                                                },
                                            new Node
                                                {
                                                    Name = "3.3"
                                                }
                                        }
                                }

                        }
                };
            var result = new StringBuilder();
            Fn.Y<Node>(p => s => { result.AppendLine(s.Name); foreach (var c in s.Children) p(c); })(rootNode);
            Assert.AreEqual(@"root
branch 1
1.1
1.2
1.3
branch 2
2.1
2.2
2.3
branch 3
3.1
3.2
3.3
", result.ToString());

            var f = Fn.Y<Node, string>(p => s =>
                {
                    var x = s.Name;
                    foreach (var c in s.Children) x = x + p(c);
                    return x;
                });

            var result2 = f(rootNode);
            Assert.AreEqual("rootbranch 11.11.21.3branch 22.12.22.3branch 33.13.23.3", result2);

        }
    }
    
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Children { get; set; }
        public Node()
        {
            Children = new List<Node>();
        }
    }
}
