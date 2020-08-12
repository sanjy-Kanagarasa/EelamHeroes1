namespace EelamHeroes.Models.Dto
{
    public class HeroDetailsDto: HeroDto
    {
        
        public string Incident { get; set; }
        public string Gender { get; set; }
        public string District { get; set; }
        public string Division { get; set; }
        public string RestingHome { get; set; }
        public string Comment { get; set; }
    }
}