using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSuggestorAPI.Domain.Common;
using MusicSuggestorAPI.Domain.CustomException;
using MusicSuggestorAPI.Domain.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("MusicSuggestor/")]
    public class MusicSuggestorController : ControllerBase
    {
        const string InternalErrorMessage = "Unstable server, please try again later";
        const int InternalErrorStatusCode = (int)HttpStatusCode.InternalServerError;

        private IMusicSuggestorService _musicSuggestorService;

        public MusicSuggestorController(IMusicSuggestorService musicSuggestorService)
        {
            _musicSuggestorService = musicSuggestorService;
        }

        [Route("GetSuggestion/{cityName}")]
        [HttpGet]
        public async Task<IActionResult> GetSuggestion(string cityName)
        {
            try
            {
                if (verifyToken())
                {
                    return Redirect("");
                }

                cityName.StringValid();

                return Ok(_musicSuggestorService.GetBy(cityName));
            }
            catch (CustomExceptionAPI ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(InternalErrorStatusCode, InternalErrorMessage);
            }
        }

        [Route("GetSuggestion/{lat}/{lon}")]
        [HttpGet]
        public async Task<IActionResult> GetSuggestion(double? lat, double? lon)
        {
            try
            {
                ValidationExtension.CoordinateValid(lat, lon);

                return Ok(_musicSuggestorService.GetBy(lat.Value, lon.Value));
            }
            catch (CustomExceptionAPI ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(InternalErrorStatusCode, InternalErrorMessage);
            }
        }



        private bool verifyToken()
        {
            return string.IsNullOrEmpty(AuthHelper.CodeSpotifyAuth);
        }
    }
}
