using System.ComponentModel.DataAnnotations;

namespace RelationShip8_7.Models
{
    public class Make
    {
        [Key]
        public int MakeId { get; set; }
        public string MakeName { get; set; }

        // one-to-many Car-Make
        public List<CarMake> CarMake { get; set; }
    }
}
