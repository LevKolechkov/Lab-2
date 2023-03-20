using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
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

      FileStream wrongFile = new FileStream(wrongLink, FileMode.OpenOrCreate, FileAccess.Read);

      FileStream rightFile = new FileStream(rightLink, FileMode.OpenOrCreate, FileAccess.Write);

      int count = File.ReadAllLines(wrongLink).Length;

      string wrongText = File.ReadAllText(wrongLink);

      List <string> words = new List<string>();

      string word = "";

      for (int index = 0; index < wrongText.Length; index++) 
      {

        if (!char.IsWhiteSpace(wrongText[index]))
        {
          word += wrongText[index];
        }
        else
        {
          words.Add(word);

          word = "";

          ++index;
        }
      }

      Console.WriteLine("Список непрвильных слов:");

      foreach (string wrongWord in words) 
      {
        Console.WriteLine(wrongWord);
      }

      WrongWords dictionaryWords = new WrongWords(count);

      Console.WriteLine("Создайте словарь с правильными и неправильными словами, опирающийся на неправильные слова");
      dictionaryWords.AddWords();

      
      
    }
  }
}
