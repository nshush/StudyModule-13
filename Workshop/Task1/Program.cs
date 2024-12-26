using System;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу:");
        string filePath = Console.ReadLine();

        List<int> listData = new List<int>();
        LinkedList<int> linkedListData = new LinkedList<int>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
                listData.Add(int.Parse(line));
        }

        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Вставка в List<T>:");
        stopwatch.Start();
        for (int i = 0; i < 1000; i++)
        {
            listData.Insert(0, i); 
        }
        stopwatch.Stop();
        TimeSpan timeSpan = stopwatch.Elapsed;
        Console.WriteLine($"Время выполнения: {timeSpan.TotalMilliseconds} ms");

        Console.WriteLine();

        Console.WriteLine("Вставка в LinkedList<T>:");
        stopwatch.Reset();
        stopwatch.Start();
        for (int i = 0; i < 1000; i++)
        {
            linkedListData.AddFirst(i); 
        }
        stopwatch.Stop();
        timeSpan = stopwatch.Elapsed;
        Console.WriteLine($"Время выполнения: {timeSpan.TotalMilliseconds} ms");
    }
}
