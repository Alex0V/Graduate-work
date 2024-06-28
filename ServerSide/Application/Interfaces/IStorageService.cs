using Microsoft.AspNetCore.Http;
using Application.Models;

namespace Application.Interfaces;

public interface IStorageService
{
    Task<S3ResponseDto> UploadFileAsync(IFormFile image);
    Task<string> GetPrivateImageUrlAsync(string fileName);
    Task DeleteFileAsync(string fileName);

}
