using System;

namespace EelamHeroes.Models
{
    public class Filter
    {
        public int DistrictId { get; set; }
        public int DivisionId { get; set; }
        public int RankId { get; set; }
        public int RestingHomeId { get; set; }
        public DateTime DateOfDeath { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}