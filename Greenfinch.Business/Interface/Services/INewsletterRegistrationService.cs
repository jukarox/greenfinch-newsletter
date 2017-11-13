using Greenfinch.Business.Entities;

namespace Greenfinch.Business.Interface.Services
{
    public interface INewsletterRegistrationService : IServiceBase<NewsletterRegistration, int>
    {
        bool IsAlreadyHaveRegisteredEmail(string email);
    }
}