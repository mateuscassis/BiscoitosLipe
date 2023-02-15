using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cadastros.api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("biscoitosLipe/v1/clientes/")]
    public class ClientesController : ControllerBase
    {
        private ICadastroService ServiceCadastrosConta;
        private IRelatorioService<ContaAtivoDTO> RelatorioService;

        public ClientesController(ICadastroService serviceCadastrosConta, IRelatorioService<ContaAtivoDTO> relatorioService)
        {
            this.ServiceCadastrosConta = serviceCadastrosConta;
            this.RelatorioService = relatorioService;
        }

        [HttpGet]
        [Route("listar/todos")]
        public async Task<IActionResult> GetAll([FromQuery] int page = ConstPaginacao.PAGINA_PADRAO, [FromQuery] int pageSize = ConstPaginacao.LIMITE_PADRAO)
        {
            try
            {
                return Ok(new { data = await this.RelatorioService.Get(page, pageSize) });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("listar/filtrado")]
        public async Task<IActionResult> GetFilter([FromQuery] FiltroContaAtivo? filtro,
            [FromQuery] int page = ConstPaginacao.PAGINA_PADRAO, [FromQuery] int pageSize = ConstPaginacao.LIMITE_PADRAO)
        {
            try
            {
                return Ok(new { data = await this.RelatorioService.GetFiltro((IFiltro<ContaAtivoDTO>?)filtro, page, pageSize) });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> Post([FromBody] PostContaAtivoDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return StatusCode((int)HttpStatusCode.Created, new { data = await this.ServiceCadastrosConta.PostBalanceAccount(model.Data) });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}