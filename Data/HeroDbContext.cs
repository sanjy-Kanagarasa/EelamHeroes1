using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EelamHeroes.Models.Entity;

namespace EelamHeroes.Data
{
    public class HeroDbContext : IdentityDbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<RestingHome> RestingHomes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
