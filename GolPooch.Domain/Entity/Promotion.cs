using GolPooch.Domain.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GolPooch.Domain.Entity
{
    public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public byte Chance { get; set; }
        public int TotalPrice { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
        public int Profit { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        [Column(TypeName = "char(10)")]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
