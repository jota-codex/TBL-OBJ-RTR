using System;
using System.Collections.Generic;

class Pagamento
{
    public virtual void ProcessarPagamento()
    {
        Console.WriteLine("Processando pagamento...");
    }
}

class CartaoCredito : Pagamento
{
    public override void ProcessarPagamento()
    {
        Console.WriteLine("Pagamento processado com Cartão de Crédito.");
    }
}

class BoletoBancario : Pagamento
{
    public override void ProcessarPagamento()
    {
        Console.WriteLine("Pagamento processado por Boleto Bancário.");
    }
}

class Pix : Pagamento
{
    public override void ProcessarPagamento()
    {
        Console.WriteLine("Pagamento processado via Pix.");
    }
}

class Program
{
    static void Main()
    {
        List<Pagamento> pagamentos = new List<Pagamento>();

        pagamentos.Add(new CartaoCredito());
        pagamentos.Add(new BoletoBancario());
        pagamentos.Add(new Pix());

        foreach (Pagamento pagamento in pagamentos)
        {
            pagamento.ProcessarPagamento();
        }
    }
}
