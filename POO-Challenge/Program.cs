using System.Globalization;
using System.Text;
using PooChallenge;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
if (args.Contains("--test")) { Testes.Executar(); return; }
if (args.Contains("--demo")) { Demonstrar(); return; }

var estacionamento = new Estacionamento();
while (true)
{
    Console.WriteLine($"\nESTACIONAMENTO | Vagas: {estacionamento.VagasDisponiveis}/5");
    Console.WriteLine("1 - Entrada\n2 - Saída\n3 - Veículos estacionados\n4 - Histórico de saídas\n0 - Encerrar");
    Console.Write("Opção: ");
    var opcao = Console.ReadLine();
    if (opcao is null or "0") break;
    try
    {
        switch (opcao)
        {
            case "1":
                var placa = Ler("Placa: ");
                var modelo = Ler("Modelo: ");
                Exibir(estacionamento.RegistrarEntrada(placa, modelo, LerHorario()));
                break;
            case "2":
                Exibir(estacionamento.RegistrarSaida(Ler("Placa: "), LerHorario()));
                break;
            case "3": Listar(estacionamento.Estacionados); break;
            case "4": Listar(estacionamento.Historico); break;
            default: Console.WriteLine("Opção inválida."); break;
        }
    }
    catch (Exception erro) when (erro is ArgumentException or InvalidOperationException or FormatException)
    { Console.WriteLine($"Não foi possível concluir: {erro.Message}"); }
}

static string Ler(string mensagem)
{
    Console.Write(mensagem);
    return Console.ReadLine() ?? "";
}

static DateTime LerHorario()
{
    var texto = Ler("Data e hora (dd/MM/aaaa HH:mm; Enter = agora): ");
    if (string.IsNullOrWhiteSpace(texto)) return DateTime.Now;
    if (DateTime.TryParseExact(texto, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture,
        DateTimeStyles.None, out var horario)) return horario;
    throw new FormatException("Informe uma data e hora válida no formato indicado.");
}

static void Listar(IReadOnlyList<Veiculo> veiculos)
{
    if (veiculos.Count == 0) Console.WriteLine("Nenhum veículo para exibir.");
    foreach (var veiculo in veiculos) Exibir(veiculo);
}

static void Exibir(Veiculo veiculo)
{
    Console.WriteLine($"\nPlaca: {veiculo.Placa} | Modelo: {veiculo.Modelo}\nEntrada: {veiculo.Entrada:dd/MM/yyyy HH:mm}");
    if (veiculo.Saida is { } saida)
    {
        var tempo = veiculo.Permanencia!.Value;
        Console.WriteLine($"Saída: {saida:dd/MM/yyyy HH:mm}\nPermanência: {tempo.Days} dia(s), {tempo.Hours}h {tempo.Minutes}min {tempo.Seconds}s");
        Console.WriteLine($"Horas cobradas: {veiculo.HorasCobradas} | Valor pago: {veiculo.ValorPago:C2}");
    }
    else Console.WriteLine("Situação: estacionado");
}

static void Demonstrar()
{
    var patio = new Estacionamento();
    var entrada = new DateTime(2026, 10, 15, 10, 0, 0);
    Exibir(patio.RegistrarEntrada("ABC-1234", "Fiat Uno", entrada));
    try { patio.RegistrarEntrada("abc1234", "Fiat Uno", entrada); }
    catch (InvalidOperationException erro) { Console.WriteLine($"Validação: {erro.Message}"); }
    for (int i = 1; i <= 4; i++) patio.RegistrarEntrada($"DEMO{i}", "Carro", entrada);
    Console.WriteLine($"Vagas disponíveis: {patio.VagasDisponiveis}");
    try { patio.RegistrarEntrada("EXTRA", "Carro", entrada); }
    catch (InvalidOperationException erro) { Console.WriteLine($"Validação: {erro.Message}"); }
    Exibir(patio.RegistrarSaida("ABC1234", entrada.AddMinutes(30)));
    Console.WriteLine($"Vagas após a saída: {patio.VagasDisponiveis}");
}
