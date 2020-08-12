using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EelamHeroes.Data;
using EelamHeroes.Models;
using EelamHeroes.Models.Entity;
using EelamHeroes.Models.ViewModel;
using EelamHeroes.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EelamHeroes.Repository
{
    public class PostRepository: IPostRepository
    {
        private readonly HeroDbContext dbContext;
        private readonly IMapper mapper;

        public PostRepository(HeroDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                return await dbContext.Categories.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<PagedList<Post>> GetPostsByCategory(int categoryId, int pageNr, int perPage)
        {
            return await Task.Run(() =>
            {
                var queryResult = dbContext.Posts.Where(p => p.CategoryId == categoryId)
                    .AsQueryable();
                var result =  PagedList<Post>.ToPagedList(queryResult, pageNr, perPage);

                return result;
            });
        }

        public async Task<Post> GetPostById(int postId)
        {
            return await dbContext.Posts.FindAsync(postId);
        }
        public async Task AddOrUpdate(PostAddOrUpdateViewModel model)
        {
            var post = await dbContext.Posts.FindAsync(model.Id);
            if (post != null)
            {
                mapper.Map(model, post);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                var newPost = mapper.Map<Post>(model);
                dbContext.Add(newPost);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}