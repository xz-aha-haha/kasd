﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    internal class Program
    {
        class MyArrayDeque<T>
        {
            private T[] elements;
            private int head;
            private int tail;
            public MyArrayDeque()
            {
                elements = new T[16];
                head = 0;
                tail = 0;
            }
            public MyArrayDeque(T[] a)
            {
                elements = new T[a.Length];
                head = 0;
                tail = a.Length;
                for (int i = 0; i < a.Length; i++) elements[i] = a[i];
            }
            public MyArrayDeque(int numElements)
            {
                elements = new T[numElements];
                head = 0;
                tail = numElements;
            }
            public void add(T e)
            {
                if (tail == elements.Length)
                {
                    T[] newElements = new T[(tail * 2) + 1];
                    for (int i = 0; i < tail; i++) newElements[i] = elements[i];
                    elements = newElements;
                    elements[tail++] = e;
                }
                else elements[tail++] = e;
            }
            public void addAll(T[] a)
            {
                for (int i = 0; i < a.Length; i++) add(a[i]);
            }
            public void clear()
            {
                tail = 0;
                elements = new T[0]; 
            }
            public bool contains(object o)
            {
                for (int i = 0; i < tail; i++)
                {
                    if (elements[i].Equals(o)) return true;
                }
                return false;
            }
            public bool containsAll(T[] a)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (contains(a[i]) == false) return false;
                }
                return true;
            }
            public bool isEmpty()
            {
                if (tail == 0) return true;
                else return false;
            }
            public int get(T o) 
            {

                for (int i = 0; i < tail; i++)
                {
                    if (o.Equals(elements[i])) return i;
                }
                return -1;
            }
            public void remove(T o) 
            {
                if (contains(o))
                {
                    int index = get(o);
                    T[] newElements = new T[--tail];
                    for (int i = 0; i < index; i++) newElements[i] = elements[i];
                    for (int i = index; i < tail; i++) newElements[i] = elements[i + 1];
                    elements = newElements;
                }
            }
            public void removeAll(T[] a)
            {
                for (int i = 0; i < a.Length; i++) remove(a[i]);
            }
            public void retainAll(T[] a)
            {
                for (int i = 0; i < tail; i++)
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (!elements[i].Equals(a[j])) remove(elements[i]);
                    }
                }
            }
            public int Size() => tail;
            public double[] toArray()
            {
                double[] newElements = new double[tail];
                for (int i = 0; i < tail; i++) newElements[i] = Convert.ToDouble(elements[i]);
                return newElements;
            }
            public double[] toArray(T[] a)
            {
                double[] newElements = new double[tail];
                if (a == null)
                {
                    for (int i = 0; i < tail; i++)
                    {
                        newElements[i] = Convert.ToDouble(elements[i]);
                    }
                }
                else
                {
                    int h = 0;
                    for (int i = 0; i < tail; i++)
                    {
                        for (int j = 0; j < tail; j++)
                        {
                            if (elements[i].Equals(a[j]))
                            {
                                newElements[h] = Convert.ToDouble(elements[i]);
                                h++;
                            }
                        }
                    }
                }
                return newElements;
            }
            public T element() => elements[head];
            public bool offer(T obj)
            {
                add(obj);
                if (contains(obj)) return true;
                return false;
            }
            public T peek()
            {
                if (tail == 0) throw new Exception("null");
                else return elements[head];
            }
            public T poll()
            {
                if (tail == 0) throw new Exception("null");
                else
                {
                    T element = elements[head];
                    remove(elements[head]);
                    return element;
                }
            }
            public void addFirst(T obj)
            {
                if (head == 0)
                {
                    T[] newElements = new T[tail + 1];
                    newElements[0] = obj;
                    for (int i = 1; i < tail + 1; i++)
                    {
                        for (int j = 0; j < tail; j++)
                        {
                            newElements[i] = elements[j];
                        }
                    }
                    elements = newElements;
                    tail++;
                }
                else
                {
                    head--;
                    T[] newElements = new T[tail];
                    newElements[head] = obj;
                }
            }
            public void addLast(T obj)
            {
                add(obj);
            }
            public T getFirst() => elements[head];
            public T getLast() => elements[tail - 1];
            public bool offerFirst(T obj) 
            {
                addFirst(obj);
                if (contains(obj)) return true;
                return false;
            }
            public bool offerLast(T obj) 
            {
                addLast(obj);
                if (contains(obj)) return true;
                return false;
            }
            public T pop()
            {
                T element = elements[head];
                remove(elements[head]);
                return element;
            }
            public T peekFirst()
            {
                if (tail == 0) throw new Exception("null");
                return elements[head];
            }
            public T peekLast()
            {
                if (tail == 0) throw new Exception("null");
                return elements[tail - 1];
            }
            public T pollFirst()
            {
                if (tail == 0) throw new Exception("null");
                else
                {
                    T element = elements[head];
                    remove(elements[head]);
                    return element;
                }

            }
            public T pollLast()
            {
                if (tail == 0) throw new Exception("null");
                else
                {
                    T element = elements[tail - 1];
                    remove(elements[tail - 1]);
                    return element;
                }

            }
            public T removeFirst()
            {
                T element = elements[head];
                remove(elements[head]);
                return element;
            }
            public T removeLast()
            {
                T element = elements[tail - 1];
                remove(elements[tail - 1]);
                return element;
            }
            public bool removeFirstOccurrence(T obj)
            {
                bool flag = false;
                for (int i = 0; i < tail; i++)
                {
                    if (elements[i].Equals(obj))
                    {
                        remove(elements[i]);
                        flag = true;
                        break;
                    }

                }
                if (flag == true) return true;
                return false;
            }
            public bool removeLasttOccurrence(T obj)
            {
                bool flag = false;
                for (int i = tail; i >= 0; i--)
                {
                    if (elements[i].Equals(obj))
                    {
                        remove(elements[i]);
                        flag = true;
                        break;
                    }

                }
                if (flag == true) return true;
                return false;
            }
            public T get(int i) => elements[i];

        }

        static void Main(string[] args)
        {
            int[] arr1 = { 1, 5, 3, 1, 2, 4, 7, 6, 7 };
            MyArrayDeque<int> arr = new MyArrayDeque<int>(arr1);

            for (int i = 0; i < arr.Size(); i++)
            {
                Console.Write(arr.get(i)); Console.Write(" ");
            }
            Console.Write("\n");

            arr.removeFirst();
            for (int i = 0; i < arr.Size(); i++)
            {
                Console.Write(arr.get(i)); Console.Write(" ");
            }
            Console.Write("\n");

            int[] arr2 = { 4, 5 };
            arr.removeAll(arr2);
            for (int i = 0; i < arr.Size(); i++)
            {
                Console.Write(arr.get(i)); Console.Write(" ");
            }
            Console.Write("\n");

            Console.WriteLine(arr.pollFirst());
            for (int i = 0; i < arr.Size(); i++)
            {
                Console.Write(arr.get(i)); Console.Write(" ");
            }
        }
    }
}
