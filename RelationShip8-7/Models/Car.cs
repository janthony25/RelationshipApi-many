using System.ComponentModel.DataAnnotations;

namespace RelationShip8_7.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string CarRego { get; set; }
        public string CarModel { get; set; }

        // FK to customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // one-to-many Car-Make
        public List<CarMake> CarMake { get; set; }

    }
}
