using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViVuStoreApi.Models
{
    public class Pie
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Descriptions { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string ImageThumbnailUrl { get; set; }

        public bool IsInStock { get; set; }

        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
