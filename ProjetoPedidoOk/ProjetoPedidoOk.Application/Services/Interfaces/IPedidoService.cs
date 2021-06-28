using BackendPedido.Core.Entities;
using ProjetoPedidoOk.Application.ViewModels;
using ProjetoPedidoOk.Core.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidoOk.Application.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<List<HomeScreenViewModel>> GetPedidos();     

        List<RelatorioProdutosVendidos> RelatorioProdutosMaisVendidos();
        List<RelatorioVendasPorCidade> RelatorioVendasPorCidade();
        List<RelatorioVendasPorFaixaEtaria> RelatorioVendasPorFaixaEtaria();
        List<RelatorioPagamentos> RelatorioPagamentos();
    }
}
