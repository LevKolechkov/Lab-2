using System;
using System.Collections.Generic;

namespace Lab2
{
  class WrongWords
  {
    public WrongWords()
    {

    }

    public WrongWords(int count) 
    {
      this.count = count;
    }

    private int count;

    Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    public void AddWords()
    {
      for (int rowIndex = 0; rowIndex < count; ++rowIndex)
      {
        Console.WriteLine("Введите правильное слово");

        string rightWord = Console.ReadLine();

        List<string> wrongWords = new List<string>();

        Console.WriteLine("Введите теперь к этому слову неправильные слова");

        for (int columnIndex = 0; columnIndex <= 2; ++columnIndex) 
        {
          wrongWords.Add(Console.ReadLine());
        }

        dictionary.Add(rightWord, wrongWords);
      }
    }
  }
}
