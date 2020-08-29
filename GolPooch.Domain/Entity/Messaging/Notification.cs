using System;
using Elk.Core;
using GolPooch.Domain.Enum;
using GolPooch.Domain.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(Notification), Schema = "Messaging")]
    public class Notification : IEntity, IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }

        /// <summary>
        /// if this field set with null, that means this notification is for all users
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int? UserId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public string FileUrl { get; set; }
        public string Href { get; set; }
        public bool IsActive { get; set; }

        public NotificationType Type { get; set; }
        public NotificationAction Action { get; set; }

        public bool IsSend { get; set; }
        public bool? IsSuccess { get; set; }
        public bool IsRead { get; set; }

        [Column(TypeName = "char(10)")]
        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }
        public DateTime SentDateMi { get; set; }
    }
}