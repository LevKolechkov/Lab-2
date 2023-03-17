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

      cat.binSerialize(binCat);

      cat = new Cat("Британец", "Чарльз", 15);

      binCat = new FileStream("D:\\Workspace\\Labs\\binCat.bin", FileMode.OpenOrCreate, FileAccess.Read);

      cat.Print();

      cat.binDeserialize(binCat);

      cat.Print();

      cat = new Cat("Сфинкс", "Пушистик", 4);

      cat.Print();

      FileStream xmlCat = new FileStream("D:\\Workspace\\Labs\\xmlCat.bin", FileMode.OpenOrCreate, FileAccess.Write);

      cat.XmlSerialize(xmlCat);

      cat = new Cat("Мейн кун", "Рон Перлман", 14);

      cat.Print();

      xmlCat = new FileStream("D:\\Workspace\\Labs\\xmlCat.bin", FileMode.OpenOrCreate, FileAccess.Read);

      cat.XmlDeserialize(xmlCat);

      cat.Print();

      Caretaker saveCat = new Caretaker();

      saveCat.SaveState(cat);

      cat = new Cat("Тайский", "Марло", 9);

      cat.Print();

      saveCat.RestoreState(cat);

      cat.Print();
    }
  }
}