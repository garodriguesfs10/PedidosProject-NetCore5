using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPedido.Core.Entities
{
    public class Pedido
    {
        [Column("IdPedido")]
        public string id { get; set; }
        public int numero { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAlteracao { get; set; }
        public string status { get; set; }
        public decimal desconto { get; set; }
        public decimal frete { get; set; }
        public decimal subTotal { get; set; }
        public decimal valorTotal { get; set; }      
      
        public string IdCliente { get; set; }
        public string IdEnderecoEntrega { get; set; }
        [NotMapped]
        public  Cliente Cliente { get; set; }
        [NotMapped]
        public  List<Iten> Itens { get; set; }
        [NotMapped]
        public  EnderecoEntrega EnderecoEntrega { get; set; }
        [NotMapped]
        public  List<Pagamento> Pagamento { get; set; }       


    }
}
