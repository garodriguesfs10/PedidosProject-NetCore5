using BackendPedido.Core.Entities;
using ProjetoPedidoOk.Core.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidoOk.Infrastructure.Persistence.DAL.Interface
{
    public interface IPedidoDAL
    {
        void SalvarPedido(Pedido pedido);
        void SalvarItens(List<Iten> itens);
        void SalvarPagamentos(List<Pagamento> pagamentos);

        List<RelatorioProdutosVendidos> ProdutosMaisVendidos();
        List<RelatorioVendasPorCidade> RelatorioVendasPorCidades();
        List<RelatorioVendasPorFaixaEtaria> RelatorioVendasPorFaixaEtaria();
        List<RelatorioPagamentos> RelatorioPagamentos();
    }
}
