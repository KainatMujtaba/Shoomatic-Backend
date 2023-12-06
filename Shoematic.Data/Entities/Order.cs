using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoematic.Data.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate{  get; set; }
        
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(UserId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; }
    }
}
