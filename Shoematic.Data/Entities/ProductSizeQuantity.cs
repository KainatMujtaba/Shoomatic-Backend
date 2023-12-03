using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoematic.Data.Entities
{
    public class ProductSizeQuantity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
/*
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; }*/
    }
}
