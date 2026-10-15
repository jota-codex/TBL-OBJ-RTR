namespace PooChallenge;

public sealed class Veiculo
{
    public string Placa { get; }
    public string Modelo { get; }
    public DateTime Entrada { get; }
    public DateTime? Saida { get; private set; }
    public decimal ValorPago { get; private set; }
    public TimeSpan? Permanencia => Saida - Entrada;
    public decimal HorasCobradas => Permanencia is { } tempo
        ? Math.Max(1m, Math.Ceiling((decimal)tempo.Ticks / TimeSpan.TicksPerHour)) : 0m;

    internal Veiculo(string placa, string modelo, DateTime entrada)
    {
        Placa = NormalizarPlaca(placa);
        if (string.IsNullOrWhiteSpace(modelo))
            throw new ArgumentException("O modelo não pode ser vazio.");
        Modelo = modelo.Trim();
        Entrada = entrada;
    }

    internal static string NormalizarPlaca(string placa)
    {
        if (string.IsNullOrWhiteSpace(placa))
            throw new ArgumentException("A placa não pode ser vazia.");
        return placa.Trim().Replace("-", "").Replace(" ", "").ToUpperInvariant();
    }

    internal void RegistrarSaida(DateTime saida)
    {
        if (Saida.HasValue) throw new InvalidOperationException("O veículo já saiu.");
        if (saida < Entrada) throw new ArgumentException("A saída não pode ser anterior à entrada.");
        Saida = saida;
        ValorPago = HorasCobradas * Estacionamento.ValorPorHora;
    }
}
