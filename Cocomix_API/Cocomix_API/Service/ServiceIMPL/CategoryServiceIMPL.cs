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
            //FindAsync là viết tắc của SELECT * FROM Bảng Where id = ?
            var category = await db.Categories.FindAsync(idCategory);  //Tìm loại
            var product = await db.Products.FindAsync(idProduct);  //Tìm sản phẩm

            if(product != null) //Kiểm tra sản phẩm có tồn tại hay không ?
            {
                if(category != null) 
                {
                    //.FirstOrDefaultAsync : Lấy dòng đầu tiên trong dữ liệu   (pc => pc...) pc là từ viết tắt của ProductCategory , muốn đặt thành gì cũng được
                    //Select * from ProductCategory pc where pc.ProductID = ? and pc.CategoryID = ? 
                    var existingRelation = await db.ProductCategories.FirstOrDefaultAsync(pc => pc.ProductId == idProduct && pc.CategoryId == idCategory);
                    //Công dụng : Kiểm tra sản phẩm đã tồn tại thể loại đó hay chưa ?

                    if(existingRelation == null) //Nếu chưa tồn tại thì ..
                    {
                        var pc = new ProductCategory
                        {
                            ProductId = idProduct,
                            CategoryId = idCategory
                        };
                        db.ProductCategories.Add(pc);
                        await db.SaveChangesAsync();
                        return "Add category to product sccess";
                    } //Tồn tại thì thông báo đã tồn tại
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
            //Kiểm tra xem sản phẩm có thể loại đó hay ko ?
            var product_category = await db.ProductCategories.FirstOrDefaultAsync(pc => pc.ProductId == idProduct && pc.CategoryId == idCategory );
            if (product_category != null) //Nếu có thì xóa
            {
                db.ProductCategories.Remove(product_category);
                await db.SaveChangesAsync();
                return "Delete product to category success";
            } //Không có thì báo null hoặc trả thẳng về "không tìm thấy để xóa"
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
            if (category_old != null || categoryDTO != null)
            {
                category_old.Name = categoryDTO.Name ?? category_old.Name;
                await db.SaveChangesAsync();
                return map.Map<CategoryReponse>(category_old);
            }
            return null;
        }

        
    }
}
