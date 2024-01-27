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

        public async Task<string> addProducttoCategory(int idCategory, int idProduct)
        {
            var category = await db.Categories.FindAsync(idCategory);
            var product = await db.Products.FindAsync(idProduct);

            if(product != null)
            {
                if(category != null) 
                {
                    var existingRelation = await db.ProductCategories.FirstOrDefaultAsync(pc => pc.ProductId == idProduct && pc.CategoryId == idCategory);
                    if(existingRelation == null) 
                    {
                        var pc = new ProductCategory
                        {
                            ProductId = idProduct,
                            CategoryId = idCategory
                        };
                        db.ProductCategories.Add(pc);
                        await db.SaveChangesAsync();
                        return "Add category to product sccess";
                    }
                    return "Exist Relation";
                }
                return "not found category";
            }
            return "not found product";
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

        public async Task<string> deleteProductToCategory(int idCategory, int idProduct)
        {
            var product_category = await db.ProductCategories.FirstOrDefaultAsync(pc => pc.ProductId == idProduct && pc.CategoryId == idCategory );
            if (product_category != null)
            {
                db.ProductCategories.Remove(product_category);
                await db.SaveChangesAsync();
                return "Delete product to category success";
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

        public async Task<List<ProductCategoryReponse>> getListProductByCategoryID(int idCategory)
        {
            var productCategories = await db.ProductCategories
                                        .Where(pc => pc.CategoryId == idCategory)
                                        .ToListAsync();
            List<ProductCategoryReponse> list_pc = new List<ProductCategoryReponse>();
            foreach(var pc in productCategories)
            {
                ProductCategoryReponse productCategory = new ProductCategoryReponse
                {
                    productReponse = map.Map<ProductReponse>(await db.Products.FindAsync(pc.ProductId)),
                    categoryReponse = map.Map<CategoryReponse>(await db.Categories.FindAsync(pc.CategoryId))
                };
                list_pc.Add(productCategory);
            }
            return list_pc;
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
