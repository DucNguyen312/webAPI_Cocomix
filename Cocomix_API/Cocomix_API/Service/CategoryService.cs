using Cocomix_API.DataReponse;
using Cocomix_API.DTO;
using Cocomix_API.Models;

namespace Cocomix_API.Service
{
    public interface CategoryService
    {
        public Task<List<CategoryReponse>> GetListCategory();
        public Task<CategoryReponse> GetCategory(int id);
        public Task<CategoryReponse> AddCategory(CategoryDTO categoryDTO);
        public Task<CategoryReponse> UpdateCategory(int id, CategoryDTO categoryDTO);
        public Task<string> DeleteCategory(int id);
        public Task<List<ProductCategoryReponse>> getListProductByCategoryID(int idCategory);

        public Task<string> addProducttoCategory(int idCategory, int idProduct);
        public Task<string> deleteProductToCategory(int idCategory, int idProduct);
    }
}
