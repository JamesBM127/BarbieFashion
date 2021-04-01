using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarbieFashion.Models
{
    public class Agency
    {
        [Key]
        public int Id { get; set; }
        public const string Name = "Barbie Fashion";
        public const string Email = "felixdenise08@gmail.com";
        public ICollection<InfoModel> Models { get; set; }

        public Agency()
        {
        }
    }
}
