using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancoDedados_procedure
{
    public interface IBancoDeDados
    {
        public List<DadosCliente> Exbir();
        public void Unificar();
        public int PegarQuantidade();
        public void incluirNaNovaTabela(List<DadosCliente> lista);
    }
}
