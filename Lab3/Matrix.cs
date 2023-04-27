using Lab2;
using Project2;
using System;

namespace Lab_3
{
  delegate void DiagonalizeDelegate(int[,] sqMatrix);

  class SquareMatrix : ICloneable
  {
    public int SizeOfMatrix { get; set; }
    public int[,] sqMatrix;

    private BaseHandler eventHandler;

    public SquareMatrix(int sizeOfMatrix)
    {
      try
      {
        if (sizeOfMatrix <= 0)
        {
          throw new MatrixException("Размер дан неправильно");

        }
        SizeOfMatrix = sizeOfMatrix;

        Random random = new Random();

        sqMatrix = new int[sizeOfMatrix, sizeOfMatrix];

        for (int rowIndex = 0; rowIndex < SizeOfMatrix; ++rowIndex)
        {
          for (int columnIndex = 0; columnIndex < SizeOfMatrix; ++columnIndex)
          {
            sqMatrix[rowIndex, columnIndex] = random.Next(-1000, 1000);
          }
        }
      }

      catch (MatrixException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public void Run(int[,] sqMatrix, int[,] secondSqMatrix ,string message)
    {
      if (message == "Сумма матрицы и числа" || message == "Разница матрицы и числа")
      {
        switch (message)
        {
          case "Сумма матрицы и числа":
            Console.WriteLine("Введите число, которое будет прибавляться к матрице");
            int number = Int32.Parse(Console.ReadLine());

            ICalculateEvent eventOfMatrixAndNumber = new SumEvent(sqMatrix, number);

            HandleEvent(eventOfMatrixAndNumber);

            break;

          case "Сумма матрицы и матрицы":
            ICalculateEvent eventOfMatrixAndMatrix = new SumEvent(sqMatrix, secondSqMatrix);

            HandleEvent(eventOfMatrixAndMatrix);

            break;
        }
      }
      else
      {
        switch (message)
        {
          case "Разница матрицы и числа":
            Console.WriteLine("Введите число, которе будет отниматься от матрицы");
            int number = Int32.Parse(Console.ReadLine());

            ICalculateEvent eventOfMatrixAndNumber = new SubEvent(sqMatrix, number);

            HandleEvent(eventOfMatrixAndNumber);

            break;

          case "Разница матрицы и матрицы":
            ICalculateEvent eventOfMatrixAndMatrix = new SubEvent(sqMatrix, secondSqMatrix);

            HandleEvent(eventOfMatrixAndMatrix);

            break;
        }
      }  
    }

    private void HandleEvent(ICalculateEvent ev)
    {
      eventHandler.Handle(ev);
    }

    public DiagonalizeDelegate Diagonalizator { get; set; }
    public void Diagonalize()
    {
      Diagonalizator(sqMatrix);
    }

    public object Clone()
    {
      SquareMatrix sqMatrix = new SquareMatrix(SizeOfMatrix);
      sqMatrix.SizeOfMatrix = SizeOfMatrix;

      for (int rowIndex = 0; rowIndex < SizeOfMatrix; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < SizeOfMatrix; ++columnIndex)
        {
          sqMatrix.sqMatrix[rowIndex, columnIndex] = this.sqMatrix[rowIndex, columnIndex];
        }
      }
      return sqMatrix;
    }

    public int this[int rowIndex, int columnIndex]
    {
      get { return sqMatrix[rowIndex, columnIndex]; }
      set { sqMatrix[rowIndex, columnIndex] = value; }
    }

    public int GetSizeOfMatrix()
    {
      return SizeOfMatrix;
    }

    public override string ToString()
    {
      int length = GetSizeOfMatrix();

      string sqMatrix = "";

      for (int rowIndex = 0; rowIndex < length; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < length; ++columnIndex)
        {
          sqMatrix += this[rowIndex, columnIndex] + " ";
        }
      }
      return sqMatrix;
    }

    public override bool Equals(object obj)
    {
      try
      {
        if ((obj == null) || !GetType().Equals(obj.GetType()))
        {
          throw new ObjectException("Сравнение невозможно");
        }

        SquareMatrix anotherSqMatrix = ((SquareMatrix)obj).Clone() as SquareMatrix;

        if (GetSizeOfMatrix() != anotherSqMatrix.GetSizeOfMatrix())
        {
          throw new MatrixException("Размеры матриц не равны");
        }

        int length = GetSizeOfMatrix();

        for (int rowIndex = 0; rowIndex < length; ++rowIndex)
        {
          for (int columnIndex = 0; columnIndex < length; ++columnIndex)
          {
            if (this[rowIndex, columnIndex] != anotherSqMatrix[rowIndex, columnIndex])
            {
              return false;
            }
          }
        }
      }

      catch (ObjectException ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }

      catch (MatrixException ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
      return true;
    }

    public override int GetHashCode()
    {
      return int.Parse(ToString());
    }

    public int CompareTo(object obj)
    {
      if (obj == null)
      {
        throw new ObjectException("Матрица отсутсвует");
      }

      SquareMatrix sqMatrix = ((SquareMatrix)obj).Clone() as SquareMatrix;

      if (sqMatrix == null)
      {
        throw new ArgumentException("Один из элементов не является матрицей");
      }
      else
      {
        return this.Determinant().CompareTo(sqMatrix.Determinant());
      }
    }

    private static SquareMatrix MatrixDecompose(SquareMatrix aloneSqMatrix, out int[] swapArray, out int toggle)
    {
      int length = aloneSqMatrix.GetSizeOfMatrix();

      SquareMatrix sqMatrix = aloneSqMatrix.Clone() as SquareMatrix;

      swapArray = new int[length];

      for (int value = 0; value < length; ++value)
      {
        swapArray[value] = value;
      }

      toggle = 1;

      for (int mainValueCoordinate = 0; mainValueCoordinate < length - 1;)
      {
        int columnMax = Math.Abs(sqMatrix[mainValueCoordinate, mainValueCoordinate]);

        int permRow = mainValueCoordinate;

        for (int rowIndex = mainValueCoordinate + 1; rowIndex < length; ++rowIndex)
        {
          if (sqMatrix[rowIndex, mainValueCoordinate] > columnMax)
          {
            columnMax = sqMatrix[rowIndex, mainValueCoordinate];

            permRow = rowIndex;
          }
        }

        if (permRow != mainValueCoordinate)
        {
          for (int columnIndex = 0; columnIndex < length; ++columnIndex)
          {
            sqMatrix[permRow, columnIndex] = sqMatrix[mainValueCoordinate, columnIndex];
            sqMatrix[mainValueCoordinate, columnIndex] = sqMatrix[permRow, columnIndex];
          }
          swapArray[mainValueCoordinate] = swapArray[permRow];
          swapArray[permRow] = swapArray[mainValueCoordinate];
        }

        for (int rowIndex = mainValueCoordinate + 1; rowIndex < length; ++rowIndex)
        {
          sqMatrix[rowIndex, mainValueCoordinate] /= sqMatrix[mainValueCoordinate, mainValueCoordinate];
          for (int columnIndex = mainValueCoordinate + 1; columnIndex < length; ++columnIndex)
          {
            sqMatrix[rowIndex, columnIndex] -= sqMatrix[mainValueCoordinate, mainValueCoordinate] * sqMatrix[mainValueCoordinate, columnIndex];
          }
        }
      }
      return sqMatrix;
    }


    public int Determinant()
    {
      SquareMatrix sqMatrix = MatrixDecompose(this, out int[] perm, out int toggle);

      int length = sqMatrix.GetSizeOfMatrix();

      if (sqMatrix == null)
      {
        throw new MatrixException("Ошибка определения матрицы");
      }

      int result = toggle;

      for (int mainValueCoordinate = 0; mainValueCoordinate < length; ++mainValueCoordinate)
      {
        result *= sqMatrix[mainValueCoordinate, mainValueCoordinate];
      }

      return result;
    }

    public void Inverse()
    {
      int length = this.GetSizeOfMatrix();

      int[,] inverse  = new int[length, length];

      for (int rowIndex = 0; rowIndex < length; ++rowIndex)
      {
        int main = rowIndex;

        int max = Math.Abs(this[rowIndex, 0]);

        for (int columnIndex = rowIndex + 1; columnIndex < rowIndex; ++columnIndex)
        {
          int Abs = Math.Abs(this[rowIndex, columnIndex]);

          if (Abs > max)
          {
            main = columnIndex;

            max = Abs;
          }
        }

        if (main != rowIndex)
        {
          for (int columnIndex = 0; columnIndex < length; ++columnIndex)
          {
            int temp = this[rowIndex, columnIndex];
            this[rowIndex, columnIndex] = this[main, columnIndex];
            this[main, columnIndex] = temp;

            temp = inverse[rowIndex, columnIndex];
            inverse[rowIndex, columnIndex] = inverse[main, columnIndex];
            inverse[main, columnIndex] = temp;
          }
        }

        int mainValue = this[rowIndex, rowIndex];
        
        for (int columnIndex = rowIndex; columnIndex < length; ++columnIndex)
        {
          this[rowIndex, columnIndex] /= mainValue;
        }

        for (int columnIndex = 0; columnIndex < length; ++columnIndex)
        {
          if (columnIndex != rowIndex)
          {
            int factor = this[columnIndex, rowIndex];

            for (int thirdValue = rowIndex; thirdValue < length; ++thirdValue)
            {
              this[columnIndex, thirdValue] -= factor * inverse[rowIndex, thirdValue];
            }

            for (int thirdValue = 0; thirdValue < length; ++thirdValue)
            {
              inverse[columnIndex, rowIndex] -= factor * inverse[rowIndex, thirdValue];
            }
          }
        }
      }

    }

    public static SquareMatrix operator +(SquareMatrix aloneSqMatrix, int number)
    {
      SquareMatrix sumSqMatrix = aloneSqMatrix.Clone() as SquareMatrix;

      int length = sumSqMatrix.GetSizeOfMatrix();

      for (int rowIndex = 0; rowIndex < length; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < length; ++columnIndex)
        {
          sumSqMatrix[rowIndex, columnIndex] = number + aloneSqMatrix[rowIndex, columnIndex];
        }
      }
      return sumSqMatrix;
    }

