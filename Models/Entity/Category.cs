using System.ComponentModel.DataAnnotations;

namespace EelamHeroes.Models.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MaxLength(100)] 
        public string Name { get; set; }
        [MaxLength(500)] 
        public string Description { get; set; }
        [Required, MaxLength(200)] 
        public string ImagePath { get; set; }
    }
}