using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoematic.API.Dto;
using Shoematic.Data;
using Shoematic.Data.Entities;

namespace Shoematic.API.Controller
{
    public class ProductController:BaseController
    {
        public ShoematicDbContext Context { get; set; }
        public ProductController(ShoematicDbContext context)
        {
            Context = context; 
        }
        [HttpGet("Products")]
        public async Task<List<ProductDto>> GetProductList()
        {
            var products = Context.Products
                .Include(p=>p.ProductSizes).ThenInclude(ps=>ps.Size)
                .Include(p=>p.ProductCategories).ThenInclude(pc=>pc.Category)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Color = p.Color,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.ImageUrl,
                    Sizes = p.ProductSizes.Select(s=>s.Size.Name).ToList(),
                    Categories = p.ProductCategories.Select(s=>s.Category.Name).ToList()
                }).ToList();
            return products;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddNewProduct(AddProductRequestDto dto)
        {
            var product = new Product()
            {
                Color = dto.Color,
                Description = dto.Description,
                Name = dto.ProductName,
                Price = dto.Price,
                ArticleNumber = string.Empty,
                ImageUrl = dto.Image
            };
            
            var sizes = dto.Sizes.Select(s => new ProductSizes()
            {
                SizeId = s,
                Product = product
            });
            var categories = dto.Categories.Select(c => new ProductCategory()
            {
                CategoryId = c,
                Product = product,
            });

            await Context.Products.AddAsync(product);
            await Context.ProductSizes.AddRangeAsync(sizes);
            await Context.ProductCategories.AddRangeAsync(categories);

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return StatusCode(200);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await Context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
                return StatusCode(404, "Product Not found");
            Context.Products.Remove(product);
            await Context.SaveChangesAsync();
            return StatusCode(200, "Product deleted Successfully");
        }
    }
}
