using Newtonsoft.Json;

namespace Desafio.Repositorio.Implementacao
{
    public class PropriedadesModel
    {
        [JsonProperty("name")]
        public string Nome { get; set; }
    }
}
