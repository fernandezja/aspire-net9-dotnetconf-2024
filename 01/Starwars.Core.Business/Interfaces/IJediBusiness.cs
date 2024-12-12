using Starwars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starwars.Core.Business.Interfaces
{
    public interface IJediBusiness
    {
        Task<IEnumerable<Jedi>> GetAllAsync();
    }
}
