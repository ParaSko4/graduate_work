using Microsoft.AspNetCore.Http;

namespace graduate_work.Interfaces.Services
{
    public interface IImgService
    {
        void UploadFile(IFormFile file, string path);
        void DeleteFile(string path, string fileName);
    }
}
