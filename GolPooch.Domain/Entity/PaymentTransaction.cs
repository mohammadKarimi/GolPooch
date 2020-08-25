using GolPooch.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    public class PaymentTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentTransactionId { get; set; }

        public TransactionType Type { get; set; }

        [ForeignKey(nameof(PaymentGatewayId))]
        public PaymentGateway PaymentGateway { get; set; }
        public int PaymentGatewayId { get; set; }

        public int BankCardId { get; set; }

        [ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }
        public int? PurchaseId { get; set; }

        public int Price { get; set; }
        
        public bool IsSuccess { get; set; }

        public DateTime InsertDateMi { get; set; }

        [Column(TypeName = "char")]
        public string InsertDateSh { get; set; }

        [Column(TypeName = "varchar")]
        public string Status { get; set; }

        [Column(TypeName = "varchar")]
        public string Authority { get; set; }

        [Column(TypeName = "varchar")]
        public string TrackingId { get; set; }

        public string Description { get; set; }
    }
}
