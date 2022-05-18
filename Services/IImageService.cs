using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogApplication.Services
{
    public interface IImageService
    {
        Task<byte[]> EncodeImageAsync (IFormFile file);     //new  into the DB
        Task<byte[]> EncodeImageAsync (string fileName);    //default image from the DB (holds path)
        string DecodeImage(byte[] data, string type);       //displays image
        string ContentType(IFormFile file);                 //return image type
        int Size(IFormFile file);                           //image size
    }
}
