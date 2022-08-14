using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessments
{
    public class Testlet
    {
        private const int COUNT_ITEMS = 10;
        private const int COUNT_PRETEST_ITEMS = 4;
        private const int COUNT_OPERATIONAL_ITEMS = 6;

        public string TestletId;
        private List<Item> Items;

        public Testlet(string testletId, List<Item> items)
        {
            if (items.Count != COUNT_ITEMS)
            {
                throw new ArgumentOutOfRangeException("items", $"[Items] should contain strict {COUNT_ITEMS} rows");
            }

            if (!items.All(x => x is Item))
            {
                throw new ArgumentException("items", "[Items] should be type of [Item]");
            }

            if (items.Count(x => x.ItemType == ItemTypeEnum.Pretest) != COUNT_PRETEST_ITEMS ||
                items.Count(x => x.ItemType == ItemTypeEnum.Operational) != COUNT_OPERATIONAL_ITEMS)
            {
                throw new ArgumentException("items", $"[Items] should contain {COUNT_PRETEST_ITEMS} [Pretest] and {COUNT_OPERATIONAL_ITEMS} [Operational] rows");
            }

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

/*
����� ��������� ���� ����� �������� � ����� "��������������" ������� a������.
��� ��������� �������� � ���� � �� ����� � ������.

��� �������� ������������� ������� ������ ����������. ��������� ����� ������������ 2 ���� ������ ����� �������� 2 ������� �����, � ���� ������ ����� ����� ����� 200 ������� ������ �� �� ������� ��������� ������������.
�.�. � �� ��������� ��������� �������� ��� ������������ ��� ������ ��� �������� �������� ���������� ������� ������ � ������ ������� � ������� �������� ��� ����� �� ����� ������� ��� ��������� � ������������ ��������.. (�� ����� ��, �� ����, ����� �� ���� ������ ����� ��� ���������)
 */
