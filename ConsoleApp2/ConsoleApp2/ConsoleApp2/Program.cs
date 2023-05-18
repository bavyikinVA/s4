using System;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp2
{
    class Program
    {
        public class DoublyNode //узел
        {
            public DoublyNode(string data)
            {
                Data = data;
            }
            public string Data { get; set; }
            public DoublyNode Prev { get; set; } //ссылка на предыдущий узел
            public DoublyNode Next { get; set; } //ссылка на след.узел
        }

        public class DoublyLinkedList  // двусвязный список
        {
            DoublyNode head; // первый элемент
            DoublyNode tail; // последний элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Add(string data)
            {
                DoublyNode node = new DoublyNode(data);

                
                if (head == null)
                    head = node;
                else
                {
                    tail.Next = node;
                    node.Prev = tail;
                }
                tail = node;
                count++;
            }
            public void AddFirst(string data) //добавление узла на первое место в списке
            {
                DoublyNode node = new DoublyNode(data);
                
                DoublyNode temp = head;
                node.Next = temp;
                head = node;
                if (count == 0)
                    tail = head;
                else
                    temp.Prev = node;
                count++;
            }
            // удаление
            public bool Remove(string data)
            {
                DoublyNode node = head;

                // поиск удаляемого узла
                while (node != null)
                {
                    if (node.Data.Equals(data))
                    {
                        break;
                    }
                    node = node.Next;
                }
                if (node != null)
                {
                    // если узел не последний
                    if (node.Next != null)
                    {
                        node.Next.Prev = node.Prev;
                    }
                    else
                    {
                        // если последний, переустанавливаем tail
                        tail = node.Prev;
                    }

                    // если узел не первый
                    if (node.Prev != null)
                    {
                        node.Prev.Next = node.Next;
                    }
                    else
                    {
                        // если первый, переустанавливаем head
                        head = node.Next;
                    }
                    count--;
                    return true;
                }
                return false;
            }


            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }

        }

        static void Main()
        {
            DoublyLinkedList linkedList = new DoublyLinkedList();
            // добавление элементов
            //linkedList.Add(6);
            //linkedList.Add(12);
            //linkedList.Add(72);
            //linkedList.AddFirst(3);
            Console.WriteLine("Введите количество элементов списка: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Список:");
            for (int i = 0; i < index; i++)
            {
                linkedList.Add(Console.ReadLine());
            }

            foreach (DoublyNode node in linkedList)
            {
                Console.WriteLine(node.Data);
            }

            // удаление элемента
            //linkedList.Remove(6);

            Console.WriteLine("Список после удаления: ");

            // перебор с последнего элемента
            //foreach (int list in linkedList)
            //{
            //    Console.WriteLine(list);
            //}
            //очистка списка
            linkedList.Clear();
            Console.WriteLine("Список после очистки: ");
            //foreach (int list in linkedList)
            //{
            //    Console.WriteLine(list);
            //}
        }
    }
}
