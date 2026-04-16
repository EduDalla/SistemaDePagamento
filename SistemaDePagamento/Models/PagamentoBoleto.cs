namespace SistemaDePagamento.Models;

public class PagamentoBoleto : Pagamento
{
    public string CodigoBarras { get; set; } = string.Empty;

    public override string ProcessarPagamento()
    {
        return $"Processando pagamento de {FormatarValor()} via Boleto (Cod Barra: {CodigoBarras}) na data {FormatarData()}.";
    }
}
