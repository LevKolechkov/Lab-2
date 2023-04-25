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
    public SumOfMatrixAndNumberHandler(int[,] sqMatrix, int number) 
    {
      PrivateEvent = new SumEvent(sqMatrix, number);
    }
  }

  class SumOfMatrixAndMatrixHandler : BaseHandler 
  {
    public SumOfMatrixAndMatrixHandler(int[,] firstMatrix, int[,] secondMatrix)
    {
      PrivateEvent = new SumEvent (firstMatrix, secondMatrix);
    }
  }

  class SubOfMatrixAndNumberHandler : BaseHandler 
  {
    public SubOfMatrixAndNumberHandler(int[,] sqMatrix, int number) 
    {
      PrivateEvent = new SubEvent(sqMatrix, number);
    }
  }

  class SubOfMatrixAndMatrixHandler : BaseHandler
  {
    public SubOfMatrixAndMatrixHandler(int[,] firstMatrix, int[,] secondMatrix)
    {
      PrivateEvent = new SubEvent(firstMatrix, secondMatrix);
    }
  }
  
}
