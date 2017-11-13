using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenfinch.Business.Entities
{
    public class NewsletterRegistration
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(80)]
        [Required]
        public string Email { get; set; }

        public int HeardAboutUsId { get; set; }

        [ForeignKey("HeardAboutUsId")]
        public HeardAboutUsOption HeardAboutUs { get; set; }

        [MaxLength(200)]
        public string ReasonSigningUp { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }
    }
}
