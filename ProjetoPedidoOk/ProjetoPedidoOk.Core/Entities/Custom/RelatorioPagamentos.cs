using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidoOk.Core.Entities.Custom
{
    public class RelatorioPagamentos
    {
        public DateTime dataCriacao { get; set; }
        public string nome{ get; set; }
        public decimal valorTotal{ get; set; }
    }
}
