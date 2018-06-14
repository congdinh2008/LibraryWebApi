using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViVuStoreApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public List<Pie> Pies { get; set; }
    }
}