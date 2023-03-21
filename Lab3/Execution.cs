using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab2
{
  class Execution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Сначала резберёмся со словами");

      string wrongLink = ("D:\\Workspace\\Labs\\Файлы\\wrongWords.txt");
      string rightLink = ("D:\\Workspace\\Labs\\Файлы\\rightWords.txt");

      int count = File.ReadAllLines(wrongLink).Length;

      string wrongText = File.ReadAllText(wrongLink);

      List <string> wordsInFile = new List<string>();

      string word = "";

      for (int index = 0; index < wrongText.Length; index++) 
      {

        if (!char.IsWhiteSpace(wrongText[index]))
        {
          word += wrongText[index];
        }
        else
        {
          wordsInFile.Add(word);

          word = "";

          ++index;
        }
      }

      Console.WriteLine("Список непрвильных слов:");

      foreach (string wrongWord in wordsInFile) 
      {
        Console.WriteLine(wrongWord);
      }

      Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

      WrongWords dictionaryWords = new WrongWords(count);

      Console.WriteLine("Создайте словарь с правильными и неправильными словами, опирающийся на неправильные слова");
      dictionaryWords.AddWords(dictionary);

      Console.WriteLine("Слова исправлены на:");

      foreach (KeyValuePair<string, List<string>> words in dictionary)
      {
        string rightWord = words.Key;
        List<string> wrongWords = words.Value;

        foreach(string wordFromFile in wordsInFile)
        {
          if (wrongWords.Contains(wordFromFile))
          {
            using (StreamWriter writer = new StreamWriter(rightLink, true)) 
            {
              writer.WriteLine(rightWord);
              Console.WriteLine(rightWord);
            }
          }
        }

      }

      Console.WriteLine("\nТеперь работа с номерами");

      string[] numbers = 
      {
        "1-646-791-9525",
        "1-762-305-4233",
        "1-251-463-2362",
        "1-573-484-3327",
        "1-689-434-3525",
        "1-842-475-5345"
      };

      foreach(string number in numbers) 
      {
        Console.WriteLine(number);
      }

      Console.WriteLine();

      foreach (string number in numbers) 
      {
        string newNumber = Regex.Replace(number, @"^1-(\d{3})-(\d{3})-(\d{2})(\d{2})$", "8-$1-$2-$3-$4");
        Console.WriteLine(newNumber);
      }

    }
  }
}
