// Exercício 2 - Conversão de temperatura.
using System;
using System.Globalization;

public class Program
{
    public static float ConverterTemperatura(string entrada)
    {
        float temperatura = float.Parse(entrada);
        if (float.IsNaN(temperatura) || float.IsInfinity(temperatura))
            throw new FormatException("Digite uma temperatura válida.");

        return temperatura;
    }

    public static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

        while (true)
        {
            Console.Write("Digite a temperatura em Celsius: ");
            string entrada = Console.ReadLine();
            if (entrada == null)
                return;

            try
            {
                float temperatura = ConverterTemperatura(entrada);
                Console.WriteLine($"Temperatura: {temperatura} °C");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Temperatura inválida. Digite novamente.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Temperatura fora do intervalo permitido. Digite novamente.");
            }
        }
    }
}
