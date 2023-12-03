using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoematic.Data.Entities
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string SubCatName { get; set; }
        public int? MainCatID { get; set; }

        // Navigation property
        [ForeignKey(nameof(MainCatID))]
        public Category MainCategory { get; set; }
        public ICollection<Size> Sizes { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
