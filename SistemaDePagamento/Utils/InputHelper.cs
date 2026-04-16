namespace SistemaDePagamento.Utils;

public static class InputHelper
{
    public static string LerTextoObrigatorio(string mensagem)
    {
        while (true)
        {
            Console.Write($"{mensagem} ");
            string? entrada = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                return entrada.Trim();
            }

            Console.WriteLine("Campo obrigatorio. Tente novamente.");
        }
    }
}
