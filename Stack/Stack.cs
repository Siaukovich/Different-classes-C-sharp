using System;

namespace ConsoleApplication1
{
    public class Stack<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node _head;

        public Stack()
        {
            _head = null;
        }

        public bool IsEmpty() =>
            _head == null;

        public void Push(T pValue)
        {
            Node newNode = new Node {Next = null, Value = pValue};

            if (IsEmpty())
            {
                _head = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty!");

            T returnValue = _head.Value;

            var lastElement = (_head.Next == null);
            if (lastElement)
            {
                _head = null;
            }
            else
            {
                _head = _head.Next;
            }

            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            return returnValue;
        }

        public void Clear()
        {
            while (!IsEmpty())
                Pop();
        }

        public void ShowAll()
        {
            var tempNode = _head;
            while (tempNode != null)
            {
                Console.Write(tempNode.Value + " ");
                tempNode = tempNode.Next;
            }
        }
    }
}