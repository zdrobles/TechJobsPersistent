using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        

        [Required]
        public string Name { get; set; }
        [Required]
        public int EmployerID { get; set; }
        public List<Employer> SelectListItem { get; set; }
        public AddJobViewModel()
        {
        }
    }

}
