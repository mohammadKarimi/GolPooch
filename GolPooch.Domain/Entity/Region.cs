﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegionId { get; set; }

        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}