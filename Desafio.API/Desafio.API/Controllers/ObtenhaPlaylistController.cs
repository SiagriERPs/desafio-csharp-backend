using Desafio.Consulte;
using Desafio.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObtenhaPlaylistController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ObtenhaPlaylist([FromBody] ConsultePlaylistRequisicao requisicao)
        {
            ConsultePlaylistRetorno retorno = await new ConsultePlaylist().Execute(requisicao);

            if (retorno.Musicas == null || !retorno.Musicas.Any())
            {
                return NoContent();
            }

            return Ok(retorno);
        }



    }
}
