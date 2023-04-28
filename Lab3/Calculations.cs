using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
  public delegate int[,] MatrixWithNumber(int[,] matrix, int number);
  public delegate int[,] MatrixWithMatrix(int[,] MainMatrix, int[,] MinorMatrix);

  public class Calculations
  {
    int[,] MainMatrix { get; set; }
    int[,] MinorMatrix { get; set; }

    public Calculations(int[,] MainMatrix, int[,] MinorMatrix) 
    {
      this.MainMatrix = MainMatrix;
      this.MinorMatrix = MinorMatrix;
    }

    public int[,] SumOfMatrixAndNumber(int[,] MainMatrix, int number)
    {
      int sizeOfMatrix = MainMatrix.GetLength(0);

      int[,] result = new int[sizeOfMatrix, sizeOfMatrix];

      for (int rowIndex = 0; rowIndex < sizeOfMatrix; ++rowIndex) 
      {
        for (int columnIndex = 0; columnIndex < sizeOfMatrix; ++columnIndex)
        {
          result[rowIndex, columnIndex] = MainMatrix[rowIndex, columnIndex] + number;
        }
      }

      return result;
    }

    public int[,] SumOfMatrixAndMatrix(int[,] MainMatrix, int[,] MinorMatrix)
    {
      int sizeOfMatrix = MainMatrix.GetLength(0);

      int[,] result = new int[sizeOfMatrix, sizeOfMatrix];

      for (int rowIndex = 0; rowIndex < sizeOfMatrix; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < sizeOfMatrix; ++columnIndex)
        {
          result[rowIndex, columnIndex] = MainMatrix[rowIndex, columnIndex] + MinorMatrix[rowIndex, columnIndex];
        }
      }

      return result;
    }

    public int[,] SubOfMatrixAndNumber(int[,] MainMatrix, int number)
    {
      int sizeOfMatrix = MainMatrix.GetLength(0);

      int[,] result = new int[sizeOfMatrix, sizeOfMatrix];

      for (int rowIndex = 0; rowIndex < sizeOfMatrix; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < sizeOfMatrix; ++columnIndex)
        {
          result[rowIndex, columnIndex] = MainMatrix[rowIndex, columnIndex] - number;
        }
      }

      return result;
    }

    public int[,] SubOfMatrixAndMatrix(int[,] MainMatrix, int[,] MinorMatrix)
    {
      int sizeOfMatrix = MainMatrix.GetLength(0);

      int[,] result = new int[sizeOfMatrix, sizeOfMatrix];

      for (int rowIndex = 0; rowIndex < sizeOfMatrix; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < sizeOfMatrix; ++columnIndex)
        {
          result[rowIndex, columnIndex] = MainMatrix[rowIndex, columnIndex] - MinorMatrix[rowIndex, columnIndex];
        }
      }

      return result;
    }
  }
}
