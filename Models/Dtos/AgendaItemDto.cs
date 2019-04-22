namespace EventManager.Models.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class AgendaItemDto
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        [Required]
        [StringLength(5)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(5)]
        public string EndTime { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? SpeakerId { get; set; }

        public int Order { get; set; }
    }
}
