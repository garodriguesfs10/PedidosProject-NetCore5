using Microsoft.AspNetCore.Mvc;
using ProjetoPedidoOk.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPedidoOk.API.Controllers
{
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            var pedidos = await _pedidoService.GetPedidos();
            return Ok(pedidos);
        }
        

        [HttpGet]
        [Route("relatorio/produtosmaisvendidos")]
        public IActionResult RelatorioProdutosVendidos()
        {
            var pedidos = _pedidoService.RelatorioProdutosMaisVendidos();
            return Ok(pedidos);
        }

        [HttpGet]
        [Route("relatorio/vendasporcidade")]
        public IActionResult RelatorioVendasPorCidade()
        {
            var pedidos = _pedidoService.RelatorioVendasPorCidade();
            return Ok(pedidos);
        }

        [HttpGet]
        [Route("relatorio/vendasporfaixaetaria")]
        public IActionResult RelatorioVendasPorFaixaEtaria()
        {
            var pedidos = _pedidoService.RelatorioVendasPorFaixaEtaria();
            return Ok(pedidos);
        }

        [HttpGet]
        [Route("relatorio/pagamentos")]
        public IActionResult RelatorioPagamentos()
        {
            var pedidos = _pedidoService.RelatorioPagamentos();
            return Ok(pedidos);
        }


    }
}
