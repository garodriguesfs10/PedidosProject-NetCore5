using BackendPedido.Core.Entities;
using Newtonsoft.Json;
using ProjetoPedidoOk.Application.Services.Interfaces;
using ProjetoPedidoOk.Infrastructure.Persistence;
using ProjetoPedidoOk.Infrastructure.Persistence.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using ProjetoPedidoOk.Application.ViewModels;
using ProjetoPedidoOk.Core.Entities.Custom;

namespace ProjetoPedidoOk.Application.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private const string URLAPI = "https://desafiotecnicosti3.azurewebsites.net/pedido";
        private readonly PedidoDbContext _pedidoDbContext;
        private readonly IPedidoDAL _pedidoDal;

        public PedidoService(PedidoDbContext pedidoDbContext, IPedidoDAL pedidoDal)
        {
            _pedidoDbContext = pedidoDbContext;
            _pedidoDal = pedidoDal;
        }
        public async Task<List<HomeScreenViewModel>> GetPedidos()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = URLAPI;
                    var response = await httpClient.GetAsync(url);
                    var responseData = await response.Content.ReadAsStringAsync();
                    var pedidos = JsonConvert.DeserializeObject<List<Pedido>>(responseData);
                    MapData(pedidos);
                    await CheckIfExistsData(pedidos);
                    var dataViewModel = pedidos.Select(p => new HomeScreenViewModel(p.status, p.Cliente.cpf, p.numero,p.desconto,p.frete,p.subTotal,p.valorTotal)).ToList();
                    return dataViewModel;
                }
            }
            catch (Exception er)
            {
                var dataViewModel = new List<HomeScreenViewModel>();
                return dataViewModel;
            }
        }

        public static void MapData(List<Pedido> pedido)
        {
            foreach (var item in pedido)
            {
                foreach (var itens in item.Itens)
                {
                    itens.IdPedido = item.numero;
                }

                foreach (var pagamento in item.Pagamento)
                {
                    pagamento.IdPedido = item.numero;
                }

                item.IdEnderecoEntrega = item.EnderecoEntrega.id;
                item.IdCliente = item.Cliente.id;


            }
            return;
        }


        public async Task<int> CheckIfExistsData(List<Pedido> pedidos)
        {
            try
            {
                if (pedidos != null)
                {
                    foreach (var pedido in pedidos)
                    {
                        var existePedido = await _pedidoDbContext.Pedidos.FindAsync(pedido.id);
                        if (existePedido == null)
                        {
                            SalvarPedido(pedido);
                            SalvarItens(pedido.Itens);
                            SalvarPagamentos(pedido.Pagamento);
                        }

                    }
                }

                return 1;
            }
            catch (Exception er)
            {
                return 0;
            }

        }
        public void SalvarPedido(Pedido pedido)
        {
            _pedidoDal.SalvarPedido(pedido);

        }

        public void SalvarItens(List<Iten> itens)
        {
            _pedidoDal.SalvarItens(itens);
        }

        public void SalvarPagamentos(List<Pagamento> pagamentos)
        {
            _pedidoDal.SalvarPagamentos(pagamentos);
        }
              

        public List<RelatorioProdutosVendidos> RelatorioProdutosMaisVendidos()
        {
            var relatorio =  _pedidoDal.ProdutosMaisVendidos();
            return relatorio;
        }

        public List<RelatorioVendasPorCidade> RelatorioVendasPorCidade()
        {
            var relatorio = _pedidoDal.RelatorioVendasPorCidades();
            return relatorio;
        }

        public List<RelatorioVendasPorFaixaEtaria> RelatorioVendasPorFaixaEtaria()
        {
            var relatorio = _pedidoDal.RelatorioVendasPorFaixaEtaria();
            return relatorio;
        }

        public List<RelatorioPagamentos> RelatorioPagamentos()
        {
            var relatorio = _pedidoDal.RelatorioPagamentos();
            return relatorio;
        }
    }
}
