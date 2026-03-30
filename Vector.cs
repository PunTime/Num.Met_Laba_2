using System;

// Клас для роботи з вектором
public class Vector
{
    public double[] Data; // масив елементів вектора

    // Конструктор для створення вектора заданого розміру
    public Vector(int size)
    {
        Data = new double[size];
    }

    // Конструктор для передачі готового масиву
    public Vector(double[] data)
    {
        Data = data;
    }

    // Вивід вектора на екран
    public void Print(string name)
    {
        Console.WriteLine($"\n{name}:"); // назва вектора

        foreach (var x in Data)
            Console.WriteLine($"{x:F2}"); // вивід елементів
    }
}