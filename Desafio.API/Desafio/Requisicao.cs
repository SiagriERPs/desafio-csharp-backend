using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Desafio
{
    public static class Requisicao
    {
        public static async Task<string> ExecuteGet(string requisicao, string bearer = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requisicao);
            HttpClient client = new HttpClient();
            if (!string.IsNullOrEmpty(bearer))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
            }
            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "";
        }

        public static async Task<string> ExecutePost()
        {
            RestClient client = new RestClient("https://accounts.spotify.com/api/token");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "__Host-device_id=AQDXnXGiMK9maVqY_0NWaW6VLLLVbvde6MEm0KJ1vZrwLQRKN4iJpRG-ZVS0PGgGZTbfw2P50ryGyFARXqVcuKClZR3Dvctm9_E; __Secure-TPASESSION=AQCTYZBEd0JlAG7APpfjXc9QlELvRBSoipmxnTg5Vs2huD8zG3ffTl4+8yiOviUJ5SML+30xjwjNz6Sg/v/WmPZvMWNR660WO+8=; sp_sso_csrf_token=013acda719191be70f39234b492f12d0774cc2fed331363537323334333336353733; sp_tr=false");
            request.AddParameter("refresh_token", "");
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("client_id", "");
            request.AddParameter("redirect_uri", "https://oauth.pstm.io/v1/browser-callback");
            request.AddParameter("client_secret", "");

            return (await client.ExecuteAsync(request))?.Content;
        }
    }
}
