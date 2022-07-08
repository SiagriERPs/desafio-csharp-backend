using Newtonsoft.Json;
using System.Collections.Generic;

namespace Desafio.Repositorio.Implementacao
{
    public class PlayListModel
    {
        [JsonProperty("items")]
        public List<MusicaModel> Musicas { get; set; }
    }
}
