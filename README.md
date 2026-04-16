# Sistema de Pagamento

Aplicacao console em C# desenvolvida para simular o processamento de pagamentos com Cartao e Boleto.

## Integrantes

Abner    - rm558468

Heloisa  - rm554535

Fernando - rm555201

Thomas   - rm554812

Eduardo  - rm556803


## Objetivo do Projeto

Permitir que o usuario escolha uma forma de pagamento, informe o valor e os dados especificos da operacao, e visualize um resumo do processamento diretamente no console.

## Tecnologias Utilizadas

- C#
- .NET
- Aplicacao Console

## Estrutura do Projeto

- `SistemaDePagamento/Program.cs`: fluxo principal da aplicacao
- `SistemaDePagamento/Models`: classes de dominio orientadas a objetos
- `SistemaDePagamento/Utils`: menu estatico e leitura/validacao dos dados

## Funcionalidades

- Menu principal com exibicao obrigatoria via `Menu.ExibirMenu()`
- Processamento de pagamento com Cartao
- Processamento de pagamento com Boleto
- Validacao de entrada para valores monetarios com virgula ou ponto
- Exibicao de resumo com valor formatado em `pt-BR` e data no formato `dd/MM/yyyy`

## Como Executar

1. Acesse a pasta raiz do projeto.
2. Execute o comando:

```bash
dotnet run --project .\SistemaDePagamento\SistemaDePagamento.csproj
```

3. Escolha a opcao desejada no menu.

## Exemplos de Uso

- Cartao:
  - `Processando pagamento de R$ 150,50 via Cartao (Numero: 1234-5678-9012-3456) na data 01/01/2025.`
- Boleto:
  - `Processando pagamento de R$ 150,50 via Boleto (Cod Barra: 1111111122222223333333344444444) na data 01/01/2025.`

## Evidencias de Teste

Os prints abaixo foram gerados a partir de execucoes reais do console com o comando:

```bash
dotnet run --project .\SistemaDePagamento\SistemaDePagamento.csproj
```

### Pagamento com Cartao usando virgula

![Pagamento com Cartao usando virgula](docs/evidencias/01-cartao-virgula.png)

### Pagamento com Cartao usando ponto

![Pagamento com Cartao usando ponto](docs/evidencias/02-cartao-ponto.png)

### Validacao de valor minimo

![Validacao de valor minimo](docs/evidencias/03-cartao-valor-minimo.png)

### Pagamento com Boleto usando milhar brasileiro

![Pagamento com Boleto usando milhar brasileiro](docs/evidencias/04-boleto-milhar-br.png)

### Pagamento com Boleto usando milhar internacional

![Pagamento com Boleto usando milhar internacional](docs/evidencias/05-boleto-milhar-internacional.png)

### Validacao de formatos invalidos e ambiguos

![Validacao de formatos invalidos e ambiguos](docs/evidencias/06-formatos-invalidos.png)

### Encerramento da aplicacao

![Encerramento da aplicacao](docs/evidencias/07-sair.png)
