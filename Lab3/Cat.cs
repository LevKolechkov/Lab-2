using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lab4
{
  [Serializable]
  class Cat : IOriginator
  {
    public string Breed { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Cat() { }
    
    public Cat(string breed, string name, int age)
    {
      Breed = breed;
      Name = name;
      Age = age;
    }

    public void Serialize(FileStream binCat)
    {
      BinaryFormatter bf = new BinaryFormatter();

      bf.Serialize(binCat, this);

      binCat.Flush();
      binCat.Close();
    }

    public void Deserialize(FileStream binCat)
    {
      BinaryFormatter bf = new BinaryFormatter();

      Cat desCat = (Cat)bf.Deserialize(binCat);

      Breed = desCat.Breed;
      Name = desCat.Name;
      Age = desCat.Age;

      binCat.Close();
    }

    public void Print()
    {
      Console.WriteLine($"Breed: {Breed}, Name: {Name}, Age: {Age}");
    }

    object IOriginator.GetMemento()
    {
      return new Memento
      {
        Breed = Breed,
        Name = Name,
        Age = Age
      };
    }

    void IOriginator.SetMemento(object memento)
    {
      if (memento is Memento)
      {
        var mem = memento as Memento;
        Breed = mem.Breed;
        Age = mem.Age;
      }
    }
  }
}
