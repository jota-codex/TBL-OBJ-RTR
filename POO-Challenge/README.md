# POO Challenge — Sistema de Estacionamento

Aplicação de console em C# com entradas, saídas, cobrança, histórico e cinco vagas.

## Executar

Pré-requisito: **SDK .NET 8**. Na raiz do repositório:

```sh
dotnet run --project POO-Challenge
dotnet run --project POO-Challenge -- --demo
dotnet run --project POO-Challenge -- --test
```

Os comandos abrem, respectivamente, o menu, uma demonstração automática e os testes sem dependências externas. Datas manuais usam `dd/MM/aaaa HH:mm`; Enter usa o horário atual.

## Planejamento

| Classe | Responsabilidade |
|---|---|
| Veiculo | Representar uma permanência com placa, modelo, entrada, saída e pagamento |
| Estacionamento | Registrar entradas e saídas, controlar vagas e histórico |
| Program | Ler, validar formato de entrada e exibir os dados no console |

Placa, modelo e entrada têm apenas leitura. Saída e pagamento possuem alteração privada; o programa principal solicita operações ao estacionamento. O construtor e o registro de saída do veículo são internos ao projeto. Permanência e horas cobradas são calculadas. As coleções são expostas apenas para consulta.

Um dicionário de placas normalizadas armazena os veículos ativos. Uma lista guarda as permanências encerradas; uma reentrada cria outro objeto e preserva o histórico. Não é necessária herança para estas responsabilidades.

## Regras e decisões

- Placa e modelo não podem ser vazios. Placas ignoram maiúsculas/minúsculas, espaços e hífen; não é imposto formato nacional.
- A mesma placa não pode ter duas entradas ativas.
- Saída anterior à entrada é recusada sem modificar o estado ou liberar vaga.
- São cobrados R$ 10,00 por hora iniciada: 30 minutos = R$ 10,00; 60 minutos = R$ 10,00; 61 minutos = R$ 20,00. Como o enunciado só exemplifica a fração inferior a uma hora, adotou-se arredondamento de toda fração para cima. Permanência zero também recebe cobrança mínima de uma hora.
- Dinheiro usa decimal e limites de hora são calculados em ticks.
- A sexta entrada é recusada; uma saída válida libera a vaga.
- O histórico mostra placa, modelo, horários, tempo real, horas cobradas e pagamento.
- Dados ficam em memória e são perdidos ao encerrar. Os horários são locais.

## Apresentação de até três minutos

Execute `--demo`: entrada às 10:00, tentativa duplicada recusada, ocupação das cinco vagas, sexta entrada recusada e saída às 10:30 com cobrança de R$ 10,00 e vaga liberada. Use o menu para consultar veículos e histórico manualmente.

## Verificação

`--test` verifica validações, preservação do estado após erro, normalização, reentrada, histórico, lotação, reutilização de vaga, cobrança mínima e limites exatos de hora, além do setter privado do valor pago. Uma falha encerra com erro.

## Autoria e uso

Desenvolvido com assistência de IA. O enunciado proíbe esse recurso na competição; este material é uma referência de estudo e não deve ser apresentado como trabalho produzido sem assistência.
