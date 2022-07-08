using Newtonsoft.Json;

namespace Desafio.Repositorio.Implementacao
{
    public class MusicaModel
    {
        [JsonProperty("track")]
        public PropriedadesModel Propriedades { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
