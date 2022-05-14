using CourseManager.Data;
using CourseManager.Models;
using CourseManager.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repositories
{
    public class VideoEduRepository : IVideoEduRepository
    {
        private readonly ApplicationDbContext _context;
        public VideoEduRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public VideoEdu GetVideo(int id)
        {
            return Videos.Where(p => p.Id == id).FirstOrDefault();
        }

        public List<VideoEdu> GetVideos()
        {
            return _context.VideoEdus.ToList();
            
        }

        public void Create(VideoEdu video)
        {
            _context.VideoEdus.Add(video);
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            VideoEdu video = GetVideo(id);
            if(video != null)
            {
                _context.Remove(video);
                Save();
                return true;
            }
            return false;
        }


        private List<VideoEdu> Videos = new List<VideoEdu>
        {
            new VideoEdu
                {
                    Id = 1,
                    Name = "Film szkolenie",
                    Active = true,
                    VideoUrl = "https://www.youtube.com/embed/BPGtVpu81ek",
                    UserId = "318aca4f-fa16-48eb-9672-2342252245f2"
                },
            new VideoEdu
                {
                    Id = 2,
                    Name = "Film szkolenie2",
                    Active = true,
                    VideoUrl = "https://www.youtube.com/embed/BPGtVpu81ek",
                    UserId = "318aca4f-fa16-48eb-9672-2342252245f2"
                },
            new VideoEdu
                {
                    Id = 3,
                    Name = "Film szkolenie3",
                    Active = true,
                    VideoUrl = "https://www.youtube.com/embed/BPGtVpu81ek",
                    UserId = "318aca4f-fa16-48eb-9672-2342252245f2"
                },
            new VideoEdu
                {
                    Id = 4,
                    Name = "Film szkolenie4",
                    Active = true,
                    VideoUrl = "https://www.youtube.com/embed/BPGtVpu81ek",
                    UserId = "318aca4f-fa16-48eb-9672-2342252245f2"
                }
        };
    }
}
