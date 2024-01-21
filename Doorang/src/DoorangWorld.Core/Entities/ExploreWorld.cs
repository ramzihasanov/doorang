using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Core.Entities
{
    public class ExploreWorld:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Text1 { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Text2 { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Desccription { get; set; }
        public string? Imageurl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
