using Microsoft.EntityFrameworkCore;
using MyCineBel.API.DAL;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class NewsService : INewsService
    {
        private readonly ProjetMyCinebelContext _context;

        public NewsService(ProjetMyCinebelContext context)
        {
            _context = context;
        }

        //Effacer une nouvelle
        public async Task DeleteNewsAsync(int newsId)
        {
            var news = await _context.News.FindAsync(newsId);

            if (news != null)
            {
                _context.Remove(news);
            }

            await _context.SaveChangesAsync();
        }

        //avoir tous les nouvelles
        public  async Task<List<News>> GetAllNewsAsync()
        {
            //return await _context.News.OrderByDescending(x => x.NEWS_Date).ToListAsync();

            return  await _context.News.FromSqlRaw("SelectAllNews").ToListAsync();
        }

        //retirer la première nouvelle
        public async Task<News> GetNewsAsync()
        {
            var news = await _context.News.OrderByDescending(x => x.NEWS_Date).FirstAsync();

            return news;
        }

        //retire une nouvelle précise
        public  async Task<News> GetNewsAsync(int newsId)
        {
            var news = await _context.News.FirstOrDefaultAsync(X => X.NEWS_Id == newsId);

            return news;
        }

        // Créer une nouvelle
        public async Task<News> PostNewsAsync(News news)
        {
            news.NEWS_Date = DateTime.Now;

            _context.News.Add(news);

            await _context.SaveChangesAsync();

            return news;
        }

        //mettre à jour une nouvelle
        public async Task<News> PutNewsAsync(News news)
        {
            _context.Entry(news).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return news;
        }
    }
}
