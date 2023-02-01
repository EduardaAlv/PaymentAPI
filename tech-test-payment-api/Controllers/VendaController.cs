using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using PaymentAPI.Model;
using PaymentAPI.Repositorios;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : Controller
    {
        [HttpGet("ObterVendas")]
        public IActionResult ObterVendas()
        {
            VendaRepository vendaRepository = new VendaRepository();
            List<Venda> vendas = vendaRepository.GetVendas();
             
            return Ok(vendas);
        }

        [HttpGet("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            VendaRepository vendaRepository = new VendaRepository();
            Venda venda = vendaRepository.ProcurarVenda(id);

            return Ok(venda);
        }

        [HttpPost("AdicionarVenda")]
        public IActionResult AdicionarVenda(string cpfVendedor)
        {
            VendaRepository vendaRepository = new VendaRepository();
            string vendedor = vendaRepository.InserirVenda(cpfVendedor);

            return Ok(vendedor);
        }

        [HttpPut("AtualizarVenda")]
        public IActionResult AtualizarVenda(Venda venda)
        {
            List<Venda> vendas = new List<Venda>();
            var vendaBanco = vendas.Find(x => x.Id == venda.Id);
            if(vendaBanco != null)
            {
                return NotFound();
            }
            vendas.Add(venda);
            return Ok(venda);
        }


        [HttpDelete("Deletar{id}")]
        public IActionResult DeletarVenda(int id)
        {
            List<Venda> vendas = new List<Venda>();

            var vendaBanco = vendas.Find(x => x.Id == id);

            if (vendaBanco != null)
            {
                return NotFound();
            }
            else
            {
                vendas.Remove(vendaBanco);
            }
            return Ok();
        }

    }
}
