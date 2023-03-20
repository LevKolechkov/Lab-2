/***************************
*      Колечков Лев        *
*       13.03.2023         *
* Стандартный ввод и вывод *
***************************/
using Lab4;
using System;
using System.IO;

namespace Lab4
{
  class Execution
  {
    static void Main(string[] args)
    {
      KeyWords keyWords = new KeyWords();

      while (true)
      {
        Console.WriteLine("Начнём с создания файла с описанием вашего кота");

        Cat catFile = new Cat();

        Console.WriteLine("Введите название породы");

        catFile.Breed = Console.ReadLine();

        keyWords.addKeyWord(catFile.Breed);

        Console.WriteLine("Введите имя кота");

        catFile.Name = Console.ReadLine();

        keyWords.addKeyWord(catFile.Name);

        Console.WriteLine("Теперь введите возраст кота");

        catFile.Age = int.Parse(Console.ReadLine());

        Console.WriteLine("Выберите как Вы хотите сериализовать файл: 1 - Bin; 2 - XML");

        int choiceSerialize = int.Parse(Console.ReadLine());

        switch (choiceSerialize)
        {
          case 1:
            keyWords.addKeyWord("Bin");

            Console.WriteLine("Вы выбрали Bin");

            FileStream binCat = new FileStream($"D:\\Workspace\\Labs\\Файлы\\BinCat{catFile.Breed}{catFile.Name}", FileMode.OpenOrCreate, FileAccess.Write);

            catFile.binSerialize(binCat);

            break;

          case 2:
            keyWords.addKeyWord("XML");

            Console.WriteLine("Вы выбрали XML");

            FileStream xmlCat = new FileStream($"D:\\Workspace\\Labs\\Файлы\\XmlCat{catFile.Breed}{catFile.Name}", FileMode.OpenOrCreate, FileAccess.Write);

            catFile.XmlSerialize(xmlCat);

            break;

          default:

            throw new Exception("Данного варианта нет. Попрошу начать заново");
        }

        Console.WriteLine("Желаете ли вы создать ещё один файл? (Да/Нет)");

        string choiceSerFile = Console.ReadLine();

        if (choiceSerFile == "Нет") break;
        else Console.Clear();
      }

      string serKey, breedKey, nameKey;

      FileStream fileCat = keyWords.FindFile(out serKey, out breedKey, out nameKey);

      Console.WriteLine("Что вы хотите с ним сделать?");
      Console.WriteLine("1 - Вывести. 2 - Перезаписать");

      int choiceFile = int.Parse(Console.ReadLine());

      Cat cat = new Cat();

      if (serKey == "Bin")
      {
        cat.binSerialize(fileCat);

      }
      else
      {
        cat.XmlDeserialize(fileCat);

      }

      Caretaker saveCat = new Caretaker();

      switch (choiceFile)
      {
        case 1:
          Console.WriteLine("Вы выбрали вывести");

          cat.Print();

          break;

        case 2:
          Console.WriteLine("Вы выбрали перезаписать");

          saveCat.SaveState(cat);

          Console.WriteLine("Введите название породы");
          cat.Breed = Console.ReadLine();

          Console.WriteLine("Введите имя");
          cat.Name = Console.ReadLine();

          Console.WriteLine("Введите возраст");
          cat.Age = int.Parse(Console.ReadLine());

          Console.WriteLine("Вы изменили на:");
          cat.Print();

          Console.WriteLine("Желаете ли отменить? (Да/Нет)");

          string choiceCancel = Console.ReadLine();

          if (choiceCancel == "Да")
          {
            saveCat.RestoreState(cat);

            Console.WriteLine("Изменения отменены");

            cat.Print();
          }
          else
          {
            cat.Print();
          }

          break;
      }
    }
  }
}
