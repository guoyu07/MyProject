using Microsoft.AspNet.Identity.EntityFramework;
using MyProject.ENT.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ENT.IdendityModel
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(35)]
        public string SurName { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; } = DateTime.Now; //Autosetter
        public int? DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public string ActivationCode { get; set; }

        public virtual List<Booking> Booking { get; set; }
    }
}
