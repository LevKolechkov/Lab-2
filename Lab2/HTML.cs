using System;


namespace Lab2
{
  class HTML : Doc_class
  {
    string ID;
    string classes;

    public override void PrintInfo()
    {
      Console.WriteLine($" Имя = {name}; \n Автор = {author}; \n Ключевые слова = {keyWords}; \n Тема = {theme}; \n Путь = {path}; \n ID = {ID}; \n Классы {classes}.");
    }

    public HTML (string name, string author, string keyWords, string theme, string path, string ID, string classes)
    {
      this.name = name;
      this.author = author;
      this.keyWords = keyWords;
      this.theme = theme;
      this.path = path;
      this.ID = ID;
      this.classes = classes;
    }
  }
}
