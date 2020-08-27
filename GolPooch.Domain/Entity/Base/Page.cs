using Elk.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Page))]
    public class Page : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PageId { get; set; }

        public string Address { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Banner> Banners { get; set; }
    }
}