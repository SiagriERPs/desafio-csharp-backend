using Desafio.Repositorio.Implementacao;
using Desafio.Retorno;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Desafio.Repositorio
{
    public class RepositorioPlaylist
    {

        public async Task<ConsultePlaylistRetorno> ObtenhaPlayList(ConsultePlaylistRequisicao requisicao)
        {
            Token.Autorizacao += "1";
            double temperatura = await ObtenhaTemperatura(requisicao);
            string estilo = ObtenhaEstiloMusical(temperatura);
            string play = await ObtenhaPlayList(estilo);
            return await ObtenhaMusicas(play);
        }

        private async Task<double> ObtenhaTemperatura(ConsultePlaylistRequisicao requisicao)
        {
            string filtro = ObtenhaFiltro(requisicao);
            string resultado = await Requisicao.ExecuteGet($"https://api.openweathermap.org/data/2.5/weather?{filtro}units=metric&appid=");

            CidadeModel retorno = JsonConvert.DeserializeObject<CidadeModel>(resultado);

            return retorno.Temperatura.Temperatura;

        }

        private string ObtenhaFiltro(ConsultePlaylistRequisicao requisicao)
        {
            if (!string.IsNullOrEmpty(requisicao.Cidade))
            {
                string cidade = Regex.Replace(requisicao.Cidade, "[^0-9a-zA-Z]+", "").ToLower();

                return $"q={cidade}&";
            }
            if (requisicao.latitude != null && requisicao.longitude != null)
            {
                return $"lat={requisicao.latitude!}&lon={requisicao.longitude!}&";
            }

            return string.Empty;
        }

        private string ObtenhaEstiloMusical(double temperatura)
        {
            if (temperatura >= 30)
            {
                return "party";
            }
            if (temperatura < 30 && temperatura >= 15)
            {
                return "pop";
            }
            if (temperatura < 15 && temperatura >= 10)
            {
                return "rock";
            }
            return "0JQ5DAqbMKFPrEiAOxgac3";
        }

        private async Task<string> ObtenhaPlayList(string estilo)
        {
            RetornoModel retorno = await RequisicaoPlayList(estilo);

            if (retorno == null)
            {
                await Token.ObtenhaNovoToken();

                retorno = await RequisicaoPlayList(estilo);
            }

            Random rng = new Random();

            int rand = rng.Next(retorno.PlayList.Musicas.Count);

            return retorno.PlayList.Musicas[rand].Id;
        }

        private async Task<RetornoModel> RequisicaoPlayList(string estilo)
        {
            string resultado = await Requisicao.ExecuteGet($"https://api.spotify.com/v1/browse/categories/{estilo}/playlists", Token.Autorizacao);

            return JsonConvert.DeserializeObject<RetornoModel>(resultado);
        }

        private async Task<ConsultePlaylistRetorno> ObtenhaMusicas(string playlist)
        {
            PlayListModel retorno = await RequisicaoMusicas(playlist);

            if (retorno == null)
            {
                await Token.ObtenhaNovoToken();

                retorno = await RequisicaoMusicas(playlist);
            }

            return new ConsultePlaylistRetorno()
            {
                Musicas = retorno.Musicas.Select(m => m.Propriedades.Nome)
            };
        }

        private async Task<PlayListModel> RequisicaoMusicas(string playlist)
        {
            string resultado = await Requisicao.ExecuteGet($"https://api.spotify.com/v1/playlists/{playlist}/tracks", Token.Autorizacao);

            return JsonConvert.DeserializeObject<PlayListModel>(resultado);
        }
    }
}
