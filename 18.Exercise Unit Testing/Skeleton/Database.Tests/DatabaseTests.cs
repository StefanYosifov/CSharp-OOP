namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            db = new Database();
        }


        public void Test_Constructor()
        {

        }


        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Constructor_Less_Than_16_Elements(int[] elemnetsToAdd)
        {
            Database database = new Database(elemnetsToAdd);
            int[] actualData = database.Fetch();
            int actualCount = actualData.Length;

            int expectedCount = elemnetsToAdd.Length;

            CollectionAssert.AreEqual(actualData, elemnetsToAdd);
            Assert.AreEqual(expectedCount, actualCount);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void Constructor_Must_Not_Allow_More_Than_16_Elements(int[] elemnetsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(elemnetsToAdd);
            });

        }

        [Test]
        public void Testing_Add_Functionality(int[] existingArray, int[] elementsToAdd)
        {
            int[] testData = new int[] { 1, 2, 3 };

            foreach (var element in elementsToAdd)
            {
                this.db.Add(element);
            }

            int[] actualData = this.db.Fetch();
            int actualDataCount = this.db.Count;

            Assert.AreEqual(actualDataCount, existingArray.Length);

        }

        [Test]
        public void Testing_Add_Over_17_Elements()
        {
            for (int i = 0; i < 16; i++)
            {
                this.db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(1);
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 })]
        public void RemoveShouldRemoveTheLastElement(int[] startElements)
        {
            foreach (var element in startElements)
            {
                this.db.Add(element);
            }
            this.db.Remove();

            List<int> elementList = new List<int>(startElements);

            int[] actualData = this.db.Fetch();
            elementList.RemoveAt(elementList.Count - 1);
            int[] expectedData = startElements.ToArray();

            int actualCount = this.db.Count;
            int expectedCount = elementList.Count;

            CollectionAssert.AreEqual(expectedData, actualData);
            Assert.That(actualCount.Equals(expectedCount));



        }

        [Test]
        public void RemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            List<int> testData = new List<int>() { 1, 2, 3, 4, 5 };
            foreach (var element in testData)
            {
                this.db.Add(element);
            }

            for (int i = 0; i < testData.Count; i++)
            {
                this.db.Remove();
            }


        }

        [Test]
        public void RemoveShouldThrowExceptionIf0Elements()
        {
            List<int> testData = new List<int> { };
            foreach (var element in testData)
            {
                this.db.Add(element);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();

            });

        }


        [TestCase(new int[]{ })]
        [TestCase(new int[] {1,2,3,4,5,6,7,})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void FetchShoudlReturnACopy(int[] startElements)
        {
            foreach(var element in startElements)
            {
                db.Add(element);
            }
            int[] actualResult = this.db.Fetch();
            int[] expectedResult = startElements;

            CollectionAssert.AreEqual(expectedResult, actualResult);

        }
    }
}
