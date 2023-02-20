using System;

namespace Lab2
{
  class Excel : Doc_class
  {
    int rowCount;
    int columntCount;

    public override void PrintInfo()
    {
      Console.WriteLine($" Имя = {name}; \n Автор = {author}; \n Ключевые слова = {keyWords}; \n Тема = {theme}; \n Путь = {path}; \n Количество строк = {rowCount}; \n Количество столбцов = {columntCount}.");
    }

    public Excel(string name, string author, string keyWords, string theme, string path, int rowCount, int columnCount)
    {
      this.name = name;
      this.author = author;
      this.keyWords = keyWords;
      this.theme = theme;
      this.path = path;
      this.rowCount = rowCount;
      this.columntCount = columnCount;
    }

  }
}
