namespace PooChallenge;

internal static class Testes
{
    public static void Executar()
    {
        int total = 0;
        var inicio = new DateTime(2026, 10, 15, 10, 0, 0);
        void Conferir(bool condicao, string nome)
        {
            if (!condicao) throw new Exception($"FALHOU: {nome}");
            Console.WriteLine($"OK: {nome}"); total++;
        }
        void Rejeitar(Action acao, string nome)
        {
            bool rejeitada = false;
            try { acao(); }
            catch (Exception erro) when (erro is ArgumentException or InvalidOperationException)
            { rejeitada = true; }
            Conferir(rejeitada, nome);
        }
        var patio = new Estacionamento();
        Rejeitar(() => patio.RegistrarEntrada(" ", "Uno", inicio), "placa vazia");
        Rejeitar(() => patio.RegistrarEntrada("ABC1234", " ", inicio), "modelo vazio");
        var carro = patio.RegistrarEntrada(" abc-1234 ", "Uno", inicio);
        Conferir(carro.Placa == "ABC1234" && carro.Saida is null && carro.ValorPago == 0, "entrada normalizada");
        Rejeitar(() => patio.RegistrarEntrada("ABC1234", "Uno", inicio), "entrada duplicada");
        Rejeitar(() => patio.RegistrarSaida("ABC1234", inicio.AddSeconds(-1)), "saída anterior");
        Conferir(patio.VagasDisponiveis == 4 && carro.Saida is null && carro.ValorPago == 0, "erro preserva estado");
        patio.RegistrarSaida("ABC1234", inicio.AddMinutes(30));
        Conferir(carro.ValorPago == 10 && carro.Permanencia == TimeSpan.FromMinutes(30), "30 minutos custam 10 reais");
        Conferir(patio.Historico.Count == 1 && patio.VagasDisponiveis == 5, "histórico e vaga liberada");
        Rejeitar(() => patio.RegistrarSaida("ABC1234", inicio.AddHours(1)), "segunda saída");
        Rejeitar(() => patio.RegistrarSaida("INEXISTENTE", inicio), "placa inexistente");
        var nova = patio.RegistrarEntrada("ABC1234", "Uno", inicio.AddHours(1));
        Conferir(!ReferenceEquals(carro, nova) && carro.ValorPago == 10, "reentrada preserva histórico");
        for (int i = 0; i < 4; i++) patio.RegistrarEntrada($"TESTE{i}", "Carro", inicio);
        Rejeitar(() => patio.RegistrarEntrada("SEXTO", "Carro", inicio), "limite de cinco vagas");
        Conferir(patio.Estacionados.Count == 5 && patio.VagasDisponiveis == 0, "consulta de ocupação");
        patio.RegistrarSaida("TESTE0", inicio.AddHours(1));
        patio.RegistrarEntrada("SEXTO", "Carro", inicio);
        Conferir(patio.Estacionados.Count == 5, "reutilização de vaga");
        foreach (var caso in new[] { (0L, 10m), (1L, 10m), (TimeSpan.TicksPerHour, 10m),
            (TimeSpan.TicksPerHour + 1, 20m), (TimeSpan.TicksPerHour * 2, 20m), (TimeSpan.TicksPerHour * 25, 250m) })
        {
            var teste = new Estacionamento();
            teste.RegistrarEntrada("CALCULO", "Carro", inicio);
            Conferir(teste.RegistrarSaida("CALCULO", inicio.AddTicks(caso.Item1)).ValorPago == caso.Item2,
                $"cobrança para {caso.Item1} ticks = {caso.Item2}");
        }
        Conferir(typeof(Veiculo).GetProperty(nameof(Veiculo.ValorPago))!.SetMethod!.IsPrivate, "setter privado do pagamento");
        Console.WriteLine($"\n{total} verificações passaram.");
    }
}
