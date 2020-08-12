using System;
using System.ComponentModel.DataAnnotations;

namespace EelamHeroes.Models.Entity
{
    public class Hero
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string RealName { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public DateTime DeathDate { get; set; }
        [MaxLength(700)]
        public string Incident { get; set; }
        [MaxLength(700)]
        public string Comment { get; set; }
        [MaxLength(100)]
        public string Post { get; set; }

        public int DistrictId { get; set; }
        public int DivisionId { get; set; }
        public int GenderId { get; set; }
        public int RankId { get; set; }
        public int RestingHomeId { get; set; }
        
        public District District { get; set; }
        public Division Division { get; set; }
        public Gender Gender { get; set; }
        public Rank Rank { get; set; }
        public RestingHome RestingHome { get; set; }
    }
}
