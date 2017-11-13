using Greenfinch.Business.Interface.Services;
using Greenfinch.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Greenfinch.Validators
{
    public class NewsletterRegistrationValidator : AbstractModelStateValidator
    {
        private readonly INewsletterRegistrationService _newsletterRegistrationService;
        private readonly NewsletterRegistrationViewModel _newsletterRegistrationViewModel;

        public NewsletterRegistrationValidator(ModelStateDictionary modelState,
            INewsletterRegistrationService newsletterRegistrationService,
            NewsletterRegistrationViewModel newsletterRegistrationViewModel) : base(modelState)
        {
            _newsletterRegistrationService = newsletterRegistrationService;
            _newsletterRegistrationViewModel = newsletterRegistrationViewModel;
        }

        public override void Validate()
        {
            var isAlreadyHaveRegisteredEmail =
                _newsletterRegistrationService.IsAlreadyHaveRegisteredEmail(_newsletterRegistrationViewModel.Email);
            if (isAlreadyHaveRegisteredEmail)
            {
                AddError("Email is already registered in the newsletter");
            }
        }
    }
}