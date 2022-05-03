using CourseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Controllers
{
    public class MaterialsController : Controller
    {

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
    }
}
