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
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public bool FullTimeJob { get; set; }
        public bool InternationalWork { get; set; }
        public string PhoneNumber { get; set; }
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
