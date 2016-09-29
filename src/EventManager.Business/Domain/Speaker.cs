using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Business.Domain
{
    public class Speaker
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
