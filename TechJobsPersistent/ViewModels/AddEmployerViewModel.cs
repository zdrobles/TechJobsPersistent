using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required]
        public string Location { get; set; }
        [Required]
        public string Name { get; set; }

        public AddEmployerViewModel()
        {
        }
    }
}
