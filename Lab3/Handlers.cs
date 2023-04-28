using Lab_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
  public abstract class BaseHandler
  {

    protected BaseHandler Next { get; set; }
    protected ICalculateEvent PrivateEvent { get; set; }

    public Calculations Calc { get; set; }

    public BaseHandler()
    {
      Next = null;
    }

    public virtual void Handle(ICalculateEvent eventOfMatrix)
    {
       
    }

    protected void SetNextHandler (BaseHandler newHandler)
    {
      Next = newHandler;
    }
  }

  class SumOfMatrixAndNumberHandler : BaseHandler
  {
    MatrixWithNumber operation;

    public SumOfMatrixAndNumberHandler(int[,] MainMatrix, int number) 
    {
      Next = new SubOfMatrixAndNumberHandler(MainMatrix, number);

      PrivateEvent = new SumEvent(MainMatrix, number);

      Calc = new Calculations(MainMatrix, null);

      operation = new MatrixWithNumber(Calc.SumOfMatrixAndNumber);
    }

    public override void Handle(ICalculateEvent eventOfMatrix)
    {
      if (PrivateEvent.EventType == "Матрица + число")
      {
        operation(eventOfMatrix.MainMatrix, eventOfMatrix.Number);
      }
      else
      {
        Console.WriteLine("Перехожу к следующему обработчику...");

        Next.Handle(eventOfMatrix);
      }
    }
  }

  class SumOfMatrixAndMatrixHandler : BaseHandler 
  {
    MatrixWithMatrix operation;

    public SumOfMatrixAndMatrixHandler(int[,] MainMatrix, int[,] MinorMatrix)
    {
      Next = new SubOfMatrixAndMatrixHandler(MainMatrix, MinorMatrix);

      PrivateEvent = new SumEvent (MainMatrix, MinorMatrix);

      Calc = new Calculations(MainMatrix, MinorMatrix);

      operation = new MatrixWithMatrix(Calc.SumOfMatrixAndMatrix);
    }

    public override void Handle(ICalculateEvent eventOfMatrix)
    {
      if (PrivateEvent.EventType == "Матрица + число")
      {
        operation(eventOfMatrix.MainMatrix, eventOfMatrix.MinorMatrix);
      }
      else
      {
        Console.WriteLine("Перехожу к следующему обработчику...");
        
        Next.Handle(eventOfMatrix);
      }
    }
  }

  class SubOfMatrixAndNumberHandler : BaseHandler 
  {
    MatrixWithNumber operation; 

    public SubOfMatrixAndNumberHandler(int[,] MainMatrix, int number) 
    {
      Next = null; 

      PrivateEvent = new SubEvent(MainMatrix, number);

      Calc = new Calculations(MainMatrix, null);

      operation = new MatrixWithNumber(Calc.SubOfMatrixAndNumber);
    }

    public override void Handle(ICalculateEvent eventOfMatrix)
    {
      if (PrivateEvent.EventType == "Матрица - число")
      {
        operation(eventOfMatrix.MainMatrix, eventOfMatrix.Number);
      }
      else
      {
        Console.WriteLine("Перехожу к следующему обработчику...");
        Next.Handle(eventOfMatrix);
      }
    }
  }

  class SubOfMatrixAndMatrixHandler : BaseHandler
  {
    MatrixWithMatrix operation;

    public SubOfMatrixAndMatrixHandler(int[,] MainMatrix, int[,] MinorMatrix)
    {
      Next = null;

      PrivateEvent = new SubEvent(MainMatrix, MinorMatrix);

      Calc = new Calculations(MainMatrix, null);

      operation = new MatrixWithMatrix(Calc.SubOfMatrixAndMatrix);
    }

    public override void Handle(ICalculateEvent eventOfMatrix)
    {
      if (PrivateEvent.EventType == "Матрица - матрица")
      {
        operation(eventOfMatrix.MainMatrix, eventOfMatrix.MinorMatrix);
      }
      else
      {
        Console.WriteLine("Невозможно обработать");
      }
    }
  }
  
}
