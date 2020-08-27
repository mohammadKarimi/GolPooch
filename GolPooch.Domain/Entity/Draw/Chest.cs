using System;
using Elk.Core;
using GolPooch.Domain.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Chest))]
    public class Chest : IEntity, IInsertDateProperties, IIsActiveProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChestId { get; set; }

        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string BannerUrl { get; set; }
        public int ParticipantCount { get; set; }
        public int WinnerCount { get; set; }
        public int RoundCount { get; set; }

        [Column(TypeName = "char(10)")]
        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }
    }
}