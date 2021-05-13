using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using graduate_work.Common;
using graduate_work.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace graduate_work.Utils
{
    public class ImgService : IImgService
    {
        private AmazonS3Config s3ClientConfig = new AmazonS3Config
        {
            ServiceURL = ImgServiceConfig.ENDPOINT_URL
        };

        public void UploadFile(IFormFile file, string path)
        {
            try
            {
                using (var client = new AmazonS3Client(s3ClientConfig))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);

                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = memoryStream,
                            Key = file.FileName,
                            BucketName = ImgServiceConfig.BUCKET_NAME + @"/" + path,
                            CannedACL = S3CannedACL.PublicRead
                        };

                        var fileTransferUtility = new TransferUtility(client);
                        fileTransferUtility.UploadAsync(uploadRequest);
                    }
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }

        public void DeleteFile(string path, string fileName)
        {
            try
            {
                using (var client = new AmazonS3Client(s3ClientConfig))
                {
                    DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
                    {
                        BucketName = ImgServiceConfig.BUCKET_NAME + @"/" + path,
                        Key = fileName
                    };
                    client.DeleteObjectAsync(deleteObjectRequest);
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null 
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }
}
