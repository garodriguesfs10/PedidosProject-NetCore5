using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPedido.Core.Entities
{
    public class EnderecoEntrega
    {
        [Column("IdEnderecoEntrega")]
        public string id { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string complemento { get; set; }
        public string referencia { get; set; }
    }
}
