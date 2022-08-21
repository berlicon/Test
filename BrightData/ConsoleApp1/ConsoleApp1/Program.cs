using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            //int a = 5;
            //object o = a;
            //var x = (long)o;
            //Console.Write(x.GetType().Name);
            //Unhandled exception. System.InvalidCastException: Unable to cast object of type 'System.Int32' to type 'System.Int64'.
            //at ConsoleApp1.Program.Main(String[] args) in C: \Users\berli_kh\Desktop\BrightData\ConsoleApp1\ConsoleApp1\Program.cs:line 14

            //var str = "123";
            //var newStr = str;
            //str = newStr + "345";
            //Console.Write(newStr);//123

            //var count = 0;
            //Enumerable.Repeat(1, 100)
            //.Where((_) => count < 50)
            //.Select((x) => count++);
            //Console.Write(count);

            //const int iterations = 100;
            //var count = 0;
            //Parallel.For(0, iterations, (_) => count++);
            //Console.WriteLine($"{ count > iterations}, { count < iterations}");

            //var actions = new List<Action>();
            //for (var count = 0; count < 5; count++)
            //{
            //    actions.Add(() => Console.Write(count + " "));
            //}
            //foreach (var action in actions)
            //{
            //    action();
            //}

            //Console.WriteLine(verify("---(++++)----") == 1);
            //Console.WriteLine(verify("") == 1);
            //Console.WriteLine(verify("before ( middle []) after ") == 1);
            //Console.WriteLine(verify(") (") == 0);
            //Console.WriteLine(verify("<( >)") == 0);
            //Console.WriteLine(verify("( [ <> () ] <> )") == 1);
            //Console.WriteLine(verify(" ( [)") == 0);

            //Console.WriteLine(func("", "", "") == -1);
            //Console.WriteLine(func(Environment.NewLine + Environment.NewLine, "a", "b") == -1);
            //Console.WriteLine(func("aaabbbccc", "c", "d") == 8);
            //Console.WriteLine(func("aaabbbccc", "a", "b") == 5);
            //Console.WriteLine(func("aaabbbccc", "c", "c") == 8);
            //Console.WriteLine(func("aaabbbccc", "e", "f") == -1);


            /*
            Console.WriteLine(func2("", "", "") == -1);
            Console.WriteLine(func2(Environment.NewLine + Environment.NewLine, "a", "b") == -1);
            Console.WriteLine(func2("aaabbbccc", "c", "d") == 8);
            Console.WriteLine(func2("aaabbbccc", "a", "b") == 5);
            Console.WriteLine(func2("aaabbbccc", "c", "c") == 8);
            Console.WriteLine(func2("aaabbbccc", "e", "f") == -1);*/

            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("--------");

            //for (int i = 0; i < 3; ++i)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine(solution(new int[] { 2, 1 }, new int[] { 5, 1 }, 3, 6) == true);
            //Console.WriteLine(solution(new int[] { 2, 1 }, new int[] { 5, 1 }, 2, 6) == false);
            //Console.WriteLine(solution(new int[] { 1, 4, 2 }, new int[] { 10, 4, 7 }, 11, 1) == true);
            //Console.WriteLine(solution(new int[] { 5, 5, 1 }, new int[] { 3, 3, 6 }, 4, 8) == true);
            //Console.WriteLine(solution(new int[] { 1, 3 }, new int[] { 2, 6 }, 1, 5) == true);

            //Console.WriteLine(getMaxSubstrings("", 0) == 0);
            //Console.WriteLine(getMaxSubstrings("ababaeocco", 4) == 2);
            //Console.WriteLine(getMaxSubstrings("aaaaabb", 2) == 3);
            //Console.WriteLine(getMaxSubstrings("aaababaa", 5) == 1);

            Console.WriteLine(calculate("", 0) == 0);

        }


        public static long calculate(string s)
        {
            var result = 0;
           
            return result;
        }


        public static int getMaxSubstrings(string s, int k)
        {
            if (string.IsNullOrEmpty(s) || k == 0) return 0;
            /* 0. Начинаем с нулевой позиции слева
             * 1. Ищем палиндром с размером k = 3 начиная от этой позиции и сдвигаемся вправо
             * 2. Если нашли то записываем этот палиндром в массив палиндромов и начинаем искать другой палиндром
             * начиная с позиции с конца этого палиндрома и переходим к шагу 1.
             * 3. Если не нашли, то начинаем искать палиндром с размером k+1 = 4. и так далее.
             * 4. в конце у нас будет массив палиндромов. это ответ. 
             * 
             * 5. возможно, потом надо начать еще один поиск, но чтобы первый палиндром был не наш найденный,
             * а большего размера, чтобы получать разные наборы палиндромов, запихнуть их все в разные массивы
             * и результат выдать тот, где макс число палиндромов разных. 
             * !!! да, 5 пункт надо сделать, т.к. для кейса "ababaeocco", 4) == 2 алгоритм нашел палиндром "occo" в самом конце
             * с длиной 4. Но есть более оптимальное решение: "ababa" (длина 5) и "occo" (длина 4). Надо алгоритм с разными наборами палиндромов...
             */
            var countPalindroms = 0;

            //Start:

            for (int i = 0; i < s.Length; i++) // цикл по строке s
            {
                Nested:
                for (int substrLength = k; substrLength <= s.Length; substrLength++) // длина субстроки - ищем палиндром с длиной 3,4,5... длина строки s
                {
                    if (i + substrLength > s.Length) break;
                    //for (int j = i; j <= s.Length - substrLength; j++) // цикл по строке s
                    {
                        //if (isPalindrome(s.Substring(i, substrLength))) 
                        if (isPalindrome2(s, i, i + substrLength - 1))
                        {
                            countPalindroms++;
                            //s = s.Substring(i + substrLength);
                            //goto Start;
                            i += substrLength;
                            goto Nested;
                        }
                    }
                    //for (int j = i; j <= s.Length - substrLength; j++) // цикл по строке s
                    //{
                    //    if (isPalindrome(s.Substring(j, substrLength))) 
                    //    {
                    //        countPalindroms++;
                    //        s = s.Substring(j + substrLength);
                    //        goto Start;
                    //    }
                    //}
                }
            }

            return countPalindroms;
        }

        public static bool isPalindrome(string s)
        {
            return s.SequenceEqual(s.Reverse());
        }

        public static bool isPalindrome2(string s, int i, int j)
        {
            if (i > j)
                return true;

            if (s[i] != s[j])
                return false;

            return isPalindrome2(s, i + 1, j - 1);
        }

        static bool solution(int[] A, int[] P, int B, int E)
        {
            if (B == E) return true;
            if (P.Length == 0) return false;

            if (B > E) {
                var x = B;
                B = E;
                E = x;
            }

            var moved = true;

            while (moved) {
                moved = false;

                for (int i = 0; i < P.Length; i++) {
                    if (P[i] - A[i] <= B && P[i] + A[i] > B) {
                        B = P[i] + A[i];

                        if (B >= E) return true;

                        moved = true;
                        break;
                    }
                }
            }

            return false;
        }

        static int verify(string text)
        {
            if (string.IsNullOrEmpty(text)) return 1;

            var stack = new Stack();

            for (int i = 0; i < text.Length; i++)
            {
                var elem = text[i];
                if (elem == '(' || elem == '[' || elem == '<')
                {
                    stack.Push(elem);
                }
                else if (elem == ')' || elem == ']' || elem == '>')
                {
                    var peek = (stack.Count > 0) ? stack.Peek().ToString()[0] : char.MinValue;

                    if ((peek == '(' && elem == ')') || (peek == '[' && elem == ']') || (peek == '<' && elem == '>'))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            var result = (stack.Count == 0) ? 1 : 0;
            return result;
        }

        static int func2(String s, String a, String b)
        {
            if (string.IsNullOrEmpty(s)) return -1;
            var lastIndexA = s.LastIndexOf(a);
            var lastIndexB = s.LastIndexOf(b);
            if (lastIndexA != -1 && lastIndexB != -1) return Math.Max(lastIndexA, lastIndexB);
            if (lastIndexA != -1) return lastIndexA;
            return lastIndexB;
        }

        static int func(String s, String a, String b)
        {
            Regex rx = new Regex(@"^$");
            MatchCollection matches = rx.Matches(s);
            if (matches.Count > 0)
                return -1;
            else
            {
                int i = s.Length - 1;
                int aIndex = -1;
                int bIndex = -1;
                while ((aIndex == -1) && (bIndex == -1) && (i >= 0))
                {
                    if (s.Substring(i, Math.Max(Math.Min(i + 1, s.Length - i) - i, 1)).Equals(a))
                        aIndex = i;
                    if (s.Substring(i, Math.Max(Math.Min(i + 1, s.Length - i) - i, 1)).Equals(b))
                        bIndex = i;
                    i--;
                }
                if (aIndex != -1)
                {
                    if (bIndex == -1)
                        return aIndex;
                    else
                        return Math.Max(aIndex, bIndex);
                }
                else
                {
                    if (bIndex != -1)
                        return bIndex;
                    else
                        return -1;
                }
            }
        }
    }
}
