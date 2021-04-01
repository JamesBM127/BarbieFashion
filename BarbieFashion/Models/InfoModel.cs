using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarbieFashion.Models
{
    //This is the class of Models that works in the agency.
    public class InfoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Nome Completo")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "{0} deve ser maior que {2} e menor que {1} dígitos")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} obrigatória")]
        [Display(Name = "Idade")]
        public int Age { get; set; }

        [Required(ErrorMessage = "{0} obrigatória")]
        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Display(Name = "Trabalho em tempo integral")]
        public bool FullTimeJob { get; set; }

        [Display(Name = "Trabalhar internacionalmente")]
        public bool InternationalWork { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Telefone")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Coloque um email válido")]
        public string Email { get; set; }
        public Parents Parents { get; set; }
        public Agency Agency { get; set; }

        public InfoModel()
        {
        }

        public InfoModel(int id, string name, int age, string city, bool fullTimeJob, bool internationalWork, string phoneNumber, string email, Parents parents, Agency agency)
        {
            Id = id;
            Name = name;
            Age = age;
            City = city;
            FullTimeJob = fullTimeJob;
            InternationalWork = internationalWork;
            PhoneNumber = phoneNumber;
            Email = email;
            Parents = parents;
            Agency = agency;
        }
    }
}
