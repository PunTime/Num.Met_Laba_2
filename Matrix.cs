using System;

public class Matrix
{
    public double[,] Data; // двовимірний масив (сама матриця)

    public int Rows => Data.GetLength(0); // кількість рядків
    public int Cols => Data.GetLength(1); // кількість стовпців

    // Конструктор для створення квадратної матриці n×n
    public Matrix(int n)
    {
        Data = new double[n, n];
    }

    // Конструктор для передачі готової матриці
    public Matrix(double[,] data)
    {
        Data = data;
    }

    // Множення матриці A на вектор v
    public static Vector Multiply(Matrix A, Vector v)
    {
        int n = A.Rows;
        double[] result = new double[n]; // результат множення

        // проходимо по рядках матриці
        for (int i = 0; i < n; i++)
            // обчислюємо скалярний добуток рядка на вектор
            for (int j = 0; j < A.Cols; j++)
                result[i] += A.Data[i, j] * v.Data[j];

        return new Vector(result); // повертаємо новий вектор
    }

    // Вивід матриці на екран
    public void Print(string name)
    {
        Console.WriteLine($"\n{name}:"); // назва матриці

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
                Console.Write($"{Data[i, j],10:F2}"); // форматований вивід
            Console.WriteLine();
        }
    }
}