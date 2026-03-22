using System;

public class Matrix
{
    public double[,] Data;
    public int Rows => Data.GetLength(0);
    public int Cols => Data.GetLength(1);

    public Matrix(double[,] data)
    {
        Data = data;
    }

    public static Matrix Multiply(Matrix A, Matrix B)
    {
        int n = A.Rows;
        int m = B.Cols;
        int k = A.Cols;

        double[,] result = new double[n, m];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                for (int t = 0; t < k; t++)
                    result[i, j] += A.Data[i, t] * B.Data[t, j];

        return new Matrix(result);
    }

    public static Vector Multiply(Matrix A, Vector v)
    {
        int n = A.Rows;
        double[] result = new double[n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < A.Cols; j++)
                result[i] += A.Data[i, j] * v.Data[j];

        return new Vector(result);
    }

    public static Matrix InverseLower(Matrix L)
    {
        int n = L.Rows;
        double[,] inv = new double[n, n];

        for (int i = 0; i < n; i++)
            inv[i, i] = 1;

        for (int i = 1; i < n; i++)
            for (int j = 0; j < i; j++)
                inv[i, j] = -L.Data[i, j];

        return new Matrix(inv);
    }

    public void Print(string name)
    {
        Console.WriteLine($"\n{name}:");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
                Console.Write($"{Data[i, j],10:F2}");
            Console.WriteLine();
        }
    }
}