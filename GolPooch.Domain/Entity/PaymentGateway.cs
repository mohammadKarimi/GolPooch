using GolPooch.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    public class PaymentGateway
    {
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public BankNames BankName { get; set; }

        public DateTime InsertDateMi { get; set; }

        [Column(TypeName = "char")]
        public string InsertDateSh { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Password { get; set; }

        [Column(TypeName = "char")]
        public string MerchantId { get; set; }
    }
}