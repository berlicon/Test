using System;

namespace Calculate
{
    internal class Program
    {
        enum Operation
        {
            Plus,
            Minus,
            Multiply,
        }

        const char PLUS = '+';
        const char MINUS = '-';
        const char MULTIPLY = '*';

        static void Main(string[] args)
        {
            Console.WriteLine(Calculate("2+2") == 4);
            Console.WriteLine(Calculate("2+2+1") == 5);
            Console.WriteLine(Calculate("5-2") == 3);
            Console.WriteLine(Calculate("2*3") == 6);
            Console.WriteLine(Calculate("5-2-6") == -3);
            //Console.WriteLine(Calculate("-5-2") == -7);
        }

        static void ProcessNumber(ref long result, ref string number, Operation operation)
        {
            if (operation == Operation.Multiply)
            {
                result *= int.Parse(number);
            }
            else
            {
                result += (int.Parse(number) * ((operation == Operation.Plus) ? 1 : -1));
            }
            number = String.Empty;
        }

        static Operation GetOperation(char item)
        {
            return (item == MINUS) ? Operation.Minus : (item == PLUS) ? Operation.Plus : Operation.Multiply;
        }

        static long? Calculate(string s)
        {
            long result = 0;

            var operation = Operation.Plus;
            var number = String.Empty;
            foreach (var item in s.ToCharArray())
            {
                if (item == MINUS || item == PLUS || item == MULTIPLY) {
                    ProcessNumber(ref result, ref number, operation);
                    operation = GetOperation(item);
                } else
                {
                    number += item;
                }
            }

            ProcessNumber(ref result, ref number, operation);

            return result;
        }
    }
}
