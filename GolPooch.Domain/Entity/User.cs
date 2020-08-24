using GolPooch.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    public class User
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

        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<ModalMessage> ModalMessages { get; set; }
        public ICollection<UserChance> UserChances { get; set; }
        public ICollection<Sheet> Sheets { get; set; }
    }
}
