using Newtonsoft.Json;

namespace Desafio.Repositorio.Implementacao
{
    public class TokenModel
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
