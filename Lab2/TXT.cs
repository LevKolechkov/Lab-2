using System;


namespace Lab2
{
  class TXT : Doc_class
  {
    int day;
    int month;
    int year;

    public override void PrintInfo()
    {
      Console.WriteLine($" Имя = {name}; \n Автор = {author}; \n Ключевые слова = {keyWords}; \n Тема = {theme}; \n Путь = {path}; \n Файл создан {day}.{month}.{year}.");
    }
    public TXT (string name, string author, string keyWords, string theme, string path, byte day, byte month, int year)
    {
      this.name = name;
      this.author = author;
      this.keyWords = keyWords;
      this.theme = theme;
      this.path = path;
      this.day = day;
      this.month = month;
      this.year = year;
    }
  }
}
