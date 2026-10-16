// Exercício 1b - Investimento com juros compostos.
using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

        double capital = LerValor("Capital inicial: ");
        double taxa = LerValor("Taxa mensal (%): ") / 100;
        Console.Write("Número de meses: ");
        int meses;
        while (!int.TryParse(Console.ReadLine(), out meses) || meses < 0)
            Console.Write("Informe um número inteiro não negativo: ");

        double meta = LerValor("Meta de lucro: ");
        double montante = capital * Math.Pow(1 + taxa, meses);
        if (double.IsInfinity(montante) || double.IsNaN(montante))
        {
            Console.WriteLine("Os valores informados excedem o limite do cálculo.");
            return;
        }

        double lucro = montante - capital;
        Console.WriteLine($"Montante final: {montante:C2}");
        Console.WriteLine($"Lucro: {Math.Round(lucro, 2):C2}");
        Console.WriteLine($"Meta de lucro: {meta:C2}");
        Console.WriteLine(lucro > meta
            ? "O lucro supera a meta."
            : "O lucro não supera a meta.");
    }

    static double LerValor(string mensagem)
    {
        Console.Write(mensagem);
        double valor;
        while (!double.TryParse(Console.ReadLine(), out valor)
            || valor < 0 || double.IsNaN(valor) || double.IsInfinity(valor))
            Console.Write("Informe um valor não negativo: ");
        return valor;
    }
}
