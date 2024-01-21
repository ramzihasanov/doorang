using DoorangWorld.Core.Entities;
using DoorangWorld.Core.Repositories;
using DoorangWorld.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Data.Repositories
{
    public class ExploreWorldRepository : GenericRepository<ExploreWorld>, IExploreWorldRepository
    {
        public ExploreWorldRepository(AppDbContext context) : base(context)
        {
        }
    }
}
