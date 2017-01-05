using System.Data.Entity;

namespace AWSBucket.Models.DataModel
{
    public class Context : DbContext 
    {
        public Context(): base("name=DefaultConnection")
        {

        }

        public DbSet<Bucket> Buckets { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}