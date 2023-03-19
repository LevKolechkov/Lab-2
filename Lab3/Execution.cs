using System;
using System.IO;

namespace Lab2
{
  class Execution
  {
    public void Main(string[] args)
    {
      string wrongLink = ("D:\\Workspace\\Labs\\Файлы\\wrongWords.txt");
      string rightLink = ("D:\\Workspace\\Labs\\Файлы\\rightWords.txt");

      FileStream wrongFile = new FileStream(wrongLink, FileMode.OpenOrCreate, FileAccess.Read);

      FileStream rightFile = new FileStream(rightLink, FileMode.OpenOrCreate, FileAccess.Write);

      int count = File.ReadAllLines(wrongLink).Length;

      WrongWords wrongWords = new WrongWords(count);

      wrongWords.AddWords();

       
    }
  }
}
