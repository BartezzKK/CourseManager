using CourseManager.Data;
using CourseManager.Models;
using CourseManager.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseManager.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly IVideoEduRepository videoEduRepository;
        private readonly ApplicationDbContext _context;

        public MaterialsController(ApplicationDbContext context, IVideoEduRepository videoEduRepository)
        {
            this._context = context;
            this.videoEduRepository = videoEduRepository;
        }


        [Authorize(Roles = "Administrator, Teacher, User")]
        [HttpGet]
        public IActionResult GetMaterialCategories()
        {
            if (this.User.IsInRole("User") && !UserHasPayment(this.User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("MissingPayment", "Administration");
            }
            return View();
        }

        [Authorize(Roles = "Administrator, Teacher, User")]
        [HttpGet]
        public IActionResult VideosEdu()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, Teacher, User")]
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

        private bool UserHasPayment(string userId)
        {
            return _context.Payments.Where(p => p.UserId == userId && DateTime.Today > p.PaymentDate && DateTime.Now < p.EndSubscription).Any();
        }
    }
}
