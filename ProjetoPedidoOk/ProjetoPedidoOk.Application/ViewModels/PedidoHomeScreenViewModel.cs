using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidoOk.Application.ViewModels
{
    public class HomeScreenViewModel
    {
        public HomeScreenViewModel(string status, string cpfCliente, int numeroVenda, decimal desconto, decimal frete, decimal subtotal, decimal total)
        {
            this.status = status;
            this.cpfCliente = cpfCliente;
            this.numeroVenda = numeroVenda;
            this.desconto = desconto;
            this.frete = frete;
            this.subtotal = subtotal;
            this.total = total;
        }

        public string status { get; private set; }
        public string cpfCliente { get; private set; }
        public int numeroVenda { get; private set; }
        public decimal desconto { get; private set; }
        public decimal frete { get; private set; }
        public decimal subtotal { get; private set; }
        public decimal total { get; private set; }
    }
}
