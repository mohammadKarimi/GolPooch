using Elk.Core;
using GolPooch.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(UserChance))]
    public class UserChance :IEntity , IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChanceId { get; set; }

        public int Order { get; set; }
        public string Code { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(SheetId))]
        public Sheet Sheet { get; set; }
        public int? SheetId { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        [Column(TypeName = "char(10)")]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }

    }
}
