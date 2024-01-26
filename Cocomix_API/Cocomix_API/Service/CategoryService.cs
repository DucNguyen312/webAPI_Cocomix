using Cocomix_API.DataReponse;
using Cocomix_API.DTO;

namespace Cocomix_API.Service
{
    public interface CategoryService
    {
        public Task<List<CategoryReponse>> GetListCategory();
        public Task<CategoryReponse> GetCategory(int id);
        public Task<CategoryReponse> AddCategory(CategoryDTO categoryDTO);
        public Task<CategoryReponse> UpdateCategory(int id, CategoryDTO categoryDTO);
        public Task<string> DeleteCategory(int id);
    }
}
