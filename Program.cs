using System;

class Program
{
    static void Main()
    {
        // Введення розміру матриці
        Console.Write("Введіть розмір квадратної матриці n: ");
        int n = int.Parse(Console.ReadLine());

        // Введення матриці A
        Matrix A = new Matrix(n);
        Console.WriteLine("Введіть матрицю A по рядках (через пробіл):");
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
                A.Data[i, j] = double.Parse(row[j]);
        }

        // Введення вектора b
        Vector b = new Vector(n);
        Console.WriteLine("Введіть вектор b (через пробіл):");
        string[] values = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
            b.Data[i] = double.Parse(values[i]);

        // Вивід введених даних
        Console.WriteLine("\n=== ВХІДНІ ДАНІ ===");
        A.Print("A");
        b.Print("b");

        // Покроковий LU-розклад
        LUDecomposition solver = new LUDecomposition(A, b);

        solver.SolveStepByStep();

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}