using System.ComponentModel.DataAnnotations;

namespace EelamHeroes.Models.Entity
{
    public class Gender
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
