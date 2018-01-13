using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ENT.ViewModel
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Ad")]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(35)]
        [Required]
        [Display(Name = "Soyad")]
        public string SurName { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
  
}
