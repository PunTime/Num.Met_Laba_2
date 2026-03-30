using System;

// Клас для LU-розкладу та розв’язку СЛАР
public class LUDecomposition
{
    public Matrix L { get; private set; } // нижня трикутна матриця
    public Matrix U { get; private set; } // верхня трикутна матриця
    public Vector Y { get; private set; } // проміжний вектор (Ly = b)
    public Vector X { get; private set; } // розв’язок системи (Ux = y)

    private Matrix A; // початкова матриця
    private Vector b; // вектор правої частини

    public LUDecomposition(Matrix A, Vector b)
    {
        this.A = A;
        this.b = b;
    }

    // Виконання LU-розкладу та розв’язку
    public void Solve()
    {
        int n = A.Rows;

        double[,] Udata = new double[n, n]; // матриця U
        double[,] Ldata = new double[n, n]; // матриця L

        // Ініціалізація L як одиничної
        for (int i = 0; i < n; i++)
            Ldata[i, i] = 1.0;

        // ===== LU-розклад =====
        for (int k = 0; k < n; k++)
        {
            // формування k-го рядка U
            Udata[k, k] = A.Data[k, k];
            for (int j = k + 1; j < n; j++)
                Udata[k, j] = A.Data[k, j];

            // обчислення елементів L та оновлення A
            for (int i = k + 1; i < n; i++)
            {
                Ldata[i, k] = A.Data[i, k] / Udata[k, k]; // коефіцієнт
                for (int j = k + 1; j < n; j++)
                    A.Data[i, j] -= Ldata[i, k] * Udata[k, j]; // виключення
            }
        }

        // збереження результатів
        L = new Matrix(Ldata);
        U = new Matrix(Udata);

        // ===== Прямий хід: Ly = b =====
        double[] y = new double[n];
        for (int i = 0; i < n; i++)
        {
            double sum = 0;
            for (int j = 0; j < i; j++)
                sum += Ldata[i, j] * y[j];

            y[i] = b.Data[i] - sum; // обчислення y[i]
        }
        Y = new Vector(y);

        // ===== Зворотний хід: Ux = y =====
        double[] x = new double[n];
        for (int i = n - 1; i >= 0; i--)
        {
            double sum = 0;
            for (int j = i + 1; j < n; j++)
                sum += Udata[i, j] * x[j];

            x[i] = (y[i] - sum) / Udata[i, i]; // обчислення x[i]
        }
        X = new Vector(x);
    }

    // Вивід результатів
    public void PrintResults()
    {
        L.Print("L");
        U.Print("U");
        Y.Print("y");
        X.Print("x");
    }
}