using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Portfolio.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [AllowHtml]
        public string Message { get; set; }
    }
}