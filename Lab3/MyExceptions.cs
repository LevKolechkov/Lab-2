using System;

namespace Project2
{
  public class MatrixException : Exception
  {
    public MatrixException() { }
    public MatrixException(string message) : base(message) { }
    public MatrixException(string message, Exception innerEception) : base(message, innerEception) { }
  }

  public class ObjectException : Exception
  {
    public ObjectException() { }
    public ObjectException(string message) : base(message) { }
    public ObjectException(string message, Exception innerEception) : base(message, innerEception) { }
  }
}
