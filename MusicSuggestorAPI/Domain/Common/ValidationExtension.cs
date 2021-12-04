using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MusicSuggestorAPI.Domain;
using MusicSuggestorAPI.Domain.CustomException;

namespace MusicSuggestorAPI.Domain.Common
{
    public static class ValidationExtension
    {
        private const int _statusCodeErro = (int)HttpStatusCode.BadRequest;

        //Todo : melhorar validação de string
        public static void StringValid(this string field)
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrWhiteSpace(field))
                throw new CustomExceptionAPI("Nome da cidade deve ser obrigatóriamente preenchido.", _statusCodeErro);

        }

        public static void CoordinateValid(double? latitude, double? longitude)
        {
            if (!latitude.HasValue || !longitude.HasValue)
                throw new CustomExceptionAPI("As coordenadas geográficas são obrigatórias para consulta.", _statusCodeErro);

            if (latitude < -90 || latitude > 90)
                throw new CustomExceptionAPI("Latitude deve estar entre -90 a 90 graus.", _statusCodeErro);

            if (longitude < -180 || longitude > 180)
                throw new CustomExceptionAPI("Longitude deve estar entre -180 a 180 graus.", _statusCodeErro);
        }
    }
}
