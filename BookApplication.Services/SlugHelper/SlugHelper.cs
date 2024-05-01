using System.Text.RegularExpressions;

namespace BookApplication.Services.SlugHelper
{
    public static class SlugHelper
    {
        public static string GenerateSlugForImages(this string input)
        {
            input = input.Length > 40 ? input.Substring(0, 40) : input;

            string slug = input.ToLower();

            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug = slug.Replace(" ", "-");
            slug = Regex.Replace(slug, @"-+", "-").Trim();
            slug = slug.Replace("/", "-").Replace("\\", "-").Replace("+", "-").Replace("?", "-").Trim();

            slug = slug.Replace("ç", "c")
                       .Replace("ğ", "g")
                       .Replace("ı", "i")
                       .Replace("i", "i")
                       .Replace("ö", "o")
                       .Replace("ş", "s")
                       .Replace("ü", "u");
            return slug;
        }
        public static string GenerateSlugName(this string input)
        {
            string slug = input.ToLower();

            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug = slug.Replace(" ", "-");
            slug = Regex.Replace(slug, @"-+", "-").Trim();
            slug = slug.Replace("ç", "c")
                       .Replace("ğ", "g")
                       .Replace("ı", "i")
                       .Replace("i", "i")
                       .Replace("ö", "o")
                       .Replace("ş", "s")
                       .Replace("ü", "u")
                       .Replace("?", "-");
            return slug;
        }
    }
}
