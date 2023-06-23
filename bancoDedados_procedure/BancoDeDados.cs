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
            { DadosCliente cliente = new DadosCliente(respostaExibir["telefone"].ToString(), respostaExibir["endereco"].ToString(), int.Parse(respostaExibir["entityXD"].ToString()));

                clienteLista.Add(cliente);
            }
            conexao.Close();
            foreach(DadosCliente elemento in clienteLista)
            {
                Console.WriteLine("id:"+elemento.id+" tel:"+elemento.telefone+" endereço:"+elemento.endereco );
            }
            return clienteLista;
        }

        public void Unificar()
        {
            
            conexao.Open();
            SqlCommand comandoBuscarDados = new SqlCommand("inserirDadosDeUmaVez", this.conexao);
            comandoBuscarDados.ExecuteReader();
           
            
            conexao.Close();
            
        }
        public int PegarQuantidade()
        {
            conexao.Open();
            SqlCommand comando = new SqlCommand("SELECT COUNT(*)FROM enderecoTelefone", this.conexao);
            int numero = (int)comando.ExecuteScalar();
            conexao.Close();
            return numero;
        }
        
    }
}
