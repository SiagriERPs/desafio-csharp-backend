using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiagriPlaylistsChallenge.Domain.Contracts;
using SiagriPlaylistsChallenge.Domain.ValueObjects;
using SiagriPlaylistsChallenge.Infrastructure.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Infrastructure.Services
{
    public class PlaylistGenerator : IPlaylistGenerator
    {
        private HttpClient _httpClient;
       

        
        private string _authCode;

        
       
        private string _clientId;
        private string _clientSecret;
        //Esse Url não tem muita importancia ser não especifico
        private string _localUrl;

        private const string _spotifyTokenURI = "https://accounts.spotify.com/api/token/";
        private const string _spotifySuggestionURI = "https://api.spotify.com/v1/recommendations";

        public PlaylistGenerator(HttpClient httpClient)
        {
           
            _clientId = "b6a9a55c5f5846b28955f522f6fe08e6";
            _clientSecret = "4a3302681dba4fe7984419773caa092d";
            _localUrl = "https://localhost:5001/Auth/MusicService";
            _httpClient = httpClient;


            if (string.IsNullOrEmpty(AuthParams.ServiceToken))
                AuthParams.ServiceToken = FindToken();

            _authCode = GenerateAuthCode();



            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthParams.ServiceToken);
           
        }


        public PlaylistDTO GetPlaylistMusics(string genre)
        {
            var data = RetriveData(_spotifySuggestionURI + getURLSpotifyParameters(genre)).Result;

            return data;
        }

        private string getURLSpotifyParameters(string genre)
        {
            return $"?market=BR&seed_genres={genre}";
        }

        private string GenerateAuthCode()
        {
            return AuthParams.ServiceAuthCode;
        }


        private string FindToken()
        {
            var rtk = new HttpRequestMessage(HttpMethod.Post, _spotifyTokenURI);

            List<KeyValuePair<string, string>> header = new List<KeyValuePair<string, string>>();
            header.Add(new KeyValuePair<string, string>("GRANT_TYPE", "AUTHORIZATION_CODE"));
            header.Add(new KeyValuePair<string, string>("CLIENT_ID", _clientId));
            header.Add(new KeyValuePair<string, string>("REDIRECT_URI", _localUrl));
            header.Add(new KeyValuePair<string, string>("CODE", _authCode));
            header.Add(new KeyValuePair<string, string>("CLIENT_SECRET", _clientSecret));

            rtk.Content = new FormUrlEncodedContent(header);


            HttpResponseMessage response = new HttpClient().SendAsync(rtk).Result;
            var tokenJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            string tk = "BQAoFV9lBohH9R-An6dwbH3I2VkXTgBMhTGBtiohBGk13E5vs_69QDj0WH4ThWbkkr82AXlLccaCxnfc1DruSRwCk79qatiCxOJfU23TuJhUJip0LQUK1BmzgG1f3GoHaBcRj8DHOkzb9xE7YkDYZlQqiacYyxpiDQA";

            return tk;
        }

        private async Task<PlaylistDTO> RetriveData(string url)
        {
            var response = _httpClient.GetAsync(url).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            var data = JsonConvert.DeserializeObject<PlaylistDTO>(result);

            return data;
        }

    }

    public static class AuthParams
    {
        public static string ServiceAuthCode { get; set; }
        public static string ServiceToken { get; set; }
    }
}
