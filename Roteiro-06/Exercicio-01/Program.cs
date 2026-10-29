// Exercício 1 - Validação de produto.
using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

        try
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto não pode ficar em branco.");

            Console.Write("Digite o preço do produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            if (preco <= 0)
                throw new ArgumentException("O preço do produto deve ser maior que zero.");

            Console.WriteLine($"Produto: {nome} - Preço: {preco:C}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Digite um preço válido.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Erro: O preço informado está fora do intervalo permitido.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
