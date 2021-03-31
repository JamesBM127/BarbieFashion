using System.Collections.Generic;

namespace BarbieFashion.Models
{
    public class Agency
    {
        public const string Name = "Barbie Fashion";
        public const string Email = "felixdenise08@gmail.com";
        public ICollection<InfoModel> Models { get; set; }

        public Agency()
        {
        }
    }
}
