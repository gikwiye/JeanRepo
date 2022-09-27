using Microsoft.AspNetCore.Http;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public interface IBlobService
    {
        public Task<BlobInfo> GetBlobAsync(string name);

        public Task<IEnumerable<string>> ListBlobAsync();

        public Task UploadFileBlobAsync(string filePath, string filename);


        public Task UpLoadContentBlobAsync(string content, string filename);

        public Task DeleteBlobAsync(string blobName);

        public Task UploadStreamBlobAsync(IFormFile file, string fileName);


    }
}
