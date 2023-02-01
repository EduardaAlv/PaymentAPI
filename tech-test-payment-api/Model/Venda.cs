using PaymentAPI.Enumeradores;
using PaymentAPI.EnumeradoresSeguros;

namespace PaymentAPI.Model
{
    public class Venda
    {
        public int Id { get; set; }
        public List<Produto> Vendas { get; set; }
        public Vendedor Vendedor { get; set; }

        public EnumStatusVenda StatusVenda {get; set;}

        public Venda(int id, List<Produto> vendas, Vendedor vendedor, EnumStatusVenda statusVenda)
        {
            Id = id;
            Vendas = vendas;
            Vendedor = vendedor;
            StatusVenda = statusVenda;
        }
    }
}
