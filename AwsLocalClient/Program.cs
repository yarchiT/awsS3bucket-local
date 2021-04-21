using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace AwsLocalClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var awsClient = new AmazonS3Client(new AmazonS3Config
            {
                UseHttp = true,
                ServiceURL = "http://localhost:4566",
                ForcePathStyle = true,
            });

            // how to list objects
            var listResponse = await awsClient.ListObjectsV2Async(new ListObjectsV2Request
            {
                Prefix = "my-bucket",
                BucketName = "my-bucket"
            });
            
            
            // how to get specific object
            var imageFile = await awsClient.GetObjectAsync(new GetObjectRequest
            {
                Key = "Data/image.jpg",
                BucketName = "my-bucket"
            });
            
            Console.WriteLine($"S3Object data: key {imageFile.Key}.");

            foreach (var metadataKey in imageFile.Metadata.Keys)
            {
                Console.WriteLine($"Metadata key: {metadataKey}.");
            }
        }
    }
}