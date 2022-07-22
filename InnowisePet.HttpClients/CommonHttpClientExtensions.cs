using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace InnowisePet.HttpClients;

public static class CommonHttpClientExtensions
{
    public static async Task<T> Deserialize<T>(HttpResponseMessage result)
    {
        if (result.IsSuccessStatusCode)
        {
            if (result.StatusCode == HttpStatusCode.NoContent) return default;

            await using Stream stream = await result.Content.ReadAsStreamAsync();
            JsonSerializerOptions options = new()
            {
                IncludeFields = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<T>(stream, options);
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {result.StatusCode}.");
    }

    public static StringContent SerializeObject<T>(T model)
    {
        return new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
    }
}