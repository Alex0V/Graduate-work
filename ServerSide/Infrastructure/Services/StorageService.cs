using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Application.Models;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class StorageService : IStorageService
{
    private readonly IConfiguration _config;

    public StorageService(IConfiguration configuration) 
    {
        _config = configuration;
    }
    public async Task<S3ResponseDto> UploadFileAsync(IFormFile image)
    {
        var awsCredentials = new AwsCredentials()
        {
            AwsKey = _config["AwsConfiguration:AwsAccessKey"],
            AwsSecretKey = _config["AwsConfiguration:AwsSecretKey"]
        };
        var response = new S3ResponseDto();

        await using var memoryStr = new MemoryStream();
        await image.CopyToAsync(memoryStr);

        var fileExt = Path.GetExtension(image.FileName);
        if (string.IsNullOrEmpty(fileExt))
        {
            response.StatusCode = 400;
            response.Message = $"Path.GetExtension don't get extention({fileExt})";
            return response;
        }
        var objName = $"{Guid.NewGuid()}{fileExt}";
        var credential = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

        var config = new AmazonS3Config()
        {
            RegionEndpoint = Amazon.RegionEndpoint.EUWest2,
        };
        try
        {
            var uploadRequest = new TransferUtilityUploadRequest()
            {
                InputStream = memoryStr,
                Key = objName.ToString(),
                BucketName = "medi-coursework",
                CannedACL = S3CannedACL.NoACL
            };
            using var client = new AmazonS3Client(credential, config);
            var transferUtility = new TransferUtility(client);
            await transferUtility.UploadAsync(uploadRequest);
            response.StatusCode = 200;
            response.Message = $"file uploaded successfully";
            response.FileName = objName;
        }
        catch(AmazonS3Exception ex)
        {
            response.StatusCode = (int)ex.StatusCode;
            response.Message = ex.Message;
        }catch(Exception ex)
        {
            response.StatusCode = 500;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<string> GetPrivateImageUrlAsync(string fileName)
    {
        var awsCredentials = new AwsCredentials()
        {
            AwsKey = _config["AwsConfiguration:AwsAccessKey"],
            AwsSecretKey = _config["AwsConfiguration:AwsSecretKey"]
        };
        var credential = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);
        var config = new AmazonS3Config()
        {
            RegionEndpoint = Amazon.RegionEndpoint.EUWest2,
        };
        using (var client = new AmazonS3Client(credential, config))
        {
            var request = new Amazon.S3.Model.GetPreSignedUrlRequest
            {
                BucketName = "medi-coursework",
                Key = fileName,
                Expires = DateTime.UtcNow.AddDays(7) // Тривалість дії підписаного URL
            };
            string url = client.GetPreSignedURL(request);
            return url;
        }
    }

    public async Task DeleteFileAsync(string fileName)
    {
        var awsCredentials = new AwsCredentials()
        {
            AwsKey = _config["AwsConfiguration:AwsAccessKey"],
            AwsSecretKey = _config["AwsConfiguration:AwsSecretKey"]
        };
        var credential = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);
        var config = new AmazonS3Config()
        {
            RegionEndpoint = Amazon.RegionEndpoint.EUWest2,
        };
        using (var client = new AmazonS3Client(credential, config))
        {
            var request = new Amazon.S3.Model.DeleteObjectRequest
            {
                BucketName = "medi-coursework",
                Key = fileName
            };
            await client.DeleteObjectAsync(request);
        }
    }
}
