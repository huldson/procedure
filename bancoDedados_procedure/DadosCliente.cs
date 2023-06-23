using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancoDedados_procedure
{
    public class DadosCliente
    {
        public int id { get; set; }
        public string telefone { get; set; }
       
        public string endereco { get; set; }

        public DadosCliente() { }
        public DadosCliente(string telefone, string endereco)
        {
           
            this.telefone = telefone;
            this.endereco = endereco;
        }
        public DadosCliente(string telefone, string endereco, int id)
        {
            this.id= id;
            this.telefone = telefone;
            this.endereco = endereco;
        }
    }
}
