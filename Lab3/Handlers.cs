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

    public virtual void Handle(ICalculateEvent ev)
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

    public SumOfMatrixAndNumberHandler(int[,] sqMatrix, int number) 
    {
      PrivateEvent = new SumEvent(sqMatrix, number);

      Calc = new Calculations();

      operation = new MatrixWithNumber(Calc.SumOfMatrixAndNumber);
    }
  }

  class SumOfMatrixAndMatrixHandler : BaseHandler 
  {
    MatrixWithMatrix operation;

    public SumOfMatrixAndMatrixHandler(int[,] firstMatrix, int[,] secondMatrix)
    {
      PrivateEvent = new SumEvent (firstMatrix, secondMatrix);

      Calc = new Calculations();

      operation = new MatrixWithMatrix(Calc.SumOfMatrixAndMatrix);
    }
  }

  class SubOfMatrixAndNumberHandler : BaseHandler 
  {
    MatrixWithNumber operation; 

    public SubOfMatrixAndNumberHandler(int[,] sqMatrix, int number) 
    {
      PrivateEvent = new SubEvent(sqMatrix, number);

      Calc = new Calculations();

      operation = new MatrixWithNumber(Calc.SubOfMatrixAndNumber);
    }
  }

  class SubOfMatrixAndMatrixHandler : BaseHandler
  {
    MatrixWithMatrix operation;

    public SubOfMatrixAndMatrixHandler(int[,] firstMatrix, int[,] secondMatrix)
    {
      PrivateEvent = new SubEvent(firstMatrix, secondMatrix);

      Calc = new Calculations();

      operation = new MatrixWithMatrix(Calc.SubOfMatrixAndMatrix);
    }
  }
  
}
