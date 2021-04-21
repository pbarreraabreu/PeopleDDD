using System.ComponentModel.DataAnnotations;

namespace PeopleDDD.Application.ViewModels
{
    public class PeopleViewModel
    {
        public int Id { get; set; }

    //    [Required(ErrorMessage = "The Name is Required")]
     //   [MinLength(2)]
    //    [MaxLength(100)]
        public string Name { get; set; }

     //   [Required(ErrorMessage = "The Surname is Required")]
     //   [MinLength(2)]
     //   [MaxLength(100)]
        public string Surname { get; set; }

     //   [Required(ErrorMessage = "The Dni is Required")]
        public string Dni { get; set; }

        public string Phone { get; set; }
    }
}
