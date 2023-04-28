using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{ 
  public abstract class ICalculateEvent
  {
    public string EventType { get; set;}
    public int[,] MainMatrix { get; set; }
    public int[,] MinorMatrix { get; set; }
    public int Number { get; set; }
  }
  
  class SumEvent : ICalculateEvent
  {

    public SumEvent(int[,] sqMatrix, int number)
    {
      EventType = "Матрица + число";

      MainMatrix= sqMatrix;
      this.Number = number;
    }

    public SumEvent(int[,] firstMatrix, int[,] secondMatrix)
    {
      EventType = "Матрица + матрица";

      MainMatrix = firstMatrix;
      MinorMatrix = secondMatrix;
    }
  }

  class SubEvent : ICalculateEvent
  {

    public SubEvent(int[,] sqMatrix, int number)
    {
      EventType = "Матрица - число";

      MainMatrix = sqMatrix;
      this.Number = number;
    }

    public SubEvent(int[,] firstMatrix, int[,] secondMatrix)
    {
      EventType = "Матрица - матрица";

      MainMatrix = firstMatrix;
      MinorMatrix = secondMatrix;
    }
  }
}
