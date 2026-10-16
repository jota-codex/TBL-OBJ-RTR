// Exercício 2b - Limpeza e formatação de CPF.
// Verifica o formato; não calcula os dígitos verificadores.
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Digite o CPF: ");
        string cpf = (Console.ReadLine() ?? "").Trim()
            .Replace(".", "").Replace("-", "").Replace(" ", "");

        if (cpf.Length != 11)
        {
            Console.WriteLine("O CPF deve conter exatamente 11 dígitos.");
            return;
        }

        // O enunciado não restringe o primeiro dígito: aceita de 0 a 9.
        bool inicioValido = false;
        for (int i = 0; i <= 9; i++)
            if (cpf.StartsWith(i.ToString()))
                inicioValido = true;

        bool apenasDigitos = true;
        foreach (char caractere in cpf)
            if (caractere < '0' || caractere > '9')
                apenasDigitos = false;

        if (!inicioValido || !apenasDigitos)
        {
            Console.WriteLine("O CPF deve conter somente dígitos de 0 a 9.");
            return;
        }

        string formatado = cpf.Substring(0, 3) + "."
            + cpf.Substring(3, 3) + "." + cpf.Substring(6, 3)
            + "-" + cpf.Substring(9, 2);
        Console.WriteLine($"CPF formatado: {formatado}");
    }
}
