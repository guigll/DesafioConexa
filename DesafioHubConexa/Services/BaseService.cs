using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesafioHubConexa.Services
{
    public abstract class BaseService
    {
        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }
    }
}
