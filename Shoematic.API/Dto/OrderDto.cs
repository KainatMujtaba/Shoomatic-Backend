using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shoematic.Data.Entities;
using System.Net;

namespace Shoematic.API.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName {  get; set; }
        public string ProductDescription { get; set; }
        public string ProductColor { get; set; }
        public decimal ProductPrice { get; set; }
        public string UserName { get; set; }
        public string UserAddress {  get; set; }
        public string Size { get;set; }


    }
}
