using System;

namespace Imagebook.Services.Mapping.Extensions
{
    public static class StringExtensions
    {
        public static string GetBase64(this byte[] imageBytes)
        {
            var base64 = Convert.ToBase64String(imageBytes);
            var imageSrc = $"data:image/jpg;base64,{base64}";

            return imageSrc;
        }
    }
}
