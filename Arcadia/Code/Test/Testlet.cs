using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Testlet
    {
        public string TestletId;
        private List<Item> Items;
        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }
        public List<Item> Randomize()
        {
            var rnd = new Random();
            var result = new Item[Items.Count];

            var firstPretestItem =
                Items.OrderBy(x => rnd.Next())
                .Where(x => x.ItemType == ItemTypeEnum.Pretest)
                .First();

            var secondPretestItem =
                Items.OrderBy(x => rnd.Next())
                .Where(x => x.ItemType == ItemTypeEnum.Pretest && x.ItemId != firstPretestItem.ItemId)
                .First();

            result[0] = firstPretestItem;
            result[1] = secondPretestItem;

            Items.OrderBy(x => rnd.Next())
                .Where(x => x.ItemId != firstPretestItem.ItemId && x.ItemId != secondPretestItem.ItemId)
                .ToList()
                .CopyTo(0, result, 2, Items.Count - 2);

            return result.ToList();
        }
    }

    public class Item
    {
        public string ItemId;
        public ItemTypeEnum ItemType;
    }

    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}
