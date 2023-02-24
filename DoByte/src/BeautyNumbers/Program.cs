using System;

namespace BeautyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ushort luckyBusTicketsNumber = 55252;               //Число счастливых билетов (6 цифр, 10-чная система счисления)
            ulong beautyNumbersCount = 9203637295151;           //Число красивых чисел (13 цифр, 13-чная система счисления)
            ulong result;

            //Тесты
            result = GetLuckyTicketsCount(1, 2); Console.WriteLine($"Result = {result}, should be: {2}, {result == 2}");
            result = GetLuckyTicketsCount(2, 2); Console.WriteLine($"Result = {result}, should be: {6}, {result == 6}");

            result = GetLuckyTicketsCount(1, 3); Console.WriteLine($"Result = {result}, should be: {3}, {result == 3}");

            result = GetLuckyTicketsCount(1, 10); Console.WriteLine($"Result = {result}, should be: {10}, {result == 10}");
            result = GetLuckyTicketsCount(3, 10); Console.WriteLine($"Result = {result}, should be: {luckyBusTicketsNumber}, {result == luckyBusTicketsNumber}");

            result = GetBeautyNumbersCount(); Console.WriteLine($"Result = {result}, should be: {beautyNumbersCount}, {result == beautyNumbersCount}");

            //Результат
            Console.WriteLine(result);
        }

        /// <summary>
        /// В данной задаче будут рассматриваться 13-ти значные числа в тринадцатиричной системе
        /// исчисления(цифры 0,1,2,3,4,5,6,7,8,9,A,B,C) с ведущими нулями.
        /// Например, ABA98859978C0, 6789110551234, 0000007000000
        /// Назовем число красивым, если сумма его первых шести цифр равна сумме шести последних цифр.
        /// 
        /// Пример:
        /// Число 0055237050A00 - красивое, так как 0+0+5+5+2+3 = 0+5+0+A+0+0
        /// Число 1234AB988BABA - некрасивое, так как 1+2+3+4+A+B != 8+8+B+A+B+A​
        /// 
        /// Задача:
        /// написать программу на С# печатающую в стандартный вывод количество 13-ти значных красивых чисел с
        /// ведущими нулями в тринадцатиричной системе исчисления.
        /// 
        /// В качестве решения должен быть предоставлено:
        /// 1) ответ - количество таких чисел.Ответ должен быть представлен в десятичной системе исчисления.
        /// 2) исходный код программы.
        /// Пож-та, кроме кода, напишите ответ числом в теле письма.
        /// </summary>
        /// <returns>количество 13-ти значных красивых чисел с ведущими нулями в 13-ричной системе исчисления</returns>
        static ulong GetBeautyNumbersCount()
        {
            int n = 6;
            int m = 13;

            ulong count = (ulong)m * GetLuckyTicketsCount(n, m);

            return count;
        }

        /// <summary>
        /// Получение числа счастливых билетов
        /// https://ru.wikipedia.org/wiki/Счастливый_билет
        /// http://ega-math.narod.ru/Quant/Tickets.htm
        /// https://ru.stackoverflow.com/questions/1354392/Посчитать-количество-красивых-чисел
        /// 
        /// Общее число шестизначных номеров, порождающих счастливые билеты, равно 55251
        /// (55252, если учитывать билет с номером 000000), то есть в среднем примерно один билет 
        /// из восемнадцати является счастливым (5,5252%). 
        /// </summary>
        /// <param name="n">Длина половины цифры (для 6-значных автобусных билетов n=3)</param>
        /// <param name="m">Система счисления (для десятичной системы m=10)</param>
        /// <returns>Число счастливых билетов (сумма первых N цифр совпадает с суммой N последних.</returns>
        static ulong GetLuckyTicketsCount(int n, int m)
        {
            ulong count;

            count = (ulong)Math.Round(GetIntegral(n, m) / Math.PI);

            return count;
        }

        //************** Вычисление интеграла (лучше использовать библиотеку для этого) **************

        /// <summary>
        /// Интегральная функция подсчета: https://ru.wikipedia.org/wiki/Счастливый_билет#Явные_формулы
        /// </summary>
        /// <param name="x">Аргумент функции</param>
        /// <param name="n">Длина половины цифры (для 6-значных автобусных билетов n=3)</param>
        /// <param name="m">Система счисления (для десятичной системы m=10)</param>
        /// <returns>Значение функции</returns>
        static double Y(double x, int n, int m)
        {
            return Math.Pow(Math.Sin(m * x) / Math.Sin(x), 2 * n);
        }

        /// <summary>
        /// Подсчет интеграла
        /// https://pyatnitsev.ru/2011/12/20/simpson_cs/
        /// </summary>
        /// <param name="n">Длина половины цифры (для 6-значных автобусных билетов n=3)</param>
        /// <param name="m">Система счисления (для десятичной системы m=10)</param>
        /// <returns>Значение интеграла (приблизительное, точность зависит от числа [parts])</returns>
        static double GetIntegral(int n, int m)
        {
            double x;               //Значение аргумента [X] в интегральной функции
            double a = -Math.PI / 2;//Отрезок интегрирования [a,b] —> (a)
            double b =  Math.PI / 2;//Отрезок интегрирования [a,b] —> (b)
            double h;               //Ширина отрезка, на который поделили функцию (шаг подсчета)
            double s;               //Результат - сумма площадей трапеций в каждом отрезке
            int parts = 1000;       //На сколько частей нужно разделить отрезок - можно увеличить точность, но и так ОК

            //HACK: в оригинальной формуле пределы интегрирования [a,b] = [0, Math.PI], но Math.Sin(0) = 0 и код падает,
            //т.к. деление на ноль, поэтому изменил пределы интегрирования на [-Math.PI / 2, Math.PI / 2]

            h = (b - a) / parts;
            s = 0; x = a + h;

            while (x < b)
            {
                s = s + 4 * Y(x, n, m);
                x = x + h;
                s = s + 2 * Y(x, n, m);
                x = x + h;
            }
            s = h / 3 * (s + Y(a, n, m) - Y(b, n, m));

            return s;
        }
    }
}
