using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Models
{
   

        public class BlobInfo
        {
            public BlobInfo(Stream content, string contentType)
            {
                Content = content;
                ContentType = contentType;
            }

            public Stream Content { get; set; }
            public string ContentType { get; set; }
        }
    
}
