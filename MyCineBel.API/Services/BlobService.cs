using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using MyCineBel.API.Extensions;
using MyCineBel.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCineBel.API.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        //represente le contenaire utilisé sur azure
        private readonly string contenaire = "cineimage";

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task DeleteBlobAsync(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(contenaire);

            var blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<BlobInfo> GetBlobAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(contenaire);
            var blobClient = containerClient.GetBlobClient(name);
            var blobDownLoadInfo = await blobClient.DownloadAsync();


            return new BlobInfo(blobDownLoadInfo.Value.Content, blobDownLoadInfo.Value.ContentType);
        }



        public async Task<IEnumerable<string>> ListBlobAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(contenaire);
            var items = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }

            return items;
        }

        public Task UpLoadContentBlobAsync(string content, string filename)
        {
            throw new NotImplementedException();
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(contenaire);

            var blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(filePath, new Azure.Storage.Blobs.Models.BlobHttpHeaders { ContentType = filePath.GetContentType() });

        }

        public async Task UploadStreamBlobAsync(IFormFile file, string fileName)
        {
            await using (var memoryStream = new MemoryStream())
            {
                //Turn IFormFile to a Stream
                await file.CopyToAsync(memoryStream);

                //Turn Stream to Bytes
                //for Encryption
                //var bytes = memoryStream.ToArray();

                //Otherwise upload is frozen
                memoryStream.Position = 0;
                //Upload to blob storag

                var containerClient = _blobServiceClient.GetBlobContainerClient(contenaire);

                var blobClient = containerClient.GetBlobClient(file.FileName);

                await blobClient.UploadAsync(memoryStream, new Azure.Storage.Blobs.Models.BlobHttpHeaders { ContentType = file.ContentType });

            }


        }
    }
}
