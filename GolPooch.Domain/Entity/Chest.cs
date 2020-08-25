using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolPooch.Domain.Entity
{
    public class Chest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChestId { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
        public int Participant { get; set; }
        public int Winner { get; set; }
        public int Round { get; set; }
    }
}
