using System.Text;
using SistemaDePagamento.Models;
using SistemaDePagamento.Utils;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

while (true)
{
    Menu.ExibirMenu();
    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            ProcessarPagamentoCartao();
            break;
        case "2":
            ProcessarPagamentoBoleto();
            break;
        case "3":
            Console.WriteLine("Encerrando o sistema. Até logo!");
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine();
}

static void ProcessarPagamentoCartao()
{
    decimal valor = InputHelper.LerValorMonetario("Informe o valor do pagamento:");
    string numeroCartao = InputHelper.LerTextoObrigatorio("Informe o número do cartão:");

    var pagamento = new PagamentoCartao
    {
        Valor = valor,
        DataProcessamento = DateTime.Now,
        NumeroCartao = numeroCartao
    };

    Console.WriteLine();
    Console.WriteLine(pagamento.ProcessarPagamento());
}

static void ProcessarPagamentoBoleto()
{
    decimal valor = InputHelper.LerValorMonetario("Informe o valor do pagamento:");
    string codigoBarras = InputHelper.LerTextoObrigatorio("Informe o código de barras:");

    var pagamento = new PagamentoBoleto
    {
        Valor = valor,
        DataProcessamento = DateTime.Now,
        CodigoBarras = codigoBarras
    };

    Console.WriteLine();
    Console.WriteLine(pagamento.ProcessarPagamento());
}
