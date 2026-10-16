// Exercício integrador - Cadastro de evento.
// Regra adotada, pois o enunciado não define a taxa: VIP tem 10%
// de desconto; Comum não tem desconto.
using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        CultureInfo cultura = new CultureInfo("pt-BR");
        CultureInfo.CurrentCulture = cultura;
        Console.Write("Nome do evento: ");
        string nome = (Console.ReadLine() ?? "").Trim();
        if (nome.Length == 0)
        {
            Console.WriteLine("Informe o nome do evento.");
            return;
        }

        Console.Write("Data do evento (dd/MM/yyyy): ");
        DateTime data;
        if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",
            cultura, DateTimeStyles.None, out data) || data.Date < DateTime.Today)
        {
            Console.WriteLine("Informe uma data válida que não esteja no passado.");
            return;
        }

        Console.Write("Valor do ingresso: ");
        decimal valor;
        if (!decimal.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        Console.Write("Categoria (VIP/Comum): ");
        string categoria = (Console.ReadLine() ?? "").Trim().ToUpper();
        // Delimitadores exigem uma opção completa, evitando aceitar 'VI'.
        if (categoria.Length == 0 || !"|VIP|COMUM|".Contains("|" + categoria + "|"))
        {
            Console.WriteLine("Categoria inválida. Use VIP ou Comum.");
            return;
        }

        int dias = (data.Date - DateTime.Today).Days;
        decimal taxa = categoria == "VIP" ? 0.10m : 0m;
        decimal desconto = Math.Round(valor * taxa, 2);
        decimal total = Math.Round(valor - desconto, 2);

        Console.WriteLine("\n========== INGRESSO ==========");
        Console.WriteLine(string.Format(cultura, "{0,-18} {1}", "Evento:", nome));
        Console.WriteLine(string.Format(cultura, "{0,-18} {1:dd/MM/yyyy}", "Data:", data));
        Console.WriteLine(string.Format(cultura, "{0,-18} {1}", "Categoria:", categoria));
        Console.WriteLine(string.Format(cultura, "{0,-18} {1} dias", "Faltam:", dias));
        Console.WriteLine(string.Format(cultura, "{0,-18} {1,12:C2}", "Valor original:", valor));
        Console.WriteLine(string.Format(cultura, "{0,-18} {1,12:P0}", "Desconto (%):", taxa));
        Console.WriteLine(string.Format(cultura, "{0,-18} {1,12:C2}", "Desconto:", desconto));
        Console.WriteLine(string.Format(cultura, "{0,-18} {1,12:C2}", "Valor final:", total));
        Console.WriteLine("==============================");
    }
}
