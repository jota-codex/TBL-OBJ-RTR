// Exercício 4 - Datas e calendários.
using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        CultureInfo cultura = new CultureInfo("pt-BR");
        Console.Write("Seu nome: ");
        string nome = (Console.ReadLine() ?? "").Trim();
        Console.Write("Data e hora do compromisso (dd/MM/yyyy HH:mm): ");
        DateTime compromisso;
        if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm",
            cultura, DateTimeStyles.None, out compromisso))
        {
            Console.WriteLine("Data ou hora inválida.");
            return;
        }

        DateTime agora = DateTime.Now;
        if (compromisso < agora)
        {
            Console.WriteLine("O compromisso informado já passou.");
            return;
        }

        // Diferença entre datas do calendário: amanhã equivale a um dia.
        int dias = (compromisso.Date - agora.Date).Days;
        string diaSemana = compromisso.ToString("dddd", cultura);
        string mensagem = string.Format(cultura,
            "Olá, {0}! Seu compromisso será em {1} dias, na {2}. Data marcada: {3:dd/MM/yyyy} às {3:HH:mm}",
            nome, dias, diaSemana, compromisso);
        Console.WriteLine(mensagem);
    }
}
