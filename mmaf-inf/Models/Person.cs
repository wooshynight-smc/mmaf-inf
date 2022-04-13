using System;
using System.ComponentModel.DataAnnotations;

namespace mmaf_inf.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please enter the name we may address you by"]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your surname"]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a valid e-mail address so we can get in touch"]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a message"]
        public string Message { get; set; }
    }
}
