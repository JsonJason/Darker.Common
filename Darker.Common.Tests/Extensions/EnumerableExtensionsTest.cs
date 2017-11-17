using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Darker.Test
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [TestFixture]
        public class ToDisplayString
        {
            [Test]
            [TestCaseSource(nameof(_expectedPrintOutputCases))]
            public void ExpectedPrintOutput(List<object> items, string expectedOutput)
            {
                var output = items.ToDisplayString();
                Assert.AreEqual(expectedOutput, output);
            }

            private static object[] _expectedPrintOutputCases =
            {
                new object[] {new List<object> {1, 2, 3, 4}, "[1, 2, 3, 4]"},
                new object[]
                    {new List<object> {"Jason", "Tom", "Mary", "Carl", "Lenny"}, "[Jason, Tom, Mary, Carl, Lenny]"},
                new object[] {new List<object> {"Dave"}, "[Dave]"},
                new object[] {new List<object> {"Sarah", "Jenny"}, "[Sarah, Jenny]"},
                new object[] {new List<object>(), "[]"}
            };

            [Test]
            public void Null_Object_Does_Not_Throw()
            {
                List<object> list = null;

                Assert.DoesNotThrow(() =>
                {
                    var output = list.ToDisplayString();
                    Assert.AreEqual("null", output);
                });
            }

            [Test]
            public void Empty_List_Shows_Empty_Brackets()
            {
                var list = new List<object>();

                var output = list.ToDisplayString();
                Assert.AreEqual("[]", output);
            }
        }

        [TestFixture]
        public class AllElementsAreUnique
        {
            [Test]
            public void NullEnumerable_Throws_NullArgument()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {    
                  ((List<object>)null).AllElementsAreUnique();
                });
            }

            [Test]
            [TestCaseSource(nameof(_expectedDistinctOutputCases))]
            public void When_All_Distinct_Return_True(List<object> items)
            {
                Assert.IsTrue(items.AllElementsAreUnique(), items.ToDisplayString());
            }


            private static object[] _expectedDistinctOutputCases =
            {
                new List<object> {1, 2, 3, 4},
                new List<object> {"Jason", "Tom", "Mary", "Carl", "Lenny"},
                new List<object> {"Dave"},
                new List<object> {"Sarah", "Jenny"},
                new List<object>()
            };

            [Test]
            [TestCaseSource(nameof(_expectedNotDistinctOutputCases))]
            public void When_All_Distinct_Return_False(List<object> items)
            {
                Assert.IsFalse(items.AllElementsAreUnique(), items.ToDisplayString());
            }

            private static object[] _expectedNotDistinctOutputCases =
            {
                new List<object> {1, 2, 3, 4,3},
                new List<object> {"Jason", "Tom", "Tom", "Mary", "Carl", "Lenny"},
                new List<object> {"Dave","Dave","Dave"},
                new List<object> {"Sarah", "Jenny","Sarah"}
            };
        }

        [TestFixture]
        public class FilterByType
        {
            [Test]
            [TestCaseSource(nameof(_expectedFilterByCases))]
            public void Filter_Returns_Correct_Count(List<object> items,Type type,int amount)
            {
                var matching = items.FilterByType(type).ToList();

                Assert.AreEqual(amount,matching.Count);
            }

            private static object[] _expectedFilterByCases =
            {
                new object[]
                {
                    new List<object> { "Jason", "Tom",1, 2, 3, 4}, typeof(string),2
                },
                new object[]
                {
                    new List<object> { "Jason", "Tom",1, 2, 3, 4}, typeof(int),4
                },
                new object[]
                {
                    new List<object>(),typeof(int),0 
                }
            };
        }

        [TestFixture]
        public class FilterByTypeGeneric
        {

            [Test]
            public void List_with_3_Ints_Filtering_Ints_returns_Three()
            {
                var items = new List<object> {"Jason", "Tom", 1, 2, 3};
                var ints = items.FilterByType<object,int>();

                Assert.AreEqual(3,ints.Count());
            }

            [Test]
            public void List_with_2_Strings_Filtering_Ints_returns_Two()
            {
                var items = new List<object> { "Jason", "Tom", 1, 2, 3 };
                var ints = items.FilterByType<object, string>();

                Assert.AreEqual(2, ints.Count());
            }

        }

        [TestFixture]
        public class MaxBy
        {

            [Test]
            public void Max_By_Name_Returns_Latest_Alphabet_Letter()
            {
                var items = GetTestData();

                var chosen = items.MaxBy(x => x.Name);

                Assert.AreEqual("Tom", chosen.Name);
            }

            [Test]
            public void Max_By_Age_Returns_Highest_Number()
            {
                var items = GetTestData();

                var chosen = items.MaxBy(x => x.Age);

                Assert.AreEqual(41, chosen.Age);
            }


            List<SortTester> GetTestData()
            {
                return new List<SortTester>
                {
                    new SortTester { Name = "Tom", Age = 23 },
                    new SortTester { Name = "Mary", Age = 31 },
                    new SortTester { Name = "Max", Age = 30 },
                    new SortTester { Name = "Sarah", Age = 24 },
                    new SortTester { Name = "Gavin", Age = 17 },
                    new SortTester { Name = "Lenny", Age = 35 },
                    new SortTester { Name = "Olaf", Age = 41 },
                    new SortTester { Name = "James", Age = 8 },
                    new SortTester { Name = "Elenor", Age = 26 }
                };
            }
        }

        [TestFixture]
        public class MinBy
        {

            [Test]
            public void Min_By_Name_Returns_Earliest_Alphabet_Letter()
            {
                var items = GetTestData();

                var chosen = items.MinBy(x => x.Name);

                Assert.AreEqual("Elenor", chosen.Name);
            }

            [Test]
            public void Max_By_Age_Returns_Highest_Number()
            {
                var items = GetTestData();

                var chosen = items.MinBy(x => x.Age);

                Assert.AreEqual(8, chosen.Age);
            }


            List<SortTester> GetTestData()
            {
                return new List<SortTester>
                {
                    new SortTester { Name = "Tom", Age = 23 },
                    new SortTester { Name = "Mary", Age = 31 },
                    new SortTester { Name = "Max", Age = 30 },
                    new SortTester { Name = "Sarah", Age = 24 },
                    new SortTester { Name = "Gavin", Age = 17 },
                    new SortTester { Name = "Lenny", Age = 35 },
                    new SortTester { Name = "Olaf", Age = 41 },
                    new SortTester { Name = "James", Age = 8 },
                    new SortTester { Name = "Elenor", Age = 26 }
                };
            }
        }


        public class SortTester
        {
            public string Name;
            public int Age;
        }

    }
}