using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ENT.Model
{
    public class Seats
    {
        [Key]
        public int Id { get; set; }
        [StringLength(2,ErrorMessage ="Value must be one chracter!")]
        public string Row { get; set; }
        [Range(1,20,ErrorMessage ="Value must be ranged from 1 to 20!")]
        public int SeatNo { get; set; }

        public virtual List<Booking> Booking { get; set; }
    }
}
