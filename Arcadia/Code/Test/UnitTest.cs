using Assessments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        List<Item> items;
        List<Item> itemsRandomized;
        Testlet testlet;

        public UnitTest() {
            items = new List<Item>();
            items.Add(new Item() { ItemId = "0", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "1", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "2", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "3", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "4", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "5", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "6", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "7", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "8", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "9", ItemType = ItemTypeEnum.Operational });

            testlet = new Testlet("1", items);
            itemsRandomized = testlet.Randomize();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "[Items] should contain strict 10 rows")]
        public void TestLetContainsStrict10Items()
        {
            new Testlet("1", new List<Item>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "[Items] should be type of [Item]")]
        public void TestLetContainsItemsWithCorrectType()
        {
            var newItems = new List<Item>(items.Take(items.Count - 1));
            newItems.Add(null);
            new Testlet("1", newItems);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "[Items] should contain 4 [Pretest] and 6 [Operational] rows")]
        public void TestLetContains4Pretestand6OperationalItems()
        {
            var newItems = new List<Item>(items);
            newItems.ForEach(x => x.ItemType = ItemTypeEnum.Pretest);
            new Testlet("1", newItems);
        }

        [TestMethod]
        public void ResultNotNull()
        {
            Assert.IsNotNull(itemsRandomized);
        }

        [TestMethod]
        public void ResultSameLength()
        {
            Assert.AreEqual(items.Count, itemsRandomized.Count);
        }

        [TestMethod]
        public void FirstTwoItemsArePretest()
        {
            Assert.AreEqual(ItemTypeEnum.Pretest, itemsRandomized[0].ItemType);
            Assert.AreEqual(ItemTypeEnum.Pretest, itemsRandomized[1].ItemType);
            Assert.AreNotEqual(itemsRandomized[0].ItemId, itemsRandomized[1].ItemId);
        }

        [TestMethod]
        public void ResultNotEqualsToOriginal()
        {
            Assert.AreNotEqual(
                string.Join("", items.Select(x => x.ItemId)),
                string.Join("", itemsRandomized.Select(x => x.ItemId)));
        }

        [TestMethod]
        public void RandomizeLeaveSameItems()
        {
            Assert.AreEqual(items.Sum(x => int.Parse(x.ItemId)), itemsRandomized.Sum(x => int.Parse(x.ItemId)));
        }
    }
}
