using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidoOk.Core.Entities.Custom
{
    public class RelatorioVendasPorCidade
    {
        public string nomeCidade { get; set; }
        public int qtd { get; set; }
        public decimal valorTotal { get; set; }
    }
}
