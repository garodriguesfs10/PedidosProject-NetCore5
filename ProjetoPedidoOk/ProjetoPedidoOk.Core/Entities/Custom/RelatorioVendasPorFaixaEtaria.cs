using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidoOk.Core.Entities.Custom
{
    public class RelatorioVendasPorFaixaEtaria
    {
        public string faixaetaria { get; set; }
        public decimal  valorTotal { get; set; }

        public int quantidade { get; set; }
    }
}
