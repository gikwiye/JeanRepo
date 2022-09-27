using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface INewsService
    {
        Task<List<News>> GetAllNewsAsync();

        Task<News> GetNewsAsync();

        Task<News> GetNewsAsync(int id);

        Task<News> PostNewsAsync(News news);

        Task<News> PutNewsAsync(News news);

        Task DeleteNewsAsync(int newsId);
    }
}
