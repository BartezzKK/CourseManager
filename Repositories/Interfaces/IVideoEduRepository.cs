using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repositories.Interfaces
{
    public interface IVideoEduRepository
    {
        VideoEdu GetVideos();
    }
}
