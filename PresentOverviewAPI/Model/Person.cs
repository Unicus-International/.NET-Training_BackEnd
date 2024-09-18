using System.ComponentModel.DataAnnotations;

namespace PresentOverviewAPI.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
