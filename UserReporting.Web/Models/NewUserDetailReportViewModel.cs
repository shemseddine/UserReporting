using System;
using System.ComponentModel.DataAnnotations;

namespace UserReporting.Web.Models
{
    public class NewUserDetailReportViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Postcode")]
        public string PostCode { get; set; }
        [Display(Name = "Joined on")]
        public DateTime JoinedOn { get; set; }
    }
}
