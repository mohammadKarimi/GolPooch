using System;
using Elk.Core;
using GolPooch.Domain.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Purchase))]
    public class Purchase : IEntity, IInsertDateProperties, IModifyDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(ProductOfferId))]
        public ProductOffer ProductOffer { get; set; }
        public int ProductOfferId { get; set; }

        [ForeignKey(nameof(PaymentTransactionId))]
        public PaymentTransaction PaymentTransaction { get; set; }
        public int PaymentTransactionId { get; set; }

        public byte Chance { get; set; }
        public byte UsedChance { get; set; }
        public bool IsReFoundable { get; set; }
        public bool IsFinished { get; set; }

        [Column(TypeName = "char(10)")]
        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        public string InsertDateSh { get; set; }
        public DateTime InsertDateMi { get; set; }
        public string ModifyDateSh { get; set; }
        public DateTime ModifyDateMi { get; set; }
    }
}