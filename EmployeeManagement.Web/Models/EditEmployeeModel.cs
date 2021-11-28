using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "ram.com", ErrorMessage = "Only ram.com is allowed")]
        public string Email { get; set; }
        [Compare("Email",ErrorMessage = "Email and confirm email must match.")]
        public string ConfirmEmail { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string Photo { get; set; }
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();

    }
}
