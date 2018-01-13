using MyProject.ENT.IdendityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ENT.Model
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int MovieShowingId { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }



        [ForeignKey("MovieShowingId")]
        public virtual MovieShowing Movieshowing { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ApplicationUser Customer { get; set; }
        
        public virtual List<Seats> Seats { get; set; }


    }
}
