using Greenfinch.Business.Entities;
using Greenfinch.Business.Interface.Repositories;
using Greenfinch.Business.Interface.Services;

namespace Greenfinch.Business.Services
{
    public class HeardAboutUsOptionService : ServiceBase<HeardAboutUsOption, int>, IHeardAboutUsOptionService
    {
        private readonly IHeardAboutUsOptionRepository _repository;

        public HeardAboutUsOptionService(IHeardAboutUsOptionRepository repository) : base((IRepositoryBase<HeardAboutUsOption, int>) repository)
        {
            _repository = repository;
        }
    }
}