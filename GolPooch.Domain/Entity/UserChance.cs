using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GolPooch.Domain.Entity
{
    public class UserChance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChanceId { get; set; }

        public int Order { get; set; }
        public string Code { get; set; }

        [ForeignKey(nameof(User))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(SheetId))]
        public Sheet Sheet { get; set; }
        public int SheetId { get; set; }

        public int MyProperty { get; set; }

    }
}
