using BackendPedido.Core.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoPedidoOk.Core.Entities.Custom;
using ProjetoPedidoOk.Infrastructure.Persistence.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjetoPedidoOk.Infrastructure.Persistence.DAL.Implementation
{

    public class PedidoDAL : IPedidoDAL
    {
        private readonly PedidoDbContext _pedidoDbContext;
        public PedidoDAL(PedidoDbContext pedidoDbContext)
        {
            _pedidoDbContext = pedidoDbContext;
        }

        public void SalvarItens(List<Iten> itens)
        {
            var context = _pedidoDbContext;

            foreach (var item in itens)
            {
                var command = context.Database.GetDbConnection().CreateCommand();

                command.CommandText = "PROC_I_ITENS_PEDIDO";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@id", item.id));
                command.Parameters.Add(new SqlParameter("@idProduto", item.idProduto));
                command.Parameters.Add(new SqlParameter("@nome", item.nome));
                command.Parameters.Add(new SqlParameter("@quantidade", item.quantidade));
                command.Parameters.Add(new SqlParameter("@valorUnitario", item.valorUnitario));
                command.Parameters.Add(new SqlParameter("@IdPedido", item.IdPedido));

                context.Database.OpenConnection();

                command.ExecuteNonQuery();
                context.Database.CloseConnection();
            }

        }

        public List<RelatorioVendasPorFaixaEtaria> RelatorioVendasPorFaixaEtaria()
        {
            try
            {
                var context = _pedidoDbContext;
                var command = context.Database.GetDbConnection().CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PROC_S_RELATORIO_IDADE";

                context.Database.OpenConnection();

                var listaRelatorio = new List<RelatorioVendasPorFaixaEtaria>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new RelatorioVendasPorFaixaEtaria();
                        item.faixaetaria = (string)reader.GetValue("faixa_idade");
                        item.valorTotal = (decimal)reader.GetValue("valorTotal");
                        item.quantidade = (int)reader.GetValue("quantidade");
                        listaRelatorio.Add(item);
                    }
                }

                context.Database.CloseConnection();

                return listaRelatorio;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RelatorioVendasPorCidade> RelatorioVendasPorCidades()
        {
            try
            {
                var context = _pedidoDbContext;
                var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "select b.cidade,count(*) as qtdVendas ,sum(a.valorTotal) as valorTotal from pedidos a inner join EnderecoEntregas b on a.IdEnderecoEntrega = b.IdEnderecoEntrega group by cidade order by qtdVendas desc";
                context.Database.OpenConnection();
                var listaRelatorio = new List<RelatorioVendasPorCidade>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new RelatorioVendasPorCidade();
                        item.nomeCidade = (string)reader.GetValue("cidade");
                        item.qtd = (int)reader.GetValue("qtdVendas");
                        item.valorTotal = (decimal)reader.GetValue("valorTotal");
                        listaRelatorio.Add(item);
                    }
                }

                context.Database.CloseConnection();

                return listaRelatorio;
            }
            catch (Exception er)
            {
                var listaRelatorio = new List<RelatorioVendasPorCidade>();
                return listaRelatorio;
            }
        }

        public List<RelatorioProdutosVendidos> ProdutosMaisVendidos()
        {
            try
            {
                var context = _pedidoDbContext;
                var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "select nome, sum(quantidade) as qtd, sum(valorUnitario) as valor  from itens group by idProduto,nome order by qtd desc";
                context.Database.OpenConnection();
                var listaRelatorio = new List<RelatorioProdutosVendidos>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new RelatorioProdutosVendidos();
                        item.nome = (string)reader.GetValue("nome");
                        item.qtd = (int)reader.GetValue("qtd");
                        item.valorTotal = (decimal)reader.GetValue("valor");
                        listaRelatorio.Add(item);
                    }
                }

                context.Database.CloseConnection();

                return listaRelatorio;
            }
            catch (Exception er)
            {
                var listaRelatorio = new List<RelatorioProdutosVendidos>();
                return listaRelatorio;
            }
        }

        public List<RelatorioPagamentos> RelatorioPagamentos()
        {
            try
            {
                var context = _pedidoDbContext;
                var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "select convert(date,dataCriacao) as dataCriacao ,b.nome, sum(b.valor) as valorTotal from pedidos a inner join Pagamentos b on a.numero = b.IdPedido group by dataCriacao,b.nome order by dataCriacao desc";
                context.Database.OpenConnection();
                var listaRelatorio = new List<RelatorioPagamentos>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new RelatorioPagamentos();
                        item.dataCriacao = (DateTime)reader.GetValue("dataCriacao");
                        item.nome = (string)reader.GetValue("nome");
                        item.valorTotal = (decimal)reader.GetValue("valorTotal");
                        listaRelatorio.Add(item);
                    }
                }

                context.Database.CloseConnection();

                return listaRelatorio;
            }
            catch (Exception er)
            {
                var listaRelatorio = new List<RelatorioPagamentos>();
                return listaRelatorio;
            }
        }

        public void SalvarPagamentos(List<Pagamento> pagamentos)
        {
            var context = _pedidoDbContext;

            foreach (var item in pagamentos)
            {
                var command = context.Database.GetDbConnection().CreateCommand();

                command.CommandText = "PROC_I_PAGAMENTOS_PEDIDO";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@id", item.id));
                command.Parameters.Add(new SqlParameter("@parcela", item.parcela));
                command.Parameters.Add(new SqlParameter("@valor", item.valor));
                command.Parameters.Add(new SqlParameter("@codigo", item.codigo));
                command.Parameters.Add(new SqlParameter("@nome", item.nome));
                command.Parameters.Add(new SqlParameter("@IdPedido", item.IdPedido));

                context.Database.OpenConnection();

                command.ExecuteNonQuery();
                context.Database.CloseConnection();
            }
        }

        public void SalvarPedido(Pedido pedido)
        {

            var context = _pedidoDbContext;
            var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "PROC_I_PEDIDO";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@id", pedido.id));
            command.Parameters.Add(new SqlParameter("@numero", pedido.numero));
            command.Parameters.Add(new SqlParameter("@dataCriacao", pedido.dataCriacao));
            command.Parameters.Add(new SqlParameter("@dataAlteracao", pedido.dataAlteracao));
            command.Parameters.Add(new SqlParameter("@status", pedido.status));
            command.Parameters.Add(new SqlParameter("@desconto", pedido.desconto));
            command.Parameters.Add(new SqlParameter("@frete", pedido.frete));
            command.Parameters.Add(new SqlParameter("@subtotal", pedido.subTotal));
            command.Parameters.Add(new SqlParameter("@valorTotal", pedido.valorTotal));
            command.Parameters.Add(new SqlParameter("@IdCliente", pedido.IdCliente));
            command.Parameters.Add(new SqlParameter("@IdEnderecoEntrega", pedido.IdEnderecoEntrega));

            // cliente
            command.Parameters.Add(new SqlParameter("@ccnpj", pedido.Cliente.cnpj));
            command.Parameters.Add(new SqlParameter("@ccpf", pedido.Cliente.cpf));
            command.Parameters.Add(new SqlParameter("@cnome", pedido.Cliente.nome));
            command.Parameters.Add(new SqlParameter("@crazacaoSocial", pedido.Cliente.razaoSocial));
            command.Parameters.Add(new SqlParameter("@cemail", pedido.Cliente.email));
            command.Parameters.Add(new SqlParameter("@cdataNascimento", pedido.Cliente.dataNascimento));

            //endereco Entrega
            command.Parameters.Add(new SqlParameter("@eendereco", pedido.EnderecoEntrega.endereco));
            command.Parameters.Add(new SqlParameter("@enumero", pedido.EnderecoEntrega.numero));
            command.Parameters.Add(new SqlParameter("@ecep", pedido.EnderecoEntrega.cep));
            command.Parameters.Add(new SqlParameter("@ebairro", pedido.EnderecoEntrega.bairro));
            command.Parameters.Add(new SqlParameter("@ecidade", pedido.EnderecoEntrega.cidade));
            command.Parameters.Add(new SqlParameter("@eestado", pedido.EnderecoEntrega.estado));
            command.Parameters.Add(new SqlParameter("@ecomplemento", pedido.EnderecoEntrega.complemento));
            command.Parameters.Add(new SqlParameter("@ereferencia", pedido.EnderecoEntrega.referencia));


            context.Database.OpenConnection();

            command.ExecuteNonQuery();
            context.Database.CloseConnection();
        }

       
    }
}
