using System;
using System.Numerics;

public class LUDecomposition
{
    public static void Solve()
    {
        Matrix A = new Matrix(new double[,]
        {
            {3, 2, 1},
            {3, 1, 4},
            {5, 8, 1}
        });

        Vector b = new Vector(new double[] { 10, 12, 18 });

        A.Print("A");
        b.Print("b");

        // ===== КРОК 1 =====
        Console.WriteLine("\n=== КРОК 1 ===");

        Matrix L1 = new Matrix(new double[,]
        {
            {1.0/3, 0, 0},
            {-1, 1, 0},
            {-5.0/3, 0, 1}
        });

        L1.Print("L1");

        Matrix A1 = Matrix.Multiply(L1, A);
        Vector b1 = Matrix.Multiply(L1, b);

        A1.Print("A1");
        b1.Print("b1");

        // ===== КРОК 2 =====
        Console.WriteLine("\n=== КРОК 2 ===");

        double a22 = A1.Data[1, 1];
        double a32 = A1.Data[2, 1];

        Matrix L2 = new Matrix(new double[,]
        {
            {1,0,0},
            {0,1.0/a22,0},
            {0,-a32/a22,1}
        });

        L2.Print("L2");

        Matrix A2 = Matrix.Multiply(L2, A1);
        Vector b2 = Matrix.Multiply(L2, b1);

        A2.Print("A2");
        b2.Print("b2");

        // ===== КРОК 3 =====
        Console.WriteLine("\n=== КРОК 3 ===");

        double a33 = A2.Data[2, 2];

        Matrix L3 = new Matrix(new double[,]
        {
            {1,0,0},
            {0,1,0},
            {0,0,1.0/a33}
        });

        L3.Print("L3");

        Matrix U = Matrix.Multiply(L3, A2);
        Vector B = Matrix.Multiply(L3, b2);

        U.Print("U");
        B.Print("B");

        // ===== ЗНАХОДИМО L =====
        Console.WriteLine("\n=== L ===");

        Matrix L = Matrix.Multiply(
                        Matrix.Multiply(
                            Matrix.InverseLower(L1),
                            Matrix.InverseLower(L2)),
                        Matrix.InverseLower(L3));

        L.Print("L");

        // ===== ЗВОРОТНІЙ ХІД =====
        Console.WriteLine("\n=== Розв’язок ===");

        double[] x = new double[3];

        for (int i = 2; i >= 0; i--)
        {
            double sum = 0;
            for (int j = i + 1; j < 3; j++)
                sum += U.Data[i, j] * x[j];

            x[i] = (B.Data[i] - sum) / U.Data[i, i];
        }

        Console.WriteLine("\nx:");
        foreach (var xi in x)
            Console.WriteLine($"{xi:F2}");
    }
}