using Elk.Core;
using GolPooch.Domain.Enum;
using GolPooch.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table("Transaction", Schema = "Payment")]
    public class PaymentTransaction : IEntity , IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentTransactionId { get; set; }

        public TransactionType Type { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(PaymentGatewayId))]
        public PaymentGateway PaymentGateway { get; set; }
        public int PaymentGatewayId { get; set; }

        [ForeignKey(nameof(ProductOfferId))]
        public ProductOffer ProductOffer { get; set; }
        public int ProductOfferId { get; set; }

        public int Price { get; set; }
        
        public bool IsSuccess { get; set; }

        public string Status { get; set; }

        public string TrackingId { get; set; }

        public string UserSheba { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        [Column(TypeName = "char(10)")]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }
    }
}
