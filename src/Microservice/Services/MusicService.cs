using Microservice.Dtos;
using Microservice.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Services
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _httpClient;
        private static string token = string.Empty;

        private readonly string _authBaseUrl = "https://accounts.spotify.com/api/token";
        private readonly string _baseUrl = "https://api.spotify.com/v1";

        private const string CLIENT_ID = "CLIENT_ID";
        private const string CLIENT_SECRET = "CLIENT_SECRET";

        public MusicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<bool> GetToken()
        {
            var clientId = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{CLIENT_ID}:{CLIENT_SECRET}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", clientId);

            var form = new FormUrlEncodedContent(
                new Dictionary<string, string> { { "grant_type", "client_credentials" } });
            var response = await _httpClient.PostAsync(_authBaseUrl, form);
            if (response.IsSuccessStatusCode)
            {
                var authObject = await response.Content.ReadFromJsonAsync<AuthSpotifyResponse>();
                token = authObject.access_token;
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<Response<MusicDto>> GetMusicsByGenre(string genre)
        {
            string uri = $"{_baseUrl}/search?query={genre}&type=track";

            await GetToken();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var musicResponse = await _httpClient.GetAsync(uri);
            if(musicResponse.IsSuccessStatusCode)
                return new Response<MusicDto>(await musicResponse.Content.ReadFromJsonAsync<MusicDto>());
            string response = await musicResponse.Content.ReadAsStringAsync();
            return new Response<MusicDto>();
        }
    }
}
