using System;

namespace ConsoleApplication1
{
    class WorkingWithStack
    {
        private enum Option
        {
            EXIT     = 0,
            PUSH     = 1,
            POP      = 2,
            SHOW_ALL = 3,
            CLEAR    = 4,
            IS_EMPTY = 5
        };

        static void Main(string[] args)
        {
            var queue = new Stack<int>();
            var again = true;

            while (again)
            {
                Console.WriteLine("1) Push");
                Console.WriteLine("2) Pop");
                Console.WriteLine("3) Show all");
                Console.WriteLine("4) Clear");
                Console.WriteLine("5) Check is empty");
                Console.WriteLine("0) Exit");

                var input = GetOption();

                switch (input)
                {
                    case Option.PUSH:
                        Console.Write("Input value to enqueue: ");
                        queue.Push(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case Option.POP:
                        Pop(queue);
                        break;
                    case Option.SHOW_ALL:
                        queue.ShowAll();
                        break;
                    case Option.IS_EMPTY:
                        Console.WriteLine("Is empty: " + queue.IsEmpty());
                        break;
                    case Option.CLEAR:
                        queue.Clear();
                        Console.WriteLine("Stack cleared.");
                        break;
                    case Option.EXIT:
                        again = false;
                        break;
                }

                Console.WriteLine("Press any.");
                Console.ReadKey();
                Console.WriteLine();
            }
        }

        static Option GetOption()
        {
            while (true)
            {
                Console.Write("Input your option: ");
                var inputString = Console.ReadLine();
                int backing;

                if (int.TryParse(inputString, out backing))
                {
                    var backingInRange = (backing >= 0 && backing <= 5);
                    if (backingInRange)
                        return (Option) Enum.Parse(typeof (Option), inputString);
                }

                Console.WriteLine("Wrong input!");
            }
        }


        static void Pop<T>(Stack<T> pStack)
        {
            try
            {
                Console.WriteLine("Dequeued value: " + pStack.Pop());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
