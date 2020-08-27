using Elk.Core;
using GolPooch.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Chest))]
    public class Chest : IEntity, IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChestId { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
        public int Participant { get; set; }
        public int Winner { get; set; }
        public int Round { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        [Column(TypeName = "char(10)")]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }
    }
}
