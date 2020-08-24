﻿using GolPooch.Domain.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }

        public DateTime ExpireDateTime { get; set; }
        public int UsageTime { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        [Column(TypeName = "char(10)")]
        public string InsertDateSh { get; set; }

        public bool IsShow { get; set; }
        public DateTime InsertDateMi { get; set; }

        public ICollection<Promotion> Promotions { get; set; }
    }
}
