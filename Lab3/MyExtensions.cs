using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
  static class MyExtensions
  {
    public static int[,] TransposeMatrix (this int[,] sqMatrix) 
    {
      int rows = sqMatrix.GetLength (0);
      int columns = sqMatrix.GetLength (1);
      int[,] resultMatrix = new int[columns, rows];

      for (int row = 0; row < rows; ++row) 
      {
        for (int column = 0; column < columns; ++column)
        {
          resultMatrix[column, row] = sqMatrix[row, column];
        }
      }

      return resultMatrix;
    }

    public static int TraceOfMatrix(this int[,] sqMatrix)
    {
      int trace = 0;
      int sizeOfMatrix = sqMatrix.GetLength (0);

      for (int row = 0; row < sizeOfMatrix; ++row)
      {
        trace += sqMatrix[row, row];
      }

      return trace;
    }
  }
}
