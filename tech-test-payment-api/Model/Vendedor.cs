namespace PaymentAPI.Model
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Vendedor(int id, string cpf, string nome, string email, string telefone)
        {
            Id = id;
            CPF = cpf;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

    }
}
