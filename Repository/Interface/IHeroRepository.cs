using System.Collections.Generic;
using System.Threading.Tasks;
using EelamHeroes.Models;
using EelamHeroes.Models.Dto;
using EelamHeroes.Models.Entity;
using EelamHeroes.Models.ViewModel;

namespace EelamHeroes.Repository.Interface
{
    public interface IHeroRepository
    {
        Task<PagedList<Hero>> GetByPage(FilterDto filter);
        Task<IEnumerable<HeroDto>> Get(int? dYear, int? dMonth, int? dDay, int? districtId);
        Task<Hero> GetById(int id);
        Task<PagedList<Hero>> Memorial(int pageNr, int perPage, int? dYear, int? districtId);
        Task AddOrUpdate(HeroAddOrUpdateViewModel model);
    }
}
