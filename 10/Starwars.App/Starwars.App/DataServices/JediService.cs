using Starwars.Core.Entities;

namespace Starwars.App.DataServices
{
    public class JediService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JediService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<List<Jedi>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("StarwarsAPI");

            return await client.GetFromJsonAsync<List<Jedi>>("api/jedi") ?? new List<Jedi>();
        }
    }
}
