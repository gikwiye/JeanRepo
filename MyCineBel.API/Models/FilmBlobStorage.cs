using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
    public class FilmBlobStorage
    {
        public Film film { get; set; }

        public IFormFile filmImage {get; set;}


    }
}
