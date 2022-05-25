using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            AddJobViewModel addJobViewModel = new AddJobViewModel(context.Employers.ToList(), context.Skills.ToList());
            return View(addJobViewModel);
        }
        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {            
            if (!ModelState.IsValid) 
            {
                addJobViewModel = new AddJobViewModel(context.Employers.ToList(), context.Skills.ToList());
                return View("AddJob", addJobViewModel); 
            }

            Job job = new Job()
            {
                Name = addJobViewModel.Name,
                Employer = context.Employers.Find(addJobViewModel.EmployerID),
                EmployerId = addJobViewModel.EmployerID,
                JobSkills = new List<JobSkill>()
            };
            foreach (var skill in selectedSkills) 
            {
                JobSkill jobSkill = new JobSkill
                {
                    JobId = job.Id,
                    Job = job,
                    Skill = addJobViewModel.SkillList[int.Parse(skill)-1]
                };
                job.JobSkills.Add(jobSkill);
            }
            context.Jobs.Add(job);
            context.SaveChanges();

            return Redirect("/Add");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
