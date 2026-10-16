// Exercício 1a - Classe Math: arredondamentos.
using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"Digite o {i}º número decimal: ");
            double numero;
            while (!double.TryParse(Console.ReadLine(), out numero)
                || double.IsNaN(numero) || double.IsInfinity(numero))
            {
                Console.Write("Número inválido. Digite novamente: ");
            }

            Console.WriteLine($"Original: {numero}");
            Console.WriteLine($"Arredondamento padrão: {Math.Round(numero)}");
            Console.WriteLine($"Para baixo: {Math.Floor(numero)}");
            Console.WriteLine($"Para cima: {Math.Ceiling(numero)}");
            Console.WriteLine($"Truncamento: {Math.Truncate(numero)}");
            Console.WriteLine();
        }
    }
}
