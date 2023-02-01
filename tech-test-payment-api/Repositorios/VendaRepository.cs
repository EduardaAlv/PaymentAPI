using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection.PortableExecutable;
using PaymentAPI.Enumeradores;
using PaymentAPI.Model;
using PaymentAPI.Utils;


namespace PaymentAPI.Repositorios
{
    public class VendaRepository
    {
        public List<Venda> GetVendas()
        {
            List<Venda> vendas = new List<Venda>();
            List<Produto> produtos = new List<Produto>();
            Vendedor vendedor = new Vendedor(1, "", "", "", "");
            Venda venda = new Venda(1, produtos, vendedor, Enumeradores.EnumStatusVenda.EnviadoParaTransportadora);

            string ConexaoPadrao = Utils.Utils.ObterStringConexao();

            using (SqlConnection connection = new SqlConnection(ConexaoPadrao))
            {
                connection.Open();
                using (SqlCommand comand = new SqlCommand("SELECT V.ID, V.VENDEDOR_ID, VEN.CPF, VEN.NOME, VEN.EMAIL, VEN.TELEFONE, V.VENDA_STATUS FROM VENDA V INNER JOIN VENDEDOR VEN ON VEN.CPF = V.VENDEDOR_ID", connection))
                {
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            venda.Id = Convert.ToInt32(reader["ID"]);
                            venda.Vendedor.Id = Convert.ToInt32(reader["VENDEDOR_ID"]);
                            venda.Vendedor.CPF = Convert.ToString(reader["CPF"]);
                            venda.Vendedor.Nome = Convert.ToString(reader["NOME"]);
                            venda.Vendedor.Email = Convert.ToString(reader["EMAIL"]);
                            venda.Vendedor.Telefone = Convert.ToString(reader["TELEFONE"]);
                            int statusVenda = Convert.ToInt32(reader["VENDA_STATUS"]);
                            venda.StatusVenda = Utils.Utils.ToEnum<EnumStatusVenda>(statusVenda);
                            vendas.Add(venda);
                        }

                    }
                }
            }

            return vendas;
        }

        public Venda ProcurarVenda(int idVenda)
        {
            List<Produto> produtos = new List<Produto>();
            Vendedor vendedor = new Vendedor(1, "", "", "", "");
            Venda venda = new Venda(1, produtos, vendedor, Enumeradores.EnumStatusVenda.EnviadoParaTransportadora);

            string ConexaoPadrao = Utils.Utils.ObterStringConexao();

            using (SqlConnection connection = new SqlConnection(ConexaoPadrao))
            {
                connection.Open();
                using (SqlCommand comand = new SqlCommand("SELECT V.ID, V.VENDEDOR_ID, VEN.CPF, VEN.NOME, VEN.EMAIL, VEN.TELEFONE, V.VENDA_STATUS FROM VENDA V INNER JOIN VENDEDOR VEN ON VEN.CPF = V.VENDEDOR_ID WHERE V.ID = @ID", connection))
                {
                    comand.CommandType = CommandType.Text;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.Value = idVenda;
                    comand.Parameters.Add(param);

                    using (SqlDataReader reader = comand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venda.Id = Convert.ToInt32(reader["ID"]);
                            venda.Vendedor.Id = Convert.ToInt32(reader["VENDEDOR_ID"]);
                            venda.Vendedor.CPF = Convert.ToString(reader["CPF"]);
                            venda.Vendedor.Nome = Convert.ToString(reader["NOME"]);
                            venda.Vendedor.Email = Convert.ToString(reader["EMAIL"]);
                            venda.Vendedor.Telefone = Convert.ToString(reader["TELEFONE"]);
                            int statusVenda = Convert.ToInt32(reader["VENDA_STATUS"]);
                            venda.StatusVenda = Utils.Utils.ToEnum<EnumStatusVenda>(statusVenda);
                        }
                    }
                }
            }
            return venda;
        }

        public string InserirVenda(string cpfVendedor)
        {
            string ConexaoPadrao = Utils.Utils.ObterStringConexao();

            using (SqlConnection connection = new SqlConnection(ConexaoPadrao))
            {
                connection.Open();
                using (SqlCommand comand = new SqlCommand("INSERT INTO VENDA (VENDEDOR_ID) VALUES(@CPF)", connection))
                {
                    comand.CommandType = CommandType.Text;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@CPF";
                    param.Value = cpfVendedor;
                    comand.Parameters.Add(param);
                    comand.ExecuteNonQuery();
                }
            }

            return "Venda incluída para o vendedor com número de cpf: " + cpfVendedor.ToString();
        }

        public Venda AtualizarVenda(Venda venda)
        {
            string ConexaoPadrao = Utils.Utils.ObterStringConexao();

            using (SqlConnection connection = new SqlConnection(ConexaoPadrao))
            {
                connection.Open();
                using (SqlCommand comand = new SqlCommand("UPDATE VENDA SET VENDA_STATUS = @VENDA_STATUS, VENDEDOR_ID = @VENDEDOR_ID WHERE ID = @ID", connection))
                {
                    comand.CommandType = CommandType.Text;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@VENDA_STATUS";
                    param.Value = Convert.ToInt32(venda.StatusVenda);
                    comand.Parameters.Add(param);
                    param.ParameterName = "@VENDEDOR_ID";
                    param.Value = venda.Vendedor.CPF;
                    comand.Parameters.Add(param);
                    param.ParameterName = "@ID";
                    param.Value = venda.Id;
                    comand.Parameters.Add(param);
                    comand.ExecuteNonQuery();
                }
            }

            return venda;
        }

        public string ExcluirVenda(int idVenda)
        {
            string ConexaoPadrao = Utils.Utils.ObterStringConexao();

            using (SqlConnection connection = new SqlConnection(ConexaoPadrao))
            {
                connection.Open();
                using (SqlCommand comand = new SqlCommand("DELETE FROM VENDA WHERE ID = @ID", connection))
                {
                    comand.CommandType = CommandType.Text;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.Value = idVenda;
                    comand.Parameters.Add(param);
                    comand.ExecuteNonQuery();
                }
            }

            return "Venda número " + idVenda.ToString() + "excluída";
        }
    }
}




