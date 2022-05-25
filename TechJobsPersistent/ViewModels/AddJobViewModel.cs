using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int EmployerID { get; set; }
        public List<SelectListItem> Employer { get; set; }
        public List<Skill> SkillList { get; set; }
        public AddJobViewModel()
        {
        }

        //public AddJobViewModel(JobDbContext dbContext)
        //{
        //    SelectListItem = dbContext.Employers.ToList();
        //    SkillList = dbContext.Skills.ToList();
        //}

        public AddJobViewModel(List<Employer> selectListItem, List<Skill> skillList)
        {
            SkillList = skillList;

            Employer = new List<SelectListItem>();

            foreach (var skill in selectListItem)
            {
                Employer.Add(new SelectListItem
                {
                    Value = skill.Id.ToString(),
                    Text = skill.Name
                });
            }
        }
    }

}
