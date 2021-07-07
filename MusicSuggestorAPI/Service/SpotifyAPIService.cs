using Microsoft.Extensions.Configuration;
using MusicSuggestorAPI.Domain.Common;
using MusicSuggestorAPI.Domain.CustomException;
using MusicSuggestorAPI.Domain.Enuns;
using MusicSuggestorAPI.Domain.Interfaces.Repositorys;
using MusicSuggestorAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace MusicSuggestorAPI.Repositorys
{
    public class SpotifyAPIService : ISpotifyAPIService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private string _clientSpotifyId;
        private string _clientSpotifySecret;
        private string _clientSpotifyCode;
        private const string _spotifyTokenURI = "https://accounts.spotify.com/api/token/";
        private const string _spotifySuggestionURI = "https://api.spotify.com/v1/recommendations";
        private string _redirectURL;

        public SpotifyAPIService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;

            _clientSpotifyId = _configuration["SpotifyClientId"];
            _clientSpotifySecret = _configuration["SpotifyClientSecret"];
            _redirectURL = _configuration["urlApi"];

            _clientSpotifyCode = GetAuthCode();

            if (string.IsNullOrEmpty(AuthHelper.TokenSpotifyAuth))
                AuthHelper.TokenSpotifyAuth = GetToken();


            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthHelper.TokenSpotifyAuth);
            _httpClient = httpClient;
        }


        public MusicList GetBy(eMusicType musicType)
        {
            var data = GetSuggestions(_spotifySuggestionURI + getURLSpotifyParameters(musicType)).Result;

            return data;
        }

        private string getURLSpotifyParameters(eMusicType musicType)
        {
            return $"?market=BR&seed_genres={musicType}";
        }

        private string GetAuthCode()
        {
            return AuthHelper.CodeSpotifyAuth;
        }
        private string GetToken()
        {
            var requestToken = new HttpRequestMessage(HttpMethod.Post, _spotifyTokenURI);
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            parameters.Add(new KeyValuePair<string, string>("code", _clientSpotifyCode));
            parameters.Add(new KeyValuePair<string, string>("redirect_uri", _redirectURL));
            parameters.Add(new KeyValuePair<string, string>("client_id", _clientSpotifyId));
            parameters.Add(new KeyValuePair<string, string>("client_secret", _clientSpotifySecret));
            requestToken.Content = new FormUrlEncodedContent(parameters);


            HttpResponseMessage responseToken = new HttpClient().SendAsync(requestToken).Result;
            var tokenJson = JObject.Parse(responseToken.Content.ReadAsStringAsync().Result);
            string token = tokenJson["access_token"].ToString();

            return token;
        }

        private async Task<MusicList> GetSuggestions(string url)
        {
            try
            {
                var response = _httpClient.GetAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new CustomExceptionAPI("Infelizmente não obtivemos nenhuma indicação de música.", (int)HttpStatusCode.NotFound);

                var result = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<MusicList>(result);

                return data;
            }
            catch (Exception ex)
            {
                throw new CustomExceptionAPI("Serviço de consulta de a indicações musicais temporariamente indisponível.", (int)HttpStatusCode.BadGateway);
            }
        }

    }
}
