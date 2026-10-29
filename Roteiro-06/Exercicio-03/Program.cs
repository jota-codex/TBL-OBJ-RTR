// Exercício 3 - Entrada de número inteiro.
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Digite um número inteiro: ");

        try
        {
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine($"Número digitado: {numero}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Valor inválido. Por favor, digite um número inteiro.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Valor fora do intervalo permitido para um número inteiro.");
        }
    }
}
