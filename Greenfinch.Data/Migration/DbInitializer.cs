using System;
using System.Linq;
using Greenfinch.Data.Context;
using Greenfinch.Business.Entities;

namespace Greenfinch.Data.Migration
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.HeardAboutUsOptions.Any())
            {
                return;
            }

            var heardAboutUsOptions = new[]
            {
                new HeardAboutUsOption {Description = "Advert"},
                new HeardAboutUsOption {Description = "Word of Mouth"},
                new HeardAboutUsOption {Description = "Other"}
            };

            foreach (var heardAboutUsOption in heardAboutUsOptions)
            {
                context.HeardAboutUsOptions.Add(heardAboutUsOption);
            }
            context.SaveChanges();

            var newsletterRegistration = new NewsletterRegistration
            {
                Email = "julio.contipelli@gmail.com",
                ReasonSigningUp = "bla bla bla",
                RegisteredOn = DateTime.Now,
                HeardAboutUs = heardAboutUsOptions[0]
            };

            context.NewsletterRegistrations.Add(newsletterRegistration);
            context.SaveChanges();
        }
    }
}