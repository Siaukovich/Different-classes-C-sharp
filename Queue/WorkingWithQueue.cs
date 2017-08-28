using System;

namespace ConsoleApplication1
{
    class WorkingWithQueue
    {
        private enum Option
        {
            EXIT     = 0,
            ENQUEUE  = 1,
            DEQUEUE  = 2,
            SHOW_ALL = 3,
            CLEAR    = 4,
            IS_EMPTY = 5
        };

        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            var again = true;

            while (again)
            {
                Console.WriteLine("1) Enqueue");
                Console.WriteLine("2) Dequeue");
                Console.WriteLine("3) Show all");
                Console.WriteLine("4) Clear");
                Console.WriteLine("5) Check is empty");
                Console.WriteLine("0) Exit");

                var input = GetOption();

                switch (input)
                {
                    case Option.ENQUEUE:
                        Console.Write("Input value to enqueue: ");
                        queue.Enqueue(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case Option.DEQUEUE:
                        Dequeue(queue);
                        break;
                    case Option.SHOW_ALL:
                        queue.ShowAll();
                        break;
                    case Option.IS_EMPTY:
                        Console.WriteLine("Is empty: " + queue.IsEmpty());
                        break;
                    case Option.CLEAR:
                        queue.Clear();
                        Console.WriteLine("Queue cleared.");
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


        static void Dequeue<T>(Queue<T> pQueue)
        {
            try
            {
                Console.WriteLine("Dequeued value: " + pQueue.Dequeue());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
