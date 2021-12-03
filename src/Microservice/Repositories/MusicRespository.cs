using Microservice.Dtos;
using Microservice.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Repositories
{
    public class MusicRespository : IMusicRepository
    {
        private readonly HttpClient _httpClient;
        private static string token = string.Empty;

        private readonly string _authBaseUrl = "https://accounts.spotify.com/api/token";
        private readonly string _baseUrl = "https://api.spotify.com/v1";

        private const string CLIENT_ID = "cc5cae51be7c4d228cdd33c36457c0c1";
        private const string CLIENT_SECRET = "09898e59b7ce42ed858048030139e5c4";

        public MusicRespository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private record AuthResponse(string access_token);
        private record ErrorResponse(int status, string message);
        private record SpotifyErrorResponse(ErrorResponse error);

        private async Task<bool> GetToken()
        {
            var clientId = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{CLIENT_ID}:{CLIENT_SECRET}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", clientId);

            var form = new FormUrlEncodedContent(
                new Dictionary<string, string> { { "grant_type", "client_credentials" } });
            var response = await _httpClient.PostAsync(_authBaseUrl, form);
            if (response.IsSuccessStatusCode)
            {
                var authObject = await response.Content.ReadFromJsonAsync<AuthResponse>();
                token = authObject.access_token;
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<Response<MusicDto>> GetMusicsByGenre(string genre)
        {
            string uri = $"{_baseUrl}/search?query={genre}&type=track";

            bool success = await GetToken();
            if (!success)
            {
                Response<MusicDto> authResponse = new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Error = "Falha de autenticação"
                };
                return authResponse;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var musicResponse = await _httpClient.GetAsync(uri);

            if (musicResponse.IsSuccessStatusCode)
                return new Response<MusicDto>(await musicResponse.Content.ReadFromJsonAsync<MusicDto>());
            else
            {
                SpotifyErrorResponse errorResponse = await musicResponse.Content.ReadFromJsonAsync<SpotifyErrorResponse>();
                Response<MusicDto> serviceResponse = new()
                {
                    StatusCode = errorResponse.error.status,
                    Error = errorResponse.error.message,
                };
                return serviceResponse;
            }
        }
    }
}
