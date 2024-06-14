using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDTO<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseDTO<T> Success(int statusCode, T data) 
        {
            return new CustomResponseDTO<T>
            {
                Data = data,
                StatusCode = statusCode
            };
        }

        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode
            };
        }

        public static CustomResponseDTO<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDTO<T>
            {
                Errors = errors,
                StatusCode = statusCode
            };
        }
}
