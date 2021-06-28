using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPedido.Core.Entities
{
    public class Pagamento
    {
        [Column("IdPagamento")]
        public string id { get; set; }
        public int parcela { get; set; }
        public decimal valor { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public int IdPedido { get; set; }
    }
}
