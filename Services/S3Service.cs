using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;

namespace AWSBucket.Services
{
    public class S3Service
    {
        public string AddBucket(string bucketName)
        {
             var config = WebConfigurationManager.OpenWebConfiguration("~");
            var settings = (AppSettingsSection)config.GetSection("appSettings");
            var accName = settings.Settings["AWSAccessKeyId"].Value;
            var accKey = settings.Settings["AWSSecretKey"].Value;

            AmazonS3Config conf = new AmazonS3Config();

            AmazonS3Client client = new AmazonS3Client(accName, accKey, conf);
            PutBucketRequest request = new PutBucketRequest();
            if (!AmazonS3Util.DoesS3BucketExist(client, bucketName))
            {
                request.BucketName = bucketName;
                client.PutBucket(request);
                return "bucket Created";
            }
            else
            {
                return "bucket already exsists";
            }
        }

        public IEnumerable<string> GetBucketList()
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var settings = (AppSettingsSection)config.GetSection("appSettings");
            var accName = settings.Settings["AWSAccessKeyId"].Value;
            var accKey = settings.Settings["AWSSecretKey"].Value;
             AmazonS3Config conf = new AmazonS3Config();

            AmazonS3Client client = new AmazonS3Client(accName, accKey, conf);

            ListBucketsResponse response =  client.ListBuckets();

            List<string> buck = new List<string>();
            foreach(S3Bucket b in response.Buckets)
            {
                buck.Add(b.BucketName);
            }

            return buck;
        }
    }
}