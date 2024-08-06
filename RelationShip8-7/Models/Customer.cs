using System.ComponentModel.DataAnnotations;

namespace RelationShip8_7.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public ICollection<Car> Car { get; set; }
    }
}
