using System;
using Elk.Core;
using GolPooch.Domain.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(VerificationCode), Schema = "Base")]
    public class VerificationCode : IEntity, IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VerificationCodeId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [Display(Name = nameof(DisplayNames.PinCode), ResourceType = typeof(DisplayNames))]
        public int PinCode { get; set; }

        [Display(Name = nameof(DisplayNames.IsUsed), ResourceType = typeof(DisplayNames))]
        public bool IsUsed { get; set; }

        [Display(Name = nameof(DisplayNames.InsertDate), ResourceType = typeof(DisplayNames))]
        public DateTime InsertDateMi { get; set; }

        [Column(TypeName = "char(10)")]
        [Display(Name = nameof(DisplayNames.InsertDate), ResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        public string InsertDateSh { get; set; }

        [Display(Name = nameof(DisplayNames.ExpirationTime), ResourceType = typeof(DisplayNames))]
        public DateTime ExpirationTime { get; set; }
    }
}