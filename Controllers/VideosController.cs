﻿using CourseManager.Models;
using CourseManager.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VideoEdu video)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    video.Active = true;
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
    }
}
