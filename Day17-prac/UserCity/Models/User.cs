using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserCity.Models
{
    public class User
    {
        [Key]
        [DataType(DataType.Text)]
        [MinLength(4),MaxLength(10)]
        public string LoginName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        [MinLength(4),MaxLength(10)]
        public string Password { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Name")]
        [MinLength(4), MaxLength(10)]
        public string FullName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }
        public int CityId { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter Phone")]
        [MinLength(10), MaxLength(10)]
        public string Phone { get; set; }

        public bool IsActive { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}