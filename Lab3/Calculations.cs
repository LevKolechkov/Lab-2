using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
  public delegate int[,] MatrixWithNumber(int[,] matrix, int number);
  public delegate int[,] MatrixWithMatrix(int[,] firstMatrix, int[,] secondMatrix);

  public class Calculations
  {
    public int[,] SumOfMatrixAndNumber(int[,] sqMatrix, int number)
    {
      int sizeOfMatrix = sqMatrix.GetLength(0);

      int[,] result = new int[sizeOfMatrix, sizeOfMatrix];

      for (int rowIndex = 0; rowIndex < sizeOfMatrix; ++rowIndex) 
      {
        for (int columnIndex = 0; columnIndex < sizeOfMatrix; ++columnIndex)
        {
          result[sizeOfMatrix, sizeOfMatrix] = sqMatrix[rowIndex, columnIndex] + number;
        }
      }

      return result;
    }

    public int[,] SumOfMatrixAndMatrix(int[,] firstMatrix, int[,] secondMatrix)
    {
      int sizeOfMatrix = firstMatrix.GetLength(0);

      int[,] result = new int[sizeOfMatrix, sizeOfMatrix];

      for (int rowIndex = 0; rowIndex < sizeOfMatrix; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < sizeOfMatrix; ++columnIndex)
        {
          result[rowIndex, columnIndex] = firstMatrix[rowIndex, columnIndex] + secondMatrix[rowIndex, columnIndex];
        }
      }

      return result;
    }

    public int[,] SubOfMatrixAndNumber(int[,] sqMatrix, int number)
    {
      int sizeOfMatrix = sqMatrix.GetLength(0);

      int[,] result = new int[sizeOfMatrix, sizeOfMatrix];

      for (int rowIndex = 0; rowIndex < sizeOfMatrix; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < sizeOfMatrix; ++columnIndex)
        {
          result[rowIndex, columnIndex] = sqMatrix[rowIndex, columnIndex] - number;
        }
      }

      return result;
    }

    public int[,] SubOfMatrixAndMatrix(int[,] firstMatrix, int[,] secondMatrix)
    {
      int sizeOfMatrix = firstMatrix.GetLength(0);

      int[,] result = new int[sizeOfMatrix, sizeOfMatrix];

      for (int rowIndex = 0; rowIndex < sizeOfMatrix; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < sizeOfMatrix; ++columnIndex)
        {
          result[rowIndex, columnIndex] = firstMatrix[rowIndex, columnIndex] - secondMatrix[rowIndex, columnIndex];
        }
      }

      return result;
    }
  }
}
