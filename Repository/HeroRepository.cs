using EelamHeroes.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EelamHeroes.Models;
using EelamHeroes.Models.Dto;
using EelamHeroes.Models.Entity;
using EelamHeroes.Models.ViewModel;
using EelamHeroes.Repository.Interface;

namespace EelamHeroes.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroDbContext dbContext;
        private readonly IMapper mapper;

        public HeroRepository(HeroDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<HeroDto>> Get(int? dYear, int? dMonth, int? dDay, int? districtId)
        {
            return await Task.Run(() =>
            {

                var queryResult =
                    dbContext.Heroes.Include(h => h.Rank).AsQueryable();

                if (dYear.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DeathDate.Year == dYear);
                }
                if (dMonth.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DeathDate.Month == dMonth);
                }
                if (dDay.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DeathDate.Day == dDay);
                }
                if (districtId.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DistrictId == districtId);
                }
                var result =  queryResult.ToList();
                return mapper.Map<List<HeroDto>>(result);
            });
        }

        public async Task<Hero> GetById(int id)
        {
            var hero = await dbContext.Heroes
                .Include(h => h.Rank)
                .Include(h => h.District)
                .Include(h => h.RestingHome)
                .Include(h => h.Gender)
                .Include(h => h.Division)
                .FirstOrDefaultAsync(h => h.Id == id);
            return hero;
        }

        public async Task<PagedList<Hero>> GetByPage(FilterDto flt)
        {
            return await Task.Run(() =>
            {

                var queryResult =
                    dbContext.Heroes.Include(h => h.Rank)
                        .OrderBy(h => h.DeathDate).AsQueryable();

                
                if (flt.BirthDate.HasValue)
                {
                    queryResult = queryResult.Where(q => q.BirthDate == flt.BirthDate);
                }
                if (flt.DeathDay.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DeathDate.Day == flt.DeathDay);
                }
                if (flt.DeathMonth.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DeathDate.Month == flt.DeathMonth);
                }
                if (flt.DeathYear.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DeathDate.Year == flt.DeathYear);
                }
                if (flt.DistrictId.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DistrictId == flt.DistrictId);
                }
                if (flt.RankId.HasValue)
                {
                    queryResult = queryResult.Where(q => q.RankId == flt.RankId);
                }
                if (flt.RestingHomeId.HasValue)
                {
                    queryResult = queryResult.Where(q => q.RestingHomeId == flt.RestingHomeId);
                }
                if (!string.IsNullOrWhiteSpace(flt.Name))
                {
                    queryResult = queryResult.Where(q => q.Name.Contains(flt.Name));
                }
                if (!string.IsNullOrWhiteSpace(flt.RealName))
                {
                    queryResult = queryResult.Where(q => q.RealName.Contains(flt.RealName));
                }
                var result =  PagedList<Hero>.ToPagedList(queryResult, flt.PageNr, flt.PageSize);
                return result;
            });
        }

        public async Task<PagedList<Hero>> Memorial(int pageNr, int perPage, int? dYear, int? districtId)
        {
            
            return await Task.Run(() =>
            {
                var today = DateTime.Now;
                var queryResult = dbContext.Heroes
                    .Include(h => h.Rank)
                    .Where(h => h.DeathDate.Month == today.Month && h.DeathDate.Day == today.Day)
                    .AsQueryable();
                if (dYear.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DeathDate.Year == dYear);
                }
                if (districtId.HasValue)
                {
                    queryResult = queryResult.Where(q => q.DistrictId == districtId);
                }
                var result =  PagedList<Hero>.ToPagedList(queryResult, pageNr, perPage);

                return result;
            });
        }

        public async Task AddOrUpdate(HeroAddOrUpdateViewModel model)
        {
            var hero = await dbContext.Heroes.FindAsync(model.Id);
            if (hero != null)
            {
                mapper.Map(model, hero);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                var newHero = mapper.Map<Hero>(model);
                dbContext.Add(newHero);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}