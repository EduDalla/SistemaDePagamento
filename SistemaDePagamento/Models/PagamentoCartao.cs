namespace SistemaDePagamento.Models;

public class PagamentoCartao : Pagamento
{
    public string NumeroCartao { get; set; } = string.Empty;

    public override string ProcessarPagamento()
    {
        return $"Processando pagamento de {FormatarValor()} via Cartão (Número: {NumeroCartao}) na data {FormatarData()}.";
    }
}
