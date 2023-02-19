/***************
* Колечков Лев *
*  19.02.2023  *
*     Лаб.2    *
***************/

using System;

namespace Lab2
{
  class SingleTone
  {
    byte type;

    enum TypesOfFiles
    {
      Word = 1,
      PDF,
      Excel,
      TXT,
      HTML
    }

    // Относится ко всем типам
    string name;
    string author;
    string keyWords; 
    string theme;
    string path;

    //Относится только к WORD
    string title;
    string font;

    // Относится только к PDF
    string certificate; 
    int DPI;

    // Относится только к Excel
    int rowCount;
    int columnCount;

    //Относится только к TXT
    byte day;
    byte month;
    int year;

    // Относится только к HTML
    string ID;
    string classes;

    public void InitialiseFile()
    {
      Console.WriteLine("Выберите номер типа файла (1 - Word, 2 - PDF, 3 - Excel, 4 - TXT, 5 - HTML)");
      type = byte.Parse(Console.ReadLine());
      writeInfo(type);
    }

    public void writeInfo(byte type)
    {
      Console.WriteLine("Введите имя файла");
      name = Console.ReadLine();

      Console.WriteLine("Введите имя автора");
      author = Console.ReadLine();

      Console.WriteLine("Введите ключевые слова файла");
      keyWords = Console.ReadLine();

      Console.WriteLine("Введите тему файла");
      theme = Console.ReadLine();

      Console.WriteLine("Введите путь к файлу");
      path = Console.ReadLine();

      switch (type)
      {
        case (byte)TypesOfFiles.Word:
          
          Console.WriteLine("Введите заголовок");
          title = Console.ReadLine();

          Console.WriteLine("Введите название шрифта");
          font = Console.ReadLine();

          Word Word_Document = new Word(name, author, keyWords, theme, path, title, font);
          Word_Document.PrintInfo();
          
          break;
        case (byte)TypesOfFiles.PDF:
          Console.WriteLine("Введите сертификат");
          certificate= Console.ReadLine();

          Console.WriteLine("Введите количество точек на дюйм (DPI)");
          DPI = int.Parse(Console.ReadLine());

          PDF PDF_Document = new PDF(name, author, keyWords, theme, path, certificate, DPI);
          PDF_Document.PrintInfo();

          break;
        case (byte)TypesOfFiles.Excel:
          Console.WriteLine("Введите количество строк");
          rowCount = int.Parse(Console.ReadLine());

          Console.WriteLine("Введите количество столбцов");
          columnCount= int.Parse(Console.ReadLine());

          Excel Excel_Document = new Excel (name, author, keyWords, theme, path, rowCount, columnCount);
          Excel_Document.PrintInfo(); 
          
          break;

        case (byte)TypesOfFiles.TXT:
          Console.WriteLine("Введите день");
          day = byte.Parse(Console.ReadLine());

          Console.WriteLine("Введите месяц");
          month = byte.Parse(Console.ReadLine());

          Console.WriteLine("Введите год");
          year = int.Parse(Console.ReadLine());

          TXT TXT_Document = new TXT(name, author, keyWords, theme, path, day, month, year);
          TXT_Document.PrintInfo();

          break;
        case (byte)TypesOfFiles.HTML:
          Console.WriteLine("Введите название индентефикатора");
          ID = Console.ReadLine();

          Console.WriteLine("Введите название классов");
          classes = Console.ReadLine();

          HTML HTML_Document = new HTML(name, author, keyWords, theme, path, ID, classes);
          HTML_Document.PrintInfo(); 
          break;

      }
    }
  }

  class Execution
  {
    static void Main(string[] args)
    {
      SingleTone file = new SingleTone();
      file.InitialiseFile();
    }
  }
}
