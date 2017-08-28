using System;

namespace ConsoleApplication1
{
    public class Queue<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
        }

        private Node _head;
        private Node _tail;

        public Queue()
        {
            _head = _tail = null;
        }

        public bool IsEmpty() =>
            _head == null;

        public void Enqueue(T pValue)
        {
            Node newNode = new Node {Next = null, Prev = null, Value = pValue};

            if (IsEmpty())
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.Next = _tail;
                _tail.Prev = newNode;
                _tail = _tail.Prev;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty!");

            T returnValue = _head.Value;

            if (_head == _tail)
            {
                _head = _tail = null;
            }
            else
            {
                _head = _head.Prev;
                _head.Next = null;
            }

            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            return returnValue;
        }

        public void Clear()
        {
            while (!IsEmpty())
                Dequeue();
        }

        public void ShowAll()
        {
            var tempNode = _tail;
            while (tempNode != null)
            {
                Console.Write(tempNode.Value + " ");
                tempNode = tempNode.Next;
            }
        }
    }
}