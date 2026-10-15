namespace PooChallenge;

public sealed class Estacionamento
{
    public const int Capacidade = 5;
    public const decimal ValorPorHora = 10m;
    private readonly Dictionary<string, Veiculo> estacionados = new();
    private readonly List<Veiculo> historico = new();
    public int VagasDisponiveis => Capacidade - estacionados.Count;
    public IReadOnlyList<Veiculo> Estacionados => Array.AsReadOnly(estacionados.Values.ToArray());
    public IReadOnlyList<Veiculo> Historico => historico.AsReadOnly();

    public Veiculo RegistrarEntrada(string placa, string modelo, DateTime entrada)
    {
        var chave = Veiculo.NormalizarPlaca(placa);
        if (estacionados.ContainsKey(chave))
            throw new InvalidOperationException("Este veículo já está estacionado.");
        if (VagasDisponiveis == 0)
            throw new InvalidOperationException("Estacionamento lotado.");
        var veiculo = new Veiculo(chave, modelo, entrada);
        estacionados.Add(chave, veiculo);
        return veiculo;
    }

    public Veiculo RegistrarSaida(string placa, DateTime saida)
    {
        var chave = Veiculo.NormalizarPlaca(placa);
        if (!estacionados.TryGetValue(chave, out var veiculo))
            throw new InvalidOperationException("Veículo não encontrado no estacionamento.");
        veiculo.RegistrarSaida(saida);
        estacionados.Remove(chave);
        historico.Add(veiculo);
        return veiculo;
    }
}
