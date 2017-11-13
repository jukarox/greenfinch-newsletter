using Greenfinch.Business.Entities;
using Greenfinch.Business.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Greenfinch.Data.Repositories
{
    public class NewsletterRegistrationRepository : RepositoryBase<NewsletterRegistration, int>, INewsletterRegistrationRepository
    {
        public NewsletterRegistrationRepository(DbContext context) : base(context)
        {
        }
    }
}
