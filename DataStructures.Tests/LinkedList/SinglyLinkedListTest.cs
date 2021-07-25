using NUnit.Framework;
using System;
using DataStructures.LinkedList.SinglyLinkedList;

namespace DataStructures.Tests.LinkedList
{
    [TestFixture()]
    public class SinglyLinkedListTest
    {
        [Test()]
        public static void LengthWorksCorrectly([Random(0, 1000, 100)] int quantity)
        {
            // Arrange
            SinglyLinkedList<int> testLinkedList = new();

            // Act
            var r = TestContext.CurrentContext.Random;
            for (var i = 0; i < quantity; i++)
            {
                _ = testLinkedList.InsertHead(r.Next());
            }

            // Assert
            Assert.AreEqual(quantity, testLinkedList.GetLength());
        }

        [Test()]
        public static void LengthOnEmptyIsZero()
        {
            // Arrange
            SinglyLinkedList<int> testLinkedList = new();

            // Act

            // Assert
            Assert.AreEqual(0, testLinkedList.GetLength());
        }

        [Test()]
        public static void GetItemsFromLinkedList()
        {
            // Arrange
            SinglyLinkedList<string> testLinkedList = new();
            testLinkedList.InsertTail("H");
            testLinkedList.InsertTail("E");
            testLinkedList.InsertTail("L");
            testLinkedList.InsertTail("L");
            testLinkedList.InsertTail("O");

            // Act

            // Assert
            Assert.AreEqual("L", testLinkedList.GetValueAtNode(3));
        }
    }
}
