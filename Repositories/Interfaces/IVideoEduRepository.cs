using CourseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repositories.Interfaces
{
    public interface IVideoEduRepository
    {
        List<VideoEdu> GetVideos();
        VideoEdu GetVideo(int id);
        void Create(VideoEdu video);
        bool Save();
        bool Delete(int id);
        bool HasPayments(string userId);
    }
}
