using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Жёстко задаём x = 5.6 (как в условии)
        double x = 5.6;

        // Ввод y (принимаем как с запятой, так и с точкой)
        Console.Write("Введите y (например 2.5 или 2,5): ");
        string input = Console.ReadLine();
        double y;
        if (!double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out y)
            && !double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out y))
        {
            Console.WriteLine("Не удалось распознать число y. Используйте формат с точкой или запятой.");
            return;
        }

        // Интерпретация A: 1.87 * e * cos(x)
        double valueA = y - x - 5.0 + 1.87 * Math.E * Math.Cos(x) - Math.Cos(Math.Sin(x));

        // Интерпретация B: 1.87 * e^{cos(x)}  (вместо e * cos(x))
        double valueB = y - x - 5.0 + 1.87 * Math.Exp(Math.Cos(x)) - Math.Cos(Math.Sin(x));

        Console.WriteLine();
        Console.WriteLine($"Используется x = {x}");
        Console.WriteLine($"Введено y = {y}");
        Console.WriteLine();
        Console.WriteLine("Результаты (две интерпретации выражения):");
        Console.WriteLine($"A) y - x - 5 + 1.87 * e * cos(x) - cos(sin(x))  = {valueA}");
        Console.WriteLine($"B) y - x - 5 + 1.87 * e^(cos(x)) - cos(sin(x))   = {valueB}");
    }
}
