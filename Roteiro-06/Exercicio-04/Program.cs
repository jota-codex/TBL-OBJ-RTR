// Exercício 4 - Exceção personalizada para idade.
using System;

public class IdadeInvalidaException : Exception
{
    public IdadeInvalidaException(string mensagem) : base(mensagem) { }
}

public class Program
{
    public static void VerificarIdade(int idade)
    {
        if (idade < 18)
            throw new IdadeInvalidaException("Idade mínima para acesso é 18 anos.");

        Console.WriteLine("Acesso permitido.");
    }

    public static void Main()
    {
        Console.Write("Digite a idade: ");

        try
        {
            int idade = int.Parse(Console.ReadLine());
            VerificarIdade(idade);
        }
        catch (IdadeInvalidaException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Digite uma idade válida.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Erro: Idade fora do intervalo permitido.");
        }
    }
}
