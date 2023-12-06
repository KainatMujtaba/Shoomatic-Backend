namespace Shoematic.API.Dto
{
    public class AddProductRequestDto
    {
        public decimal Price { get; set; }
        public string ProductName {  get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public List<int> Sizes { get; set; }
        public List<int> Categories { get; set; }
    }
}
