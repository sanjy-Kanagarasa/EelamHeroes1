using System.Collections.Generic;
using System.Threading.Tasks;
using EelamHeroes.Models;
using EelamHeroes.Models.Entity;
using EelamHeroes.Models.ViewModel;

namespace EelamHeroes.Repository.Interface
{
    public interface IPostRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<PagedList<Post>> GetPostsByCategory(int categoryId, int pageNr, int perPage);
        Task<Post> GetPostById(int postId);
        Task AddOrUpdate(PostAddOrUpdateViewModel model);
    }
}