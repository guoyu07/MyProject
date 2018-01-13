using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ENT.Model
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Country { get; set; }
        public string Lang { get; set; }
        public string Subtitle { get; set; }
        public int GenresId { get; set; }
        public string Production { get; set; }
        public string Runtime { get; set; }

        [ForeignKey("DirectorId")]
        public virtual Director Director { get; set; }
        [ForeignKey("GenresId")]
        public virtual Genres Genres { get; set; }
        public virtual List<Players> Players { get; set; }

    }
}
