using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessments
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

/*
UnitTest находится внутри проекта Test, немного непонятно. 
Выделить юнит тесты в отдельный проект.
В конструкторе класса тестлет нет никаких валидаций айтемов, сколько их какого типа и тд.
Метод рандомайз тоже готов работать с таким "неопределенным" списком aйтемов.
Эта валидация вынесена в тест а не сидит в классе.

сам алгоритм перемешивания кончено вопрос холиварный. непонятно зачем перемешивать 2 раза только чтобы получить 2 претест итема, и если завтра нужно будет взять 200 претест итемов то всё придётся полностью переписывать.
т.е. я бы предложил кандидату подумать над возможностью что завтра нас попросят изменить количество претест итемов в начале массива и описать алгоритм так чтобы мы могли сделать это изменение с минимальными усилиями.. (но опять же, не знаю, будет ли этот момент важен для заказчика)
 */
