using System.ComponentModel.DataAnnotations;

namespace Greenfinch.Business.Entities
{
    public class HeardAboutUsOption
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Description { get; set; }
    }
}