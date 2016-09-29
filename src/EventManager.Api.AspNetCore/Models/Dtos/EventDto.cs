namespace EventManager.Api.AspNetCore.Models.Dtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [StringLength(500)]
        public string Location { get; set; }

        public bool Visible { get; set; }
    }
}
