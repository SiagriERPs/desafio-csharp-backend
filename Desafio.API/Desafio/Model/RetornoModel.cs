using Newtonsoft.Json;

namespace Desafio.Repositorio.Implementacao
{
    public class RetornoModel
    {
        [JsonProperty("playlists")]
        public PlayListModel PlayList { get; set; }
    }
}
