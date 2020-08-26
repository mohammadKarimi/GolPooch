using Elk.Core;
using GolPooch.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(PaymentGateway))]
    public class PaymentGateway : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentGatewayId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public BankNames BankName { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }


        public string Password { get; set; }

        public string MerchantId { get; set; }
    }
}