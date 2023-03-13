/***************************
*      Колечков Лев        *
*       13.03.2023         *
* Стандартный ввод и вывод *
***************************/
using System;
using System.IO;

namespace Lab4
{
  class Execution
  {
    static void Main(string[] args)
    {
      FileStream binCat = new FileStream("D:\\Workspace\\Labs\\binCat.bin", FileMode.OpenOrCreate, FileAccess.Write);
      
      Cat cat = new Cat("Сиамский", "Барсик", 9);

      cat.Print();

      cat.Serialize(binCat);

      cat = new Cat("Британец", "Чарльз", 15);

      binCat = new FileStream("D:\\Workspace\\Labs\\binCat.bin", FileMode.OpenOrCreate, FileAccess.Read);

      cat.Print();

      cat.Deserialize(binCat);

      cat.Print();
    }
  }
}