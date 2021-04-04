using System.ComponentModel.DataAnnotations;

namespace BarbieFashion.Models
{
    public class Parents
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Nome do responsável")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Idade do responsável")]
        public int Age { get; set; }

        public InfoModel InfoModel { get; set; }
        public int InfoModelId { get; set; }

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
