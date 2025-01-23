using System;
using MyHashMap;

 static class Project
    {

        static void Main(string[] args)
        {
            MyHashMap<int, int> map = new MyHashMap<int, int>();
            map.Put(1, 1);
            map.Put(2, 2);
            map.Put(3, 3);
            map.Put(4, 4);
            map.Put(5, 5);
            map.Put(3, 6);
            map.Put(6, 6);
        var keys = map.KeySet();
        foreach (var entry in map.EntrySet())
        {
            Console.WriteLine($"Ключ: {entry.Key}, Значение: {entry.Value}");
        }
        Console.WriteLine(map.ContainsValue(6));
        Console.WriteLine(map.ContainsValue(10));
    }
}
