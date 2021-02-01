using System;
using Microsoft.VisualBasic;

namespace DoubleLinekedList
{
    public class DoubleLinkedList <T>
    {
        protected Node<T> head { get; set; }
        protected Node<T> tail { get; set; }
        protected int count;
        
        /// <summary>
        /// добавление элемента в конец списка
        /// </summary>
        /// <param name="data"></param>
        public void AddToTail (T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
                count = 1;
            }
            else if (count == 1)
            {
                head.Next = node;
                node.Prev = head;
                tail = node;
                count++;
            }
            else if (count > 1)
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
                count++;
            }
        }
        /// <summary>
        /// добавление элемента в начало списка
        /// </summary>
        /// <param name="data"></param>
        public void AddToHead(T data)
        {
            Node<T> node = new Node<T>(data);

            if (count == 0)
            {
                head = node;
                count = 1;
            }
            else
            {
                Node<T> prevHead = head;
                prevHead.Prev = node;
                node.Next = prevHead;
                head = node;
                count++;
            }
        }
        /// <summary>
        /// добавление элемента по позици
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        public void AddToPos(T data , int pos)
        {
            Node<T> node = new Node<T>(data);

            if (count == 0 && pos == 0)
            {
                head = node;
                count = 1;
            }
            else if (pos == 1)
            {
                AddToHead(data);
            }
            else if (pos == count)
            {
                AddToTail(data);
            }
            else
            {
                Node<T> iter = head;
                for (int i = 1; i < pos; ++i)
                {
                    iter = iter.Next;
                }

                iter.Next.Prev = node;
                node.Next = iter.Next;
                node.Prev = iter;
                iter.Next = node;
                
                count++;
            }
        }
        /// <summary>
        /// возвращение новой ноды из массива прототипов
        /// </summary>
        /// <param name="data"></param>
        /// <param name="iter"></param>
        /// <returns></returns>
        public Node<T> ReturnNewNodeFromRange(T[] data, int iter)
        {
            Node<T> node = new Node<T>(data[iter]);
            return node;
        }
        /// <summary>
        /// добавить массив данных по позиции
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <exception cref="Exception"></exception>
        public void AddRangeToPos(T[] data, int pos)
        {
            if (count == 0 && pos == 0)
            {
                if (data.Length == 1)
                {
                    head = ReturnNewNodeFromRange(data, 0);
                    count++;
                }
                else if (data.Length == 2)
                {
                    head = ReturnNewNodeFromRange(data, 0);
                    tail = ReturnNewNodeFromRange(data, 1);
                    head.Next = tail;
                    tail.Prev = head;
                    count += 2;
                }
                else
                {
                    head = ReturnNewNodeFromRange(data, 0);
                    Node<T> iter = head;
                    count = 1;
                    for (int i = 1; i < data.Length; ++i)
                    {
                        Node<T> newNode = ReturnNewNodeFromRange(data, i);
                        iter.Next = newNode;
                        newNode.Prev = iter;
                        count++;
                        iter = iter.Next;
                        if (i == data.Length - 1)
                        {
                            tail = iter;
                        }
                    }
                }
            }
            else if (pos > count + 1)
            {
                throw new Exception("Position outside of the limit");
            }
            else if (data.Length == 0)
            {
                throw new Exception("No Data!");
            }
            else if (pos == count + 1)
            {
                int newPos = pos - 1;
                for (int i = 0; i < data.Length; ++i)
                {
                    AddToPos(data[i], newPos++);
                }
            }
            else if (pos == count)
            {
                /*Node<T> node = tail;
                for (int i = 0; i < data.Length; ++i)
                {
                    Node<T> newNode = ReturnNewNodeFromRange(data, i);
                    node.Next = newNode;
                    newNode.Prev = node;
                    count++;
                    if (i != data.Length)
                    {
                        node = node.Next;
                    }
                    if (i == data.Length)
                    {
                        tail = node;
                    }
                }*/

                int newPos = pos - 2;
                for (int i = 0; i < data.Length; ++i)
                {
                    AddToPos(data[i], newPos++);
                }
            }
            else if (pos != count)
            {
                /*Node<T> node = head;
                for (int i = 1; i < pos; ++i)
                {
                    node = node.Next;
                }
                Node<T> addToList = node.Next;
                for (int i = 0; i < data.Length; ++i)
                {
                    Node<T> newNode = ReturnNewNodeFromRange(data, i);
                    node.Next = newNode;
                    newNode.Prev = node;
                    count++;
                    node = node.Next;
                }
                addToList.Prev = node;
                node.Next = addToList;
            }*/

                int newPos = pos;
                for (int i = 0; i < data.Length; ++i)
                {
                    AddToPos(data[i], newPos++);
                }
            }
        }
        /// <summary>
        /// удалить диапазон значений
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <exception cref="Exception"></exception>
        public void RemoveRangeFromTo(int startPos, int endPos)
        {
            if (count == 0 && count == 1)
            {
                throw new Exception("Can't use a range based method on a single element");
            }
            if (startPos > count || endPos > count)
            {
                throw new Exception("Incorrect arguments");
            }

            int toDeleteElementsCounter = endPos - startPos;
            if (toDeleteElementsCounter >= count)
            {
                throw new Exception("The range is too big");
            }
            
            else
            {
                Node<T> iter = head;
                for (int i = 1; i < startPos; ++i)
                {
                    iter = iter.Next;
                }
                Node<T> from = iter;    
                for (int i = 0; i < toDeleteElementsCounter; ++i)
                {
                    iter = iter.Next;
                }
                Node<T> toAttach = iter;
                
                from.Next = toAttach;
                toAttach.Prev = from;

                count = count - toDeleteElementsCounter + 1;
            }
            
        }
        /// <summary>
        /// удаление с начала
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void RemoveFromHead ()
        {
            if (count == 0)
            {
                throw new Exception("The List is Empty");
            }
            
            if (count == 1)
            {
                head = null;
                tail = null;
                count = 0;
            }
            else if (count == 2)
            {
                tail.Prev = null;
                head = null;
                head = tail;
                count--;
            }
            else if (count > 2)
            {
                Node<T> node = head.Next;
                head = null;
                head = node;
                count--;
            }
        }
        /// <summary>
        /// удаление с конца
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void RemoveFromTail ()
        {
            if (count == 0)
            {
                throw new Exception("The List is Empty");
            }
            
            if (count == 1)
            {
                head = null;
                tail = null;
                count = 0;
            }
            else if (count == 2)
            {
                head.Next = null;
                tail = null;
                count--;
            }
            else if (count > 2)
            {
                Node<T> node = tail.Prev;
                tail = null;
                tail = node;
                count--;
            }
        }
        /// <summary>
        /// удалить по позиции
        /// </summary>
        /// <param name="pos"></param>
        /// <exception cref="Exception"></exception>
        public void RemoveOnPos(int pos)
        {
            if (count == 0 || pos == 0)
            {
                throw new Exception("The List is empty, or invalid position");
            }
            if (pos == 1)
            {
                RemoveFromHead();
            }
            else if (pos == count)
            {
                RemoveFromTail();
            }
            else 
            {
                Node<T> iter = head;
                for (int i = 1; i < pos; ++i)
                {
                    iter = iter.Next;
                }
                iter.Prev.Next = iter.Next;
                iter.Next.Prev = iter.Prev;
                count--;
            }
        }
        /// <summary>
        /// вернуть данные по позиции
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public T ShowDataOnPos(int pos)
        {
            if (count == 0)
            {
                throw new Exception("The List is Empty");
            }
            if (pos == 0)
            {
                throw new Exception("Invalid Position Argument");
            }
            
            Node<T> node = head;
            for (int i = 1; i < pos; ++i)
            {
                node = node.Next;
            }
            return node.Data;
        }
        /// <summary>
        /// показать весь список
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ShowFullList()
        {
            if (count == 0)
            {
                throw new Exception("The List is Empty");
            }
            
            Console.WriteLine('\n');
            Console.WriteLine("Current size is: " + count);
            Node<T> node = head;
            for (int i = 1; i <= count; ++i)
            {
                Console.WriteLine("Node: " + i +" \t Data-> " + node.Data);
                node = node.Next;
            }
            Console.WriteLine('\n');
        }
    }
}