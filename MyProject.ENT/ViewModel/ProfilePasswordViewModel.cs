using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ENT.ViewModel
{
    public class ProfilePasswordViewModel
    {
        public ProfileViewModel profileModel { get; set; } = new ProfileViewModel();
        public PasswordViewModel passwordModel { get; set; } = new PasswordViewModel();
    }
}
