using GolPooch.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(Promotion))]
        public Promotion Promotion { get; set; }
        public int PromotionId { get; set; }

        [ForeignKey(nameof(User))]
        public User User { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        [Column(TypeName = "char(10)")]
        public string InsertDateSh { get; set; }

        public byte Chance { get; set; }
        public byte RemainedChance { get; set; }
        public int PaymentTransactionId { get; set; }
        public bool IsPayedBack { get; set; }
        public DateTime InsertDateMi { get; set; }
    }
}
