using System;

namespace Lab4
{
  interface IOriginator
  {
    object GetMemento();
    void SetMemento(object memento);
  }

  class Memento
  {
    public string Breed { get; set; }
    public string Name {get; set; }
    public int Age { get; set; }

  }
}
