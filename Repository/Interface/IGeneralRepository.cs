using System.Collections.Generic;
using System.Threading.Tasks;
using EelamHeroes.Models.Entity;

namespace EelamHeroes.Repository.Interface
{
    public interface IGeneralRepository
    {
        Task<IEnumerable<District>> GetDistricts();
        Task<IEnumerable<Division>> GetDivisions();
        Task<IEnumerable<Gender>> GetGenders();
        Task<IEnumerable<Rank>> GetRanks();
        Task<IEnumerable<RestingHome>> GetRestingHomes();
    }
}