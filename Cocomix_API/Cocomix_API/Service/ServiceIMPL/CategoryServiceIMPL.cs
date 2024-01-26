using AutoMapper;
using Cocomix_API.DataReponse;
using Cocomix_API.DTO;
using Cocomix_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cocomix_API.Service.ServiceIMPL
{
    public class CategoryServiceIMPL : CategoryService
    {
        private readonly QLCHContext db;
        private readonly IMapper map;

        public CategoryServiceIMPL(QLCHContext context, IMapper mapper)
        {
            db = context;
            map = mapper;
        }

        public async Task<CategoryReponse> AddCategory(CategoryDTO categoryDTO)
        {
            var category = map.Map<Category>(categoryDTO);
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return map.Map<CategoryReponse>(category);
        }

        public async Task<string> DeleteCategory(int id)
        {
            var category = await db.Categories.FindAsync(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
                return "delete category success";
            }
            return null;
        }

        public async Task<CategoryReponse> GetCategory(int id)
        {
            var category = await db.Categories.FindAsync(id);
            if (category != null)
            {
                return map.Map<CategoryReponse>(category);
            }
            return null;
        }

        public async Task<List<CategoryReponse>> GetListCategory()
        {
            var list_category = await db.Categories.ToListAsync();
            return map.Map<List<CategoryReponse>>(list_category);
        }

        public async Task<CategoryReponse> UpdateCategory(int id, CategoryDTO categoryDTO)
        {
            var category_old = await db.Categories.FindAsync(id);
            if (category_old != null)
            {
                map.Map(categoryDTO, category_old);
                await db.SaveChangesAsync();
                return map.Map<CategoryReponse>(category_old);
            }
            return null;
        }
    }
}
