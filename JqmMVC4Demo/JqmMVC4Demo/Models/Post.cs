using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JqmMVC4Demo.Models
{
    public class Post
    {
        [Key]
        public Int64 ID { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string PostContent { get; set; }
        public DateTime PublishDate { get; set; }
    }
}