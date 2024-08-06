namespace RelationShip8_7.Models.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<CarDto> Cars { get; set; }
    }
}
