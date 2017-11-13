using Greenfinch.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenfinch.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<NewsletterRegistration> NewsletterRegistrations { get; set; }
        public DbSet<HeardAboutUsOption> HeardAboutUsOptions { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=.\;Database=GreenfinchNewsletter;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsletterRegistration>().ToTable("NewsletterRegistration");
            modelBuilder.Entity<HeardAboutUsOption>().ToTable("HeardAboutUsOption");
        }
    }
}