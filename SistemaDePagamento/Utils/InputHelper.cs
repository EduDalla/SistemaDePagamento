using System.Globalization;

namespace SistemaDePagamento.Utils;

public static class InputHelper
{
    public static decimal LerValorMonetario(string mensagem)
    {
        while (true)
        {
            Console.Write($"{mensagem} ");
            string? entrada = Console.ReadLine();

            if (TryParseValorMonetario(entrada, out decimal valor) && valor > 0)
            {
                return valor;
            }

            Console.WriteLine("Valor invalido. Informe um numero maior que zero usando virgula ou ponto.");
        }
    }

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

    private static bool TryParseValorMonetario(string? entrada, out decimal valor)
    {
        valor = 0;

        if (string.IsNullOrWhiteSpace(entrada))
        {
            return false;
        }

        string valorNormalizado = entrada.Trim().Replace(" ", string.Empty);

        return decimal.TryParse(valorNormalizado, NumberStyles.Number, new CultureInfo("pt-BR"), out valor)
            || decimal.TryParse(valorNormalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out valor);
    }
}
