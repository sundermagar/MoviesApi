using SunderTest.Domain.Common;
using SunderTest.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SunderTest.Domain.Entities
{
    public class Genre : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
         
    }
}
