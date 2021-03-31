namespace BarbieFashion.Models
{
    public class Parents
    {
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
