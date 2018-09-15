namespace Colegio.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    //using System.ComponentModel.DataAnnotations;

    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]//only you can to write 50 characters
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Image")]
        public string Photo { get; set; }

        [Display(Name = "Is Student")]
        public bool IsStudent { get; set; }

        [Display(Name = "Is Teacher")]
        public bool IsTeacher { get; set; }




    }
}
