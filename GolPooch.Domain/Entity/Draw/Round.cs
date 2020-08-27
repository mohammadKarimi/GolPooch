using System;
using Elk.Core;
using GolPooch.Domain.Enum;
using GolPooch.Domain.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Round))]
    public class Round : IEntity, IInsertDateProperties, IModifyDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoundId { get; set; }

        [ForeignKey(nameof(ChestId))]
        public Chest Chest { get; set; }
        public int ChestId { get; set; }

        [ForeignKey(nameof(WinnerUserId))]
        public User WinnerUser { get; set; }
        public int WinnerUserId { get; set; }

        public int ParticipantCount { get; set; }

        public DateTime DateStartMi { get; set; }
        public string DateStartSh { get; set; }

        public DateTime DateEndMi { get; set; }
        public string DateEndSh { get; set; }

        public RoundState State { get; set; }
        
        public string Description { get; set; }

        [Column(TypeName = "char(10)")]
        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        public string InsertDateSh { get; set; }
        public DateTime InsertDateMi { get; set; }
        public string ModifyDateSh { get; set; }
        public DateTime ModifyDateMi { get; set; }
    }
}