using SistemaDePagamento.Models;
using SistemaDePagamento.Utils;

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
            Console.WriteLine("Encerrando o sistema. Ate logo!");
            return;
        default:
            Console.WriteLine("Opcao invalida. Tente novamente.");
            break;
    }

    Console.WriteLine();
}

static void ProcessarPagamentoCartao()
{
    decimal valor = InputHelper.LerValorMonetario("Informe o valor do pagamento:");
    string numeroCartao = InputHelper.LerTextoObrigatorio("Informe o numero do cartao:");

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
    string codigoBarras = InputHelper.LerTextoObrigatorio("Informe o codigo de barras:");

    var pagamento = new PagamentoBoleto
    {
        Valor = valor,
        DataProcessamento = DateTime.Now,
        CodigoBarras = codigoBarras
    };

    Console.WriteLine();
    Console.WriteLine(pagamento.ProcessarPagamento());
}
