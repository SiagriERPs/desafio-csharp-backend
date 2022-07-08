using Newtonsoft.Json;

namespace Desafio.Repositorio.Implementacao
{
    public class TemperaturaModel
    {
        [JsonProperty("temp")]
        public double Temperatura { get; set; }
    }
}
