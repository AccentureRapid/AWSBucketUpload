using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWSBucket.Models.DataModel
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FullUrl { get; set; }

        [Required]
        public string FileSize { get; set; }

        [Required]
        public string docType { get; set; }

        [Required]
        public int BucketId { get; set; }

        [ForeignKey("BucketId")]
        public Bucket Bucket { get; set; }

    }
}