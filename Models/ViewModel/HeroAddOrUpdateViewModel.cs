using System;

namespace EelamHeroes.Models.ViewModel
{
    public class HeroAddOrUpdateViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Address { get; set; }
        public DateTime DeathDate { get; set; } = new DateTime(2009, 5, 17);
        public DateTime? BirthDate { get; set; }

        public int GenderId { get; set; } = 1;
        public int RankId { get; set; } = 13;
        public int DistrictId { get; set; } = 11;
        public int DivisionId { get; set; } = 0;
        public int RestingHomeId { get; set; } = 21;
        public string Incident { get; set; }
        public string Comment { get; set; }
    }
}