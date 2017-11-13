using Greenfinch.Business.Entities;
using Greenfinch.Business.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Greenfinch.Data.Repositories
{
    public class HeardAboutUsOptionRepository : RepositoryBase<HeardAboutUsOption, int>, IHeardAboutUsOptionRepository
    {
        public HeardAboutUsOptionRepository(DbContext context) : base(context)
        {
        }
    }
}