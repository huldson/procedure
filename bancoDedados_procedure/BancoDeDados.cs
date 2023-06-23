using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace bancoDedados_procedure
{
    public class BancoDeDados : IBancoDeDados
    {
        public SqlConnection conexao;
        public BancoDeDados()
        {
            this.conexao = new SqlConnection("Server=DESKTOP-BI33SL6;Database=CADASTRO;Trusted_Connection=True;Trust Server Certificate=true;");
        }

        public List<DadosCliente> Exbir()
        {
            conexao.Open();
            SqlCommand comandoexbir = new SqlCommand("select * from enderecoTelefone", this.conexao);

            SqlDataReader respostaExibir = comandoexbir.ExecuteReader();
            List<DadosCliente> clienteLista = new List<DadosCliente>();
            while (respostaExibir.Read())
            { DadosCliente cliente = new DadosCliente(respostaExibir["telefone"].ToString(), respostaExibir["endereco"].ToString());

                clienteLista.Add(cliente);
            }
            conexao.Close();
            return clienteLista;
        }

        public void Unificar()
        {
            int idsCadastrados = PegarQuantidade();
            string telefone;
            string endereco;
            int id;
            conexao.Open();
            SqlCommand comandoBuscarDados = new SqlCommand("buscarDados", this.conexao);
            SqlDataReader respostaDeDados = comandoBuscarDados.ExecuteReader();
            List<DadosCliente> listaDados = new List<DadosCliente>();
            while (respostaDeDados.Read())
            {
                telefone = respostaDeDados["telefone"].ToString();
                endereco = respostaDeDados["endereco"].ToString();
                id = int.Parse(respostaDeDados["entityID"].ToString());
                
                if (id > idsCadastrados)
                {
                    DadosCliente client = new DadosCliente(telefone, endereco);
                    listaDados.Add(client);
                  // incluirNaNovaTabela(telefone, endereco);

                }
            }
            conexao.Close();
            incluirNaNovaTabela(listaDados);
        }
        public int PegarQuantidade()
        {
            conexao.Open();
            SqlCommand comando = new SqlCommand("SELECT COUNT(*)FROM enderecoTelefone", this.conexao);
            int numero = (int)comando.ExecuteScalar();
            conexao.Close();
            return numero;
        }
        public void incluirNaNovaTabela(List<DadosCliente> lista){
            conexao.Open();
            foreach (DadosCliente cliente in lista)
            {
                SqlCommand comandoInserir = new SqlCommand("inserirDadosNovaTabela", this.conexao);
                comandoInserir.CommandType = System.Data.CommandType.StoredProcedure;
                comandoInserir.Parameters.AddWithValue("@telefone", cliente.telefone);
                comandoInserir.Parameters.AddWithValue("@endereco",cliente.endereco);
                comandoInserir.ExecuteScalar();
            }
            conexao.Close();
        }
    }
}
