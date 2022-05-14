using CourseManager.Models;
using CourseManager.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly IVideoEduRepository videoEduRepository;

        public MaterialsController(IVideoEduRepository videoEduRepository)
        {
            this.videoEduRepository = videoEduRepository;
        }

        [HttpGet]
        public IActionResult GetMaterialCategories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VideosEdu()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateVideo(VideoViewModel video)
        {
            //if(ModelState.IsValid)
            //{
            //    VideoViewModel video = new V
            //}
            return View();
        }

        //[HttpGet]
        //public ViewResult Videos()
        //{
        //    VideoEdu video = videoEduRepository.GetVideos().First();
        //    return View(video);
        //}
    }
}
