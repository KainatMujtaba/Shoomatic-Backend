using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoematic.Data.Entities
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public string GenderName { get; set; }

        // Navigation properties
        //public ICollection<Size> Sizes { get; set; }
      //  public ICollection<Product> Products { get; set; }
    }
}
