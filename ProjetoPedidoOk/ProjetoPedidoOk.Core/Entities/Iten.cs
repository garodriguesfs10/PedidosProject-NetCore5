using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPedido.Core.Entities
{
    public class Iten
    {
        [Column("IdIten")]
        public string id { get; set; }
        public string idProduto { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }
        public decimal valorUnitario { get; set; }
        public int IdPedido { get; set; }

    }
}
