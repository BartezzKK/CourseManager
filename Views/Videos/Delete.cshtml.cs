using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Models;
using CourseManager.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManager.Views.Videos
{
    public class DeleteModel : PageModel
    {
        private readonly IVideoEduRepository videoEduRepository;

        public DeleteModel(IVideoEduRepository videoEduRepository)
        {
            this.videoEduRepository = videoEduRepository;
        }
        [BindProperty]
        public VideoEdu Video { get; set; }
        public void OnGet()
        { 
        }
    }
}
