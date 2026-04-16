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

            if (TryParseValorMonetario(entrada, out decimal valor))
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Informe um valor maior ou igual a 0,01, com até duas casas decimais. Exemplos: 150,50; 150.50; 1.500,50.");
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

            Console.WriteLine("Campo obrigatório. Tente novamente.");
        }
    }

    private static bool TryParseValorMonetario(string? entrada, out decimal valor)
    {
        valor = 0;

        if (string.IsNullOrWhiteSpace(entrada))
        {
            return false;
        }

        string valorInformado = entrada.Trim();

        if (!ContemApenasCaracteresMonetarios(valorInformado)
            || valorInformado[0] is '.' or ','
            || valorInformado[^1] is '.' or ',')
        {
            return false;
        }

        string? valorNormalizado = NormalizarValorMonetario(valorInformado);

        return valorNormalizado is not null
            && decimal.TryParse(valorNormalizado, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out valor)
            && valor >= 0.01m;
    }

    private static string? NormalizarValorMonetario(string valorInformado)
    {
        int quantidadeVirgulas = ContarCaracter(valorInformado, ',');
        int quantidadePontos = ContarCaracter(valorInformado, '.');

        if (quantidadeVirgulas == 0 && quantidadePontos == 0)
        {
            return TodosDigitos(valorInformado) ? valorInformado : null;
        }

        if (quantidadeVirgulas > 0 && quantidadePontos > 0)
        {
            return NormalizarComSeparadoresDecimalEMilhar(valorInformado);
        }

        char separador = quantidadeVirgulas > 0 ? ',' : '.';
        int quantidadeSeparadores = quantidadeVirgulas + quantidadePontos;

        return quantidadeSeparadores == 1
            ? NormalizarComSeparadorUnico(valorInformado, separador)
            : NormalizarComoMilhar(valorInformado, separador);
    }

    private static string? NormalizarComSeparadorUnico(string valorInformado, char separador)
    {
        int indiceSeparador = valorInformado.IndexOf(separador);
        string parteInteira = valorInformado[..indiceSeparador];
        string parteFinal = valorInformado[(indiceSeparador + 1)..];

        if (!TodosDigitos(parteInteira) || !TodosDigitos(parteFinal))
        {
            return null;
        }

        if (parteFinal.Length is 1 or 2)
        {
            return $"{parteInteira}.{parteFinal}";
        }

        if (parteFinal.Length == 3 && GrupoInicialMilharUnicoValido(parteInteira))
        {
            return parteInteira + parteFinal;
        }

        return null;
    }

    private static string? NormalizarComSeparadoresDecimalEMilhar(string valorInformado)
    {
        int ultimoIndiceVirgula = valorInformado.LastIndexOf(',');
        int ultimoIndicePonto = valorInformado.LastIndexOf('.');
        char separadorDecimal = ultimoIndiceVirgula > ultimoIndicePonto ? ',' : '.';
        char separadorMilhar = separadorDecimal == ',' ? '.' : ',';
        int indiceDecimal = Math.Max(ultimoIndiceVirgula, ultimoIndicePonto);

        string parteInteira = valorInformado[..indiceDecimal];
        string parteDecimal = valorInformado[(indiceDecimal + 1)..];

        if (parteInteira.Contains(separadorDecimal)
            || parteDecimal.Length is < 1 or > 2
            || !TodosDigitos(parteDecimal)
            || !ValidarParteInteiraComMilhar(parteInteira, separadorMilhar))
        {
            return null;
        }

        return RemoverSeparador(parteInteira, separadorMilhar) + "." + parteDecimal;
    }

    private static string? NormalizarComoMilhar(string valorInformado, char separador)
    {
        return ValidarGruposMilhar(valorInformado, separador)
            ? RemoverSeparador(valorInformado, separador)
            : null;
    }

    private static bool ValidarParteInteiraComMilhar(string parteInteira, char separadorMilhar)
    {
        if (string.IsNullOrEmpty(parteInteira))
        {
            return false;
        }

        if (!parteInteira.Contains(separadorMilhar))
        {
            return TodosDigitos(parteInteira);
        }

        return ValidarGruposMilhar(parteInteira, separadorMilhar);
    }

    private static bool ValidarGruposMilhar(string valor, char separador)
    {
        string[] grupos = valor.Split(separador);

        if (grupos.Length < 2 || !GrupoInicialMilharValido(grupos[0]))
        {
            return false;
        }

        for (int i = 1; i < grupos.Length; i++)
        {
            if (grupos[i].Length != 3 || !TodosDigitos(grupos[i]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool GrupoInicialMilharValido(string grupo)
    {
        return grupo.Length is >= 1 and <= 3
            && TodosDigitos(grupo)
            && grupo[0] != '0';
    }

    private static bool GrupoInicialMilharUnicoValido(string grupo)
    {
        return grupo.Length is 1 or 2
            && TodosDigitos(grupo)
            && grupo[0] != '0';
    }

    private static bool ContemApenasCaracteresMonetarios(string valor)
    {
        foreach (char caractere in valor)
        {
            if (!char.IsDigit(caractere) && caractere is not ('.' or ','))
            {
                return false;
            }
        }

        return true;
    }

    private static bool TodosDigitos(string valor)
    {
        if (valor.Length == 0)
        {
            return false;
        }

        foreach (char caractere in valor)
        {
            if (!char.IsDigit(caractere))
            {
                return false;
            }
        }

        return true;
    }

    private static int ContarCaracter(string valor, char caractere)
    {
        int quantidade = 0;

        foreach (char caractereAtual in valor)
        {
            if (caractereAtual == caractere)
            {
                quantidade++;
            }
        }

        return quantidade;
    }

    private static string RemoverSeparador(string valor, char separador)
    {
        return valor.Replace(separador.ToString(), string.Empty);
    }
}
