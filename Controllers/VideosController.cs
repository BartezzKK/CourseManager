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
    public class VideosController : Controller
    {
        private readonly IVideoEduRepository videoEduRepository;

        public VideosController(IVideoEduRepository videoEduRepository)
        {
            this.videoEduRepository = videoEduRepository;
        }

        [HttpGet]

        public IActionResult List()
        {
            if (this.User.IsInRole("User") && !UserHasPayment(this.User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("MissingPayment", "Administration");
            }
            List<VideoEdu> videos = videoEduRepository.GetVideos();
            ViewBag.Videos = videos;
            ViewBag.PageTitle = "Videos";
            return View(videos);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            VideoEdu video = videoEduRepository.GetVideo(id);
            return View(video);
        }
        [Authorize(Roles = "Administrator, Teacher")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, Teacher")]
        [HttpPost]
        public async Task<IActionResult> Create(VideoEdu video)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    video.Active = true;
                    string endedUrl = video.VideoUrl.Split('=')[1];
                    video.VideoUrl = "https://www.youtube.com/embed/" + endedUrl;
                    videoEduRepository.Create(video);
                    if(videoEduRepository.Save() == true)
                    {
                        return RedirectToAction("List", "Videos");
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Nie udało się zapisać");
                throw;
            }
            return View(video);
        }

        private bool UserHasPayment(string userId)
        {
            return videoEduRepository.HasPayments(userId);
        }
    }
}