using Elk.Core;
using GolPooch.Domain.Enum;
using GolPooch.Domain.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(User))]
    public class User : IEntity, IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public DateTime BirthdateMi { get; set; }

        public string PushId { get; set; }
        public string DeviceName { get; set; }

        public int RegionId { get; set; }
        [ForeignKey(nameof(RegionId))]
        public Region Region { get; set; }

        public Gender Gender { get; set; }
        public string ProfileAddr { get; set; }

        [Required(ErrorMessageResourceName = nameof(DisplayNames.Required), ErrorMessageResourceType = typeof(DisplayNames))]
        [MaxLength(10, ErrorMessageResourceName = nameof(DisplayNames.MaxLength), ErrorMessageResourceType = typeof(DisplayNames))]
        [Column(TypeName = "char(10)")]
        public string InsertDateSh { get; set; }

        public DateTime InsertDateMi { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<UserChance> UserChances { get; set; }
        public ICollection<Sheet> Sheets { get; set; }
        public ICollection<UserModalMessage> UserModalMessage { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
    }
}
