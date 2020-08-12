using System.Collections.Generic;
using System.Threading.Tasks;
using EelamHeroes.Data;
using EelamHeroes.Models.Entity;
using EelamHeroes.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EelamHeroes.Repository
{
    public class GeneralRepository:IGeneralRepository
    {
        private readonly HeroDbContext dbContext;

        public GeneralRepository(HeroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<District>> GetDistricts()
        {
            return await dbContext.Districts.ToListAsync();
        }

        public async Task<IEnumerable<Division>> GetDivisions()
        {
            return await dbContext.Divisions.ToListAsync();
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            return await dbContext.Genders.ToListAsync();
        }

        public async Task<IEnumerable<Rank>> GetRanks()
        {
            return await dbContext.Ranks.ToListAsync();
        }

        public async Task<IEnumerable<RestingHome>> GetRestingHomes()
        {
            return await dbContext.RestingHomes.ToListAsync();
        }
    }
}