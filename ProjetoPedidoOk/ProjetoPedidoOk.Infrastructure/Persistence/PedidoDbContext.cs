using BackendPedido.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidoOk.Infrastructure.Persistence
{
    public class PedidoDbContext : DbContext
    {
        
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EnderecoEntrega> EnderecoEntregas { get; set; }
        public DbSet<Iten> Itens { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        

    }
}
