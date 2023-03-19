using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2
{
  class Execution
  {
    static void Main(string[] args)
    {
      string wrongLink = ("D:\\Workspace\\Labs\\Файлы\\wrongWords.txt");
      string rightLink = ("D:\\Workspace\\Labs\\Файлы\\rightWords.txt");

      FileStream wrongFile = new FileStream(wrongLink, FileMode.OpenOrCreate, FileAccess.Read);

      FileStream rightFile = new FileStream(rightLink, FileMode.OpenOrCreate, FileAccess.Write);

      int count = File.ReadAllLines(wrongLink).Length;

      WrongWords wrongWords = new WrongWords(count);


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

      foreach (string i in words) 
      {
        Console.WriteLine(i);
      }
      
    }
  }
}
