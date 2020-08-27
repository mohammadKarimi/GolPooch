using Elk.Core;
using GolPooch.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(VerificationCode))]
    public class VerificationCode : IEntity, IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VerificationCodeId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        public int Code { get; set; }

        public DateTime ExpirationTime { get; set; }
        public bool IsVerified { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        [Column(TypeName = "char(10)")]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }
    }
}
