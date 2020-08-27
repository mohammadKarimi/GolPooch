using System;
using Elk.Core;
using GolPooch.Domain.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Product))]
    public class Product : IEntity, IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string Subject { get; set; }
        public string Text { get; set; }

        public DateTime ExpireDateTime { get; set; }

        public bool IsShow { get; set; }

        [Column(TypeName = "char(10)")]
        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        public string InsertDateSh { get; set; }
        public DateTime InsertDateMi { get; set; }


        public ICollection<ProductOffer> Promotions { get; set; }
    }
}