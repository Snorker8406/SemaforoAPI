using Microsoft.AspNetCore.Http;
using System;

namespace SemaforoWeb.Common
{
    public static class Shared
    {
        public static byte[] mapFile(IFormFile file)
        {
            if (file == null) return null;
            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);
                return stream.ToArray();
            }
        }
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input[0].ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
