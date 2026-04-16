using System.Globalization;

namespace SistemaDePagamento.Models;

public abstract class Pagamento
{
    public decimal Valor { get; set; }

    public DateTime DataProcessamento { get; set; }
    protected string FormatarValor()
    {
        return Valor.ToString("C", new CultureInfo("pt-BR"));
    }
    protected string FormatarData()
    {
        return DataProcessamento.ToString("dd/MM/yyyy");
    }

    public abstract string ProcessarPagamento();
}
