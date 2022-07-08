using Newtonsoft.Json;

namespace Desafio.Repositorio.Implementacao
{
    public class CidadeModel
    {
        [JsonProperty("main")]
        public TemperaturaModel Temperatura { get; set; }
    }
}
