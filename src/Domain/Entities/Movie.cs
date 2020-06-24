using SunderTest.Domain.Common;
using SunderTest.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunderTest.Domain.Entities
{
    public class Movie : AuditableEntity
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? Releasedate { get; set; }


        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
        public int? GenreId { get; set; }
        public string Duration { get; set; }
        public string Rating { get; set; }

    }
}
