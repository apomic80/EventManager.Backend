namespace EventManager.Models.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class SpeakerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Photo { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(500)]
        public string Biography { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string WebSite { get; set; }

        [StringLength(255)]
        public string Facebook { get; set; }

        [StringLength(255)]
        public string Linkedin { get; set; }

        [StringLength(255)]
        public string Twitter { get; set; }
    }
}
