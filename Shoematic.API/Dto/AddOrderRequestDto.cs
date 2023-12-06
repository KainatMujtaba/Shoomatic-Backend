namespace Shoematic.API.Dto
{
    public class AddOrderRequestDto
    {
        public int UserId { get; set; }    
        public int ProductId { get; set; }
        public int SizeId { get; set; }
    }
}
