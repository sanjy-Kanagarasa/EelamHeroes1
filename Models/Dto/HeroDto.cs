using System;

namespace EelamHeroes.Models.Dto
{
    public class HeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Rank { get; set; }
        public string Address { get; set; }
        public DateTime DeathDate { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
