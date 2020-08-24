using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    public class Sheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SheetId { get; set; }

        [ForeignKey(nameof(WinnerUserId))]
        public User User { get; set; }
        public int WinnerUserId { get; set; }

        public DateTime DateStartMi { get; set; }
        public string DateStartSh { get; set; }

        public DateTime? DateEndMi { get; set; }
        public string DateEndSh { get; set; }

        public bool IsActive { get; set; }
        public bool IsPayed { get; set; }
        public DateTime DatePayMi { get; set; }
        public string DatePaySh { get; set; }
        public string Description { get; set; }
    }
}