    public static SquareMatrix operator +(int number, SquareMatrix aloneSqMatrix)
    {
      SquareMatrix sumSqMatrix = aloneSqMatrix.Clone() as SquareMatrix;

      int length = sumSqMatrix.GetSizeOfMatrix();

      for (int rowIndex = 0; rowIndex < length; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < length; ++columnIndex)
        {
          sumSqMatrix[rowIndex, columnIndex] = number + aloneSqMatrix[rowIndex, columnIndex];
        }
      }
      return sumSqMatrix;
    }

    public static SquareMatrix operator +(SquareMatrix firstSqMatrix, SquareMatrix secondSqMatrix)
    {
      SquareMatrix sumSqMatrix = secondSqMatrix.Clone() as SquareMatrix;

      int length = sumSqMatrix.GetSizeOfMatrix();

      for (int rowIndex = 0; rowIndex < length; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < length; ++columnIndex)
        {
          sumSqMatrix[rowIndex, columnIndex] = firstSqMatrix[rowIndex, columnIndex] + secondSqMatrix[rowIndex, columnIndex];
        }
      }
      return sumSqMatrix;
    }

    public static SquareMatrix operator *(SquareMatrix aloneSqMatrix, int number)
    {
      SquareMatrix mulSqMatrix = aloneSqMatrix.Clone() as SquareMatrix;

      int length = mulSqMatrix.GetSizeOfMatrix();

      for (int rowIndex = 0; rowIndex < length; ++rowIndex)
      {
        for (int columnIndex = 0; rowIndex < length; ++columnIndex)
        {
          mulSqMatrix[rowIndex, columnIndex] = aloneSqMatrix[rowIndex, columnIndex] * number;
        }
      }

      return mulSqMatrix;
    }

    public static SquareMatrix operator *(int number, SquareMatrix aloneSqMatrix)
    {
      SquareMatrix mulSqMatrix = aloneSqMatrix.Clone() as SquareMatrix;

      int length = mulSqMatrix.GetSizeOfMatrix();

      for (int rowIndex = 0; rowIndex < length; ++rowIndex)
      {
        for (int columnIndex = 0; rowIndex < length; ++columnIndex)
        {
          mulSqMatrix[rowIndex, columnIndex] = aloneSqMatrix[rowIndex, columnIndex] * number;
        }
      }

      return mulSqMatrix;
    }

    public static SquareMatrix operator *(SquareMatrix firstSqMatrix, SquareMatrix secondSqMatrix)
    {
      SquareMatrix mulSqMatrix = firstSqMatrix.Clone() as SquareMatrix;

      int length = mulSqMatrix.GetSizeOfMatrix();

      int thirdValue = 0;

      for (int rowIndex = 0; rowIndex < length; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < length; ++columnIndex)
        {
          for (int thirdIndex = 0; thirdIndex < length; ++thirdIndex)
          {
            thirdValue += firstSqMatrix[rowIndex, thirdIndex] * secondSqMatrix[thirdIndex, columnIndex];
          }

          mulSqMatrix[rowIndex, columnIndex] = thirdValue;
          thirdValue = 0;
        }
      }

      return mulSqMatrix;
    }

    public static bool operator <(SquareMatrix first, SquareMatrix second)
    {
      return first.Determinant() < second.Determinant();
    }

    public static bool operator >(SquareMatrix first, SquareMatrix second)
    {
      return first.Determinant() > second.Determinant();
    }

    public static bool operator <=(SquareMatrix first, SquareMatrix second)
    {
      return first.Determinant() <= second.Determinant();
    }

    public static bool operator >=(SquareMatrix first, SquareMatrix second)
    {
      return first.Determinant() >= second.Determinant();
    }

    public static bool operator== (SquareMatrix first, SquareMatrix second)
    {
      return first.Equals(second);
    }

    public static bool operator!= (SquareMatrix first, SquareMatrix second)
    {
      return !first.Equals(second);
    }

    public static bool operator true (SquareMatrix matrix)
    {
      return matrix.GetSizeOfMatrix() != 0;
    }

    public static bool operator false (SquareMatrix matrix) 
    {
      return matrix.GetSizeOfMatrix() == 0;
    }
  }
}