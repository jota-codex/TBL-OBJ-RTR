// Exercício 2a - Operações com strings.
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Digite uma frase com palavras separadas por vírgulas: ");
        string frase = (Console.ReadLine() ?? "").Trim();
        Console.WriteLine($"Após Trim: {frase}");

        string[] palavras = frase.Split(',');
        Console.WriteLine("Partes da frase:");
        foreach (string palavra in palavras)
            Console.WriteLine(palavra.Trim());

        Console.Write("Palavra a substituir: ");
        string antiga = (Console.ReadLine() ?? "").Trim();
        Console.Write("Nova palavra: ");
        string nova = (Console.ReadLine() ?? "").Trim();
        if (antiga.Length > 0)
            frase = frase.Replace(antiga, nova);
        Console.WriteLine($"Após Replace: {frase}");

        Console.Write("Verificar se começa com: ");
        string inicio = (Console.ReadLine() ?? "").Trim();
        Console.Write("Verificar se termina com: ");
        string fim = (Console.ReadLine() ?? "").Trim();

        Console.WriteLine($"Começa com a palavra? {frase.StartsWith(inicio, StringComparison.OrdinalIgnoreCase)}");
        Console.WriteLine($"Termina com a palavra? {frase.EndsWith(fim, StringComparison.OrdinalIgnoreCase)}");
    }
}
