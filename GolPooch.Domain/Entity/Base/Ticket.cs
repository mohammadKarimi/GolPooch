using Elk.Core;
using GolPooch.Domain.Enum;
using GolPooch.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Ticket))]
    public class Ticket : IEntity, IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(AnswerUserId))]
        public User AnswerUser { get; set; }
        public int AnswerUserId { get; set; }

        public TicketType Type { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }

        public bool IsRead { get; set; }
        [Column(TypeName = "char(10)")]
        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        public string AnswerDateSh { get; set; }
        public DateTime AnswerDateMi { get; set; }

        [Column(TypeName = "char(10)")]
        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        public string InsertDateSh { get; set; }
        public DateTime InsertDateMi { get; set; }
    }
}