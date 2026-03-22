using System;

public class Vector
{
    public double[] Data;

    public Vector(double[] data)
    {
        Data = data;
    }

    public void Print(string name)
    {
        Console.WriteLine($"\n{name}:");
        foreach (var x in Data)
            Console.WriteLine($"{x:F2}");
    }
}