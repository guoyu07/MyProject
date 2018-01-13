using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ENT.Model
{
    [Table("MovieShowing")]
    public class MovieShowing
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }


        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
    }
}
