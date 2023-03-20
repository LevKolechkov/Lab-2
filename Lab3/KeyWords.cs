using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
  class KeyWords
  {
    private List<string> keyWords = new List<string>();

    public void addKeyWord(string keyWord)
    {
      keyWords.Add(keyWord);
    }

    public FileStream FindFile(out string serKey, out string breedKey, out string nameKey)
    {
      Console.WriteLine("Какой тип сериализации Вы использовали? Bin или XML?");

      serKey = Console.ReadLine();

      bool key = true;

      foreach (var keyWord in keyWords) 
      {
        if (keyWord == serKey)
        {
          key = false;

          break;
        }
      }
      if (key) throw new Exception("Данной сериализации не было произведено");

      Console.WriteLine("Введите породу кота, описанного в файле");

      breedKey = Console.ReadLine();

      key = true;

      foreach (var keyWord in keyWords)
      {
        if (keyWord == breedKey)
        {
          key = false;

          break;
        }
      }
      if (key) throw new Exception("Данной породы не обнаружено");

      Console.WriteLine("Введите имя кота, описанного в файле");

      nameKey = Console.ReadLine();

      key = true;

      foreach (var keyWord in keyWords)
      {
        if (keyWord == nameKey)
        {
          key = false;

          break;
        }
      }
      if (key) throw new Exception("Данного имени не обнаружено");

      return new FileStream($"D:\\Workspace\\Labs\\Файлы\\{serKey}Cat{breedKey}{nameKey}", FileMode.OpenOrCreate, FileAccess.ReadWrite);
    }
  }
}
