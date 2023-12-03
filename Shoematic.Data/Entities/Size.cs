using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shoematic.Data.Entities
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /*public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int GenderId { get; set; }

        // Navigation properties
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public Gender Gender { get; set; }*/
    }
}
