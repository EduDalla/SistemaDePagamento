using SistemaDePagamento.Models;
using SistemaDePagamento.Utils;

while (true)
{
    Menu.ExibirMenu();
    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "3":
            Console.WriteLine("Encerrando o sistema. Ate logo!");
            return;
        default:
            Console.WriteLine("Opcao indisponivel no momento. Tente novamente.");
            break;
    }

    Console.WriteLine();
}
