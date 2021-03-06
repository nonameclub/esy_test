using ESY.TEST.Models.EntityFramework;
using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace ESY.TEST.Models
{
    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        // Allow Initialization with an instance of ApplicationUser:
        public EditUserViewModel(ApplicationUser user)
        {
            this.UserName = user.UserName;
			this.FirstName = user.FirstName;
			this.LastName = user.LastName;
			this.Id = user.Id;
        }

		public string Id
		{
			get;
			set;
		}

		[Required]
		[DataType(DataType.EmailAddress)]
		[Email]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}