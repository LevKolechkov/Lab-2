using System;


namespace Lab2
{
  class PDF : Doc_class
  {
    string certificate;
    int DPI;

    public override void PrintInfo()
    {
      Console.WriteLine($" Имя = {name}; \n Автор = {author}; \n Ключевые слова = {keyWords}; \n Тема = {theme}; \n Путь = {path}; \n Сертификат = {certificate}; \n DPI = {DPI}.");
    }

    public PDF(string name, string author, string keyWords, string theme, string path, string certificate, int DPI)
    {
      this.name= name;
      this.author= author;
      this.keyWords= keyWords;
      this.theme= theme;
      this.path= path;
      this.certificate= certificate;
      this.DPI = DPI;
    }
  }
}
