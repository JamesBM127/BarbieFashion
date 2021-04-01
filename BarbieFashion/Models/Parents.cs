using System.ComponentModel.DataAnnotations;

namespace BarbieFashion.Models
{
    public class Parents
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Parents()
        {
        }

        public Parents(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
