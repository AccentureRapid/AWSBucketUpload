using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWSBucket.Models.DataModel
{
    public class Bucket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BucketId { get; set; }
        [Required]
        public string BucketName { get; set; }
    }
}