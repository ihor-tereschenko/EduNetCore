using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicInfo.Models
{
    public interface INewsRepository
    {
        List<News> GetNews();
        void AddNews(News news);
        void DelNews(int id);
        void UpdNews(int id, News news1);
        void PatchNews(int id, News news1);
    }
}
