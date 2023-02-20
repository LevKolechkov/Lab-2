using System;

namespace Lab2
{
  internal class Word : Doc_class
  {
    string title;
    string font;

    public override void PrintInfo()
    {
      Console.WriteLine($" Имя = {name}; \n Автор = {author};\n Ключевые слова = {keyWords}; \n Тема = {theme}; \n Путь = {path}; \n Название = {title}; \n Шрифт = {font}.");
    }

    public Word(string name, string author, string keyWords, string theme, string path, string title, string font)
    {
      this.name = name;
      this.author = author;
      this.keyWords = keyWords;
      this.theme = theme;
      this.path = path;
      this.title = title;
      this.font = font;
    }
  }
}
