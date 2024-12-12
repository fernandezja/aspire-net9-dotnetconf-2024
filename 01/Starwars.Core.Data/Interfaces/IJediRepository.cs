using Starwars.Core.Entities;

namespace Starwars.Core.Data.Interfaces
{
    public interface IJediRepository
    {
        Task<IEnumerable<Jedi>> GetAllAsync();
        //Task<Jedi> GetJedi(int id);
        //Task AddJedi(Jedi jedi);
        //Task UpdateJedi(Jedi jedi);
        //Task DeleteJedi(int id);
    }
}
