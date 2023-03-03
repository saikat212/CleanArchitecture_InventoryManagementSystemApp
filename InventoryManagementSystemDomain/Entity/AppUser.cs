using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace InventoryManagementSystemDomain.Entity
{
    public class AppUser : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, ErrorMessage = "First Name must be a maximum length of 100")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(100, ErrorMessage = "Middle Name must be a maximum length of 100")]
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last Name must be a maximum length of 100")]
        public string? LastName { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "User Name be a minimum length of 6 and a maximum length of 100")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be a minimum length of 6 and a maximum length of 20")]
        public string Password { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not Valid")]
        public string? Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Date of Birth is not Valid")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [NotMapped]
        public string GenderName
        {
            get
            {
                return Gender == Gender.Male ? "Male" : "Female";
            }
        }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }  
    }
    public enum Gender
    {
        Male = 1,
        Female
    }
}
