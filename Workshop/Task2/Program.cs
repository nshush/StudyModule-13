using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу:");
        string filePath = Console.ReadLine();

        string text = File.ReadAllText(filePath);

        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        string[] words = noPunctuationText.Split(' ');

        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (wordFrequency.ContainsKey(word))
                wordFrequency[word]++;
            else
                wordFrequency.Add(word, 1);
        }

        var sortedWordFrequency = from pair in wordFrequency
                                  orderby pair.Value descending
                                  select pair;

        Console.WriteLine("10 самых частых слов:");
        int i = 0;
        foreach (KeyValuePair<string, int> pair in sortedWordFrequency)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
            i++;
            if (i == 10)
                break;
        }
    }
}
