using Desafio.Repositorio;
using Desafio.Retorno;
using System.Threading.Tasks;

namespace Desafio.Consulte
{
    public class ConsultePlaylist
    {
        public Task<ConsultePlaylistRetorno> Execute(ConsultePlaylistRequisicao model)
        {
            ConsultePlaylistValidador validator = new ConsultePlaylistValidador();
            validator.Validate(model);
            return DoExecute(model);
        }

        protected Task<ConsultePlaylistRetorno> DoExecute(ConsultePlaylistRequisicao model) =>
             new RepositorioPlaylist().ObtenhaPlayList(model);
    }
}
