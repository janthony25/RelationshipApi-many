namespace RelationShip8_7.Models.Dto
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string CarRego { get; set; }
        public string CarModel { get; set; }
        public List<MakeDto> Make { get; set; }
    }
}
