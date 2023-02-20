using System;


namespace Lab2
{
  internal class Doc_class
  {
    public string name;
    public string author;
    public string keyWords;
    public string theme;
    public string path;

    public virtual void PrintInfo()
    {
      Console.WriteLine($" Имя = {name}; \n Автор = {author}; \n Ключевые слова = {keyWords}; \n Тема = {theme}; \n Путь = {path}.");
    }

  }
}
