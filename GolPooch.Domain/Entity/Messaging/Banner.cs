using System;
using Elk.Core;
using GolPooch.Domain.Enum;
using GolPooch.Domain.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Banner))]
    public class Banner : IEntity, IInsertDateProperties, IIsActiveProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BannerId { get; set; }

        [ForeignKey(nameof(PageId))]
        public Page Page { get; set; }
        public int PageId { get; set; }

        public BannerType Type { get; set; }
        public ActionType ActionType { get; set; }
        public DisplayType DisplayType { get; set; }
        public LocationType LocationType { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public string ActionText { get; set; }
        public string FileUrl { get; set; }
        public string Href { get; set; }
        public bool IsActive { get; set; }

        [Column(TypeName = "char(10)")]
        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }
    }
}