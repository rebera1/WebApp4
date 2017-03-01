using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;


namespace Lab3.Controllers
{
	public class PersonController : Controller
	{
		
		private static PersonRepository repo = new PersonRepository();

		public IActionResult Index()
		{
			return View(repo.PersonList);
		}

		
		public IActionResult ShowPerson()
		{
			Person p = new Person
			{
				FirstName = "Allie",
				LastName = "Reber",
				Birthday = "10/07/1994",
			
			};

			return View(p);
		}

		public IActionResult AddPerson()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddPerson(Person person)
		{
			if (ModelState.IsValid)
			{
				repo.Add(person);

				return RedirectToAction("Index");

			}
			else
			{
				return View(person);
			}
		}
	}
}
