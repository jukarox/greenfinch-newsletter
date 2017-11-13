using System.Linq;
using Greenfinch.Business.Entities;
using Greenfinch.Business.Interface.Repositories;
using Greenfinch.Business.Interface.Services;

namespace Greenfinch.Business.Services
{
    public class NewsletterRegistrationService : ServiceBase<NewsletterRegistration, int>,
        INewsletterRegistrationService
    {
        private readonly INewsletterRegistrationRepository _repository;

        public NewsletterRegistrationService(INewsletterRegistrationRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public bool IsAlreadyHaveRegisteredEmail(string email)
        {
            return _repository.Get(n => n.Email.Equals(email)).Any();
        }
    }
}