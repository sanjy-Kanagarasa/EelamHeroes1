﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EelamHeroes.Models.Entity
{
    public class RestingHome
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Hero> EelamHeroes { get; set; }
    }
}
