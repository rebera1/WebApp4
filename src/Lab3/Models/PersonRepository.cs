using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
	public class PersonRepository
	{
		public List<Person> PersonList { get; set; }


		public PersonRepository()
		{
			PersonList = new List<Person>();

			Person p = new Person
			{
				FirstName = "Allison",
				LastName = "Reber",
				Birthday = "10/07/1994",

			};

			PersonList.Add(p);


			Person o = new Person
			{
				FirstName = "Ryan",
				LastName = "McDonagh",
				Birthday = "06/13/1989",

			};

			PersonList.Add(o);

			Person z = new Person
			{
				FirstName = "Adrianna",
				LastName = "Boucher",
				Birthday = "05/31/1995",

			};

			PersonList.Add(z);

		}

		public void Add(Person person)
		{
			PersonList.Add(person);
		}
	}


}