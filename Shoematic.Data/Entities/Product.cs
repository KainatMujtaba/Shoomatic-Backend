using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shoematic.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal SellPrice { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubCatId { get; set; }
        public int GenderId { get; set; }
        public int SizesId { get; set; }
        public string Description { get; set; }
        public string ProductDetails { get; set; }
        public string MaterialCare { get; set; }
        public int FreeDelivery { get; set; }
        public int _30DayRet { get; set; }
        public int COD { get; set; }

        // Navigation properties
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [ForeignKey(nameof(SubCatId))]
        public SubCategory SubCategory { get; set; }

        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; }


        [ForeignKey(nameof(SizesId))]
        public Size Size { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductSizeQuantity> ProductSizeQuantities { get; set; }
    }
}
