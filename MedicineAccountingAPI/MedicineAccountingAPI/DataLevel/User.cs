using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAccountingAPI.DataLevel
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ("Name is required.")), 
          RegularExpression(@"^[a-zA-Z]*$",
            ErrorMessage = "Only alphabetic characters are allowed."),
            MinLength(2)]
        public string Name { get; set; }
        [Required(ErrorMessage = ("Login is required."))]
        [MinLength(4)]
        public string Login { get; set; }
        [Required(ErrorMessage = ("Password is required."))]
        [MinLength(4)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$")]
        public string Email { get; set; }
    }
}
