using MyStack;
using System;

class program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>();
        for (int i = 1; i < 11; i++)
        {
            stack.Push(i);
            Console.Write(i); Console.Write(" ");
        }
        stack.Push(87);
        Console.Write("87"); Console.Write(" ");
        Console.WriteLine(stack.Peek());
        stack.Pop();
        Console.WriteLine(stack.Empty());
        Console.WriteLine(stack.Seek(5));
        Console.WriteLine(stack.Seek(34));

    }
}
