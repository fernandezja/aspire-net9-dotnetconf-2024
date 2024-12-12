using Starwars.Core.Data.Interfaces;
using Starwars.Core.Entities;
using System.Text.Json;

namespace Starwars.Core.Data
{
    public class JediRepository : IJediRepository
    {
        public async Task<IEnumerable<Jedi>> GetAllAsync()
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "data", "jedis.json");
            var json = await File.ReadAllTextAsync(filePath);
            var jedis = JsonSerializer.Deserialize<List<Jedi>>(json);
            return jedis;

        }
    }
}
