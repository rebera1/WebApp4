using System;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
	public class Person
	{
         public int PersonID { get; set; }
		[Required(ErrorMessage ="Please enter your first name.")]
		[StringLength(20, MinimumLength =2, ErrorMessage ="Enter a name with 2-25 characters.")]
		public string FirstName { get; set; }
		public string LastName { get; set; }

		 public string Birthday { get; set; }


		

		public int Age { get
			{

				DateTime dt = Convert.ToDateTime(Birthday);
				DateTime now = DateTime.Now;

				int AgeInYears = (int) (now.Year - dt.Year - 1);

				if (now.DayOfYear >= dt.DayOfYear)
				{
					AgeInYears = (int)(now.Year - dt.Year);
				}

	

				return AgeInYears;
			}

		}
	}
}