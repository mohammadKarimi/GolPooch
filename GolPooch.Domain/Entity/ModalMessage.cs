using GolPooch.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(ModalMessage))]
    public class ModalMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModalMessageId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(PageId))]
        public Page Page { get; set; }
        public int PageId { get; set; }

        public Location Location { get; set; }
        public ModalMessageType Type { get; set; }

        public ModalMessageDisplayCount DisplayCount { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Href { get; set; }
        public bool IsActive { get; set; }
        public ModalMessageAction ModalMessageAction { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
