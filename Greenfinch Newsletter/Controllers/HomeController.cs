using System;
using System.Diagnostics;
using Greenfinch.Business.Entities;
using Greenfinch.Business.Interface.Services;
using Greenfinch.Models;
using Greenfinch.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace Greenfinch.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsletterRegistrationService _newsletterRegistrationService;
        private readonly IHeardAboutUsOptionService _heardAboutUsOptionService;
        private readonly IToastNotification _toastNotification;

        public HomeController(INewsletterRegistrationService newsletterRegistrationService,
            IHeardAboutUsOptionService heardAboutUsOptionService, IToastNotification toastNotification)
        {
            _newsletterRegistrationService = newsletterRegistrationService;
            _heardAboutUsOptionService = heardAboutUsOptionService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            getHeardAboutUsOptions();
            return View();
        }

        [HttpPost]
        public ActionResult SubscribeNewsletter(NewsletterRegistrationViewModel newsletterRegistrationViewModel)
        {
            var newsletterRegistrationValidator =
                new NewsletterRegistrationValidator(ModelState, _newsletterRegistrationService,
                    newsletterRegistrationViewModel);
            newsletterRegistrationValidator.Validate();

            if (!ModelState.IsValid)
            {
                getHeardAboutUsOptions();
                return View("Index", newsletterRegistrationViewModel);
            }

            var newsletterRegistration = new NewsletterRegistration()
            {
                Email = newsletterRegistrationViewModel.Email,
                ReasonSigningUp = newsletterRegistrationViewModel.ReasonSigningUp,
                HeardAboutUsId = (int)newsletterRegistrationViewModel.HeardAboutUsId,
                RegisteredOn = DateTime.Now
            };

            _newsletterRegistrationService.Add(newsletterRegistration);

            _toastNotification.AddSuccessToastMessage("You have been added to our mailing list and you will receive all our news!");

            return RedirectToAction("Contact");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void getHeardAboutUsOptions()
        {
            var heardAboutUsOptions = _heardAboutUsOptionService.GetAll();
            ViewBag.HeardAboutUsOptions = new SelectList(heardAboutUsOptions, "Id", "Description");
        }
    }
}