using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
  static class MyExtensions
  {
    public static int[,] TransposeMatrix (this SquareMatrix sqMatrix) 
    {
      int sizeOfMatrix = sqMatrix.SizeOfMatrix;
      int[,] resultMatrix = new int[sizeOfMatrix, sizeOfMatrix];

      for (int row = 0; row < sizeOfMatrix; ++row) 
      {
        for (int column = 0; column < sizeOfMatrix; ++column)
        {
          resultMatrix[column, row] = sqMatrix[row, column];
        }
      }

      return resultMatrix;
    }

    public static int TraceOfMatrix(this SquareMatrix sqMatrix)
    {
      int trace = 0;
      int sizeOfMatrix = sqMatrix.SizeOfMatrix;

      for (int row = 0; row < sizeOfMatrix; ++row)
      {
        trace += sqMatrix[row, row];
      }

      return trace;
    }
  }
}
