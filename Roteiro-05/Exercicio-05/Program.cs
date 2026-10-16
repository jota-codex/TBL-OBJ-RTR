// Exercício 3a - Tabela formatada de produtos.
using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
        string[] nomes = { "Caderno", "Caneta", "Mochila" };
        decimal[] precos = { 25.90m, 3.50m, 120.00m };
        int[] quantidades = { 2, 5, 1 };
        decimal subtotal = 0;
        decimal taxaDesconto = 0.10m;

        Console.WriteLine($"{"Produto",-20}{"Preço (R$)",12}{"Quantidade",12}{"Total",16}");
        Console.WriteLine(new string('-', 60));
        for (int i = 0; i < nomes.Length; i++)
        {
            decimal totalItem = precos[i] * quantidades[i];
            subtotal += totalItem;
            Console.WriteLine($"{nomes[i],-20}{precos[i],12:F2}{quantidades[i],12:N0}{totalItem,16:C2}");
        }

        decimal desconto = Math.Round(subtotal * taxaDesconto, 2);
        decimal totalFinal = subtotal - desconto;
        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"{"Subtotal:",-44}{subtotal,16:C2}");
        Console.WriteLine($"Desconto aplicado: {taxaDesconto:P0}");
        Console.WriteLine($"{"Desconto:",-44}{desconto,16:C2}");
        Console.WriteLine($"{"Total final:",-44}{totalFinal,16:C2}");
    }
}
