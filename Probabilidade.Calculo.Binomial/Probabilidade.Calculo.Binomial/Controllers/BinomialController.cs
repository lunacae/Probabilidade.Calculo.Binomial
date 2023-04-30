using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Probabilidade.Calculo.Binomial.Models;
using Probabilidade.Calculo.Binomial.Services;

namespace Probabilidade.Calculo.Binomial.Controllers
{
    [Route("api/binomial")]
    [ApiController]
    public class BinomialController : ControllerBase
    {
        private readonly ICalculoBinomialService CalculoBinomialService;

        public BinomialController(ICalculoBinomialService calculoBinomialService)
        {
            CalculoBinomialService = calculoBinomialService;
        }

        /// <summary>
        /// Calculo de binomial
        /// </summary>
        /// <param name="n">Número total de observações</param>
        /// <param name="x">Número de sucessos</param>
        /// <param name="p">Probabilidade de sucesso em valores absolutos</param>
        /// <returns></returns>
        [HttpGet("resultado")]
        //[ProducesResponseType(typeof(BinomialRetorno), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBinomial(
            [FromQuery] int n,
            [FromQuery] int x,
            [FromQuery] double p)
        {
            try
            {
                var retorno = CalculoBinomialService.GetResultado(n, x, p);
                return Ok(retorno);
            }
            catch(Exception e)
            {
                return BadRequest($"Error ao tentar calcular a fórmula de binomial, mensagem de erro: {e.Message}");
            }
        }
    }
}
