using System.Text.Json;
using System.Threading.Tasks;

namespace User.Data
{
    public static class Extensions
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public static T Deserialize<T>(this string source)
        {
            return JsonSerializer.Deserialize<T>(source, _options);
        }

        public static async Task<T> Deserialize<T>(this Task<string> source)
        {
            return JsonSerializer.Deserialize<T>(await source, _options);
        }
    }
}
