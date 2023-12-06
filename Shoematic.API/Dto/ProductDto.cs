using Shoematic.Data.Entities;
namespace Shoematic.API.Dto
{
    /* 
     * Article no.| name | color | sizes[] | category (men/women/children) | price | image | type(formal/casual)
     */
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Image{ get; set; }
        public List<string> Sizes { get; set; }
        public List<string> Categories { get; set; }

    }


}
