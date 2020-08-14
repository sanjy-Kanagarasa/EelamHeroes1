using System;

namespace EelamHeroes.Models.Dto
{
    public class FilterDto
    {
        public int PageNr { get; set; } = 1;
        public int PageSize { get; set; } = 18;
        public string Name { get; set; }
        public string RealName { get; set; }
        public int? RankId { get; set; }
        public int? DistrictId { get; set; }
        public int? RestingHomeId { get; set; }
        public int? DeathDay { get; set; }
        public int? DeathMonth { get; set; }
        public int? DeathYear{ get; set; }
        public DateTime? BirthDate { get; set; }
    }
}