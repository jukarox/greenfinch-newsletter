using System;
using System.ComponentModel.DataAnnotations;

namespace Greenfinch.Models
{
    public class NewsletterRegistrationViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(80)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "How did you hear about us?")]
        public int? HeardAboutUsId { get; set; }

        [MaxLength(200)]
        [Display(Name = "Reason for signing up")]
        public string ReasonSigningUp { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
