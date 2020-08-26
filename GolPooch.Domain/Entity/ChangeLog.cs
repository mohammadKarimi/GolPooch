using Elk.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    [Table(nameof(ChangeLog))]
    public class ChangeLog : IEntity, IInsertDateProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChangeLogId { get; set; }

        public string Version { get; set; }
        public string Change { get; set; }

        public string InsertDateSh { get; set; }
        public DateTime InsertDateMi { get; set; }
    }
}
