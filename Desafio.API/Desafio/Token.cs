using Desafio.Repositorio.Implementacao;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Desafio
{
    public static class Token
    {
        [JsonProperty("access_token")]
        public static string Autorizacao { get; set; }

        internal async static Task ObtenhaNovoToken()
        {
            string resposta = await Requisicao.ExecutePost();

            if (!string.IsNullOrEmpty(resposta))
            {
                TokenModel token = JsonConvert.DeserializeObject<TokenModel>(resposta);
                Autorizacao = token.Token;
            }
        }
    }
}
