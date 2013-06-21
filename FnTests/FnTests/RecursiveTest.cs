using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FnX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FnTests
{
    [TestClass]
    public class RecursiveTest
    {
        [TestMethod]
        public void RecursiveActionTest()
        {
            var rootNode = getNode();
            var result = new StringBuilder();
            Fn.Y<Node>(recursiveAction => param => { result.Append(param.Name); foreach (var c in param.Children) recursiveAction(c); })(rootNode);
            Assert.AreEqual(@"rootbranch 11.11.21.3branch 22.12.22.3branch 33.13.23.3", result.ToString());

        }
        [TestMethod]
        public void RecursiveFunctionTest()
        {
            var rootNode = getNode();
            var f = Fn.Y<Node, string>(recursiveFunc => 
                param => 
                    param.Children.Aggregate(param.Name, (current, c) => 
                        current + recursiveFunc(c)));

            var result2 = f(rootNode);
            Assert.AreEqual("rootbranch 11.11.21.3branch 22.12.22.3branch 33.13.23.3", result2);
            
        }
        private Node getNode()
        {
            return new Node
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
