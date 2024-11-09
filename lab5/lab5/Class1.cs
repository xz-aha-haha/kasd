﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{

    public class MyArrayList<T>
    {

        private int size;
        private T[] elementData;

        public MyArrayList()   //пустой список
        {
            elementData = new T[0];
        }

        public MyArrayList(T[] a)
        {
            elementData = new T[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                elementData[i] = a[i];
            }
            size = a.Length;
        }

        public MyArrayList(int capacity) //создание массива размера 0 с запасом на какое-то количество эл, для 
        {
            elementData = new T[capacity];
            size = 0;
        }

        public void Add(T element)
        {
            if (size == elementData.Length)
            {
                T[] ar = new T[(int)(elementData.Length * 1.5) + 1];
                for (int i = 0; i < size; i++) ar[i] = elementData[i];
                elementData = ar;
            }
            elementData[size] = element;
            size++;
        }
        public void AddAll(T[] a)
        {
            if (a.Length <= elementData.Length - size)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    elementData[size + i] = a[i];
                }
                size += a.Length;
            }
            else
            {
                var newData = new T[a.Length + size / 2 * 3 + 1];
                for (int i = 0; i < size; i++)
                {
                    newData[i] = elementData[i];
                }
                for (int i = 0; i < a.Length; i++)
                {
                    newData[i + size] = a[i];
                }
                size += a.Length;
                elementData = newData;
            }
        }
        public void Clear() //буфер не трогать
        {
            size = 0;
        }

        public bool Contains(object o)
        {
            if ((o is T) == false) return false;
            var x = (T)o;
            for (int i = 0; i < size; i++)
            {
                if (elementData[i].Equals(x)) return true;
            }
            return false;
        }

        public bool ContainsAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!Contains(a[i])) return false;
            }
            return true;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
        public void Remove(object o)
        {
            if (Contains(o))
            {
                int i = 0;
                while (!elementData[i].Equals(o)) i++;
                for (int j = i; j < elementData.Length - 1; j++) elementData[j] = elementData[j + 1];
                size--;
            }
            else Console.WriteLine($"Element {o} does not exist in this array");
        }
        public void RemoveAll(T[] a)
        {
            foreach (T e in a) Remove(e);
        }

        public void RetainAll(T[] a)
        {
            int k = 0;
            for (int i = 0; i < size; i++)
            {
                bool found = false;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j].Equals(elementData[i]))
                    {
                        found = true;
                        break;
                    }

                }
                if (found)
                {
                    k++;
                }
            }
        }
        public int Size()
        {
            return size;
        }
        public T[] ToArray()
        {
            T[] returnedArray = new T[size];
            for (int i = 0; i < size; i++)
            {
                returnedArray[i] = elementData[i];
            }
            return returnedArray;
        }

        public void ToArray(ref T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = elementData[i];
            }

        }

        public void Resize()
        {
            T[] newArray = new T[elementData.Length * (3 / 2) + 1];
            for (int i = 0; i < elementData.Length; i++) newArray[i] = elementData[i];
            Array.Clear(elementData);
            elementData = newArray;

        }

        public void Add(int index, T e)
        {
            if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
            if (size == elementData.Length) Resize();
            for (int i = size - 1; i >= index; i--) elementData[i + 1] = elementData[i];
            elementData[index] = e;
            size++;
        }

        public void AddAll(int index, T[] a)
        {
            if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
            int j = 0;
            while (size + a.Length > elementData.Length) Resize();
            for (int i = size - 1; i >= index; i--) elementData[i + a.Length] = elementData[i];
            for (int i = index; i < index + a.Length; i++) elementData[i] = a[j++];
            size += a.Length;
        }

        public T Get(int index)
        {
            if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException("index is out of range");
            }
            return elementData[index];
        }

        public int IndexOf(object o)
        {
            for (int i = 0; i < size; i++)
            {
                if (o.Equals(elementData[i])) return i;
            }
            return -1;
        }

        public int LastIndexOf(object o)
        {
            for (int i = size - 1; i >= 0; i--)
            {
                if (o.Equals(elementData[i])) return i;
            }
            return -1;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= size) throw new ArgumentOutOfRangeException("index");
            T element = elementData[index];
            Remove(element);
            return element;
        }

        public void Set(int index, T e)
        {
            if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
            elementData[index] = e;
        }

        public MyArrayList<T> SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || fromIndex > size) throw new ArgumentOutOfRangeException("index");
            if (toIndex < 0 || toIndex > size) throw new ArgumentOutOfRangeException("index");
            MyArrayList<T> resultingArray = new MyArrayList<T>(toIndex - fromIndex);
            for (int i = 0; i < resultingArray.size; i++)
            {
                resultingArray.Set(i, elementData[fromIndex + i]);
            }
            return resultingArray;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < size; i++) s += elementData[i] + " ";
            return s;
        }
        public void Print()
        {
            Console.WriteLine(this);
        }
    }

}
