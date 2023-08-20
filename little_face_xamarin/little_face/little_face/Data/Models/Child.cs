using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace little_face.Data.Models
{
    public class Child
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Names { get; set; }

        [Required]
        public string Surnames { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Alias { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
