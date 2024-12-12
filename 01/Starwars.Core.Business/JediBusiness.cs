using Starwars.Core.Business.Interfaces;
using Starwars.Core.Data.Interfaces;
using Starwars.Core.Entities;

namespace Starwars.Core.Business
{
    public class JediBusiness(IJediRepository jediRepository) : IJediBusiness
    {
        //Primary Constructor 
        //private readonly IJediRepository _jediRepository;
        //public JediBusiness(IJediRepository jediRepository)
        //{
        //    _jediRepository = jediRepository;
        //}

        public async Task<IEnumerable<Jedi>> GetAllAsync()
        {
            return await jediRepository.GetAllAsync();
        }
    }
}
