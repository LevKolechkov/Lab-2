/***************************
*      Колечков Лев        *
*       13.03.2023         *
* Стандартный ввод и вывод *
***************************/
using Lab4;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Lab2
{
  class Execution
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Начнём с создания файла с описанием вашего кота");

      Cat cat = new Cat();

      Console.WriteLine("Введите название породы");

      cat.Breed = Console.ReadLine();

      Console.WriteLine("");

      Console.WriteLine("Выберите номер сериализации которую вы хотите сделать: 1 - txt; 2 - XML");

      int choice = int.Parse(Console.ReadLine());

      switch (choice) 
      {
        case 1:
          Console.WriteLine("Вы выбрали txt");
          break;
      }
    }
  }
}
