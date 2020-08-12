using System.ComponentModel.DataAnnotations;

namespace EelamHeroes.Models.Entity
{
    public class Post
    {
        public int Id { get; set; }
        [Required, MaxLength(200)] 
        public string Title { get; set; }
        [Required] 
        public string Body { get; set; }
        [Required, MaxLength(200)] 
        public string Excerpt { get; set; }
        [Required, MaxLength(200)] 
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}