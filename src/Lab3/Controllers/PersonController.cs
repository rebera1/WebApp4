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

        //private PersonRepository repo;

        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
            //repo = new PersonRepository();
        }

        public IActionResult Index()
        {

            return View(_context.Persons.ToList());
        }


        public IActionResult ShowPerson(int? id)
        {
            Person per;
            if (id == null)
            {
                per = new Person
                {
                    PersonID = 1,
                    FirstName = "Allie",
                    LastName = "Reber",
                    Birthday = "10/07/1994",

                };
            }
            else
            {
                per = _context.Persons.SingleOrDefault(p => p.PersonID == id);
            }

            return View(per);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = _context.Persons
                    .SingleOrDefault(p => p.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View("ShowPerson", person);
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
                //repo.Add(person);

                _context.Add(person);
                _context.SaveChanges();



                return RedirectToAction("Index");

            }
            else
            {
                return View(person);
            }
        }

        public IActionResult EditPerson(int id)
        {

            var person = _context.Persons.SingleOrDefault(p => p.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(int id, Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }
            _context.Persons.Update(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

      
        [HttpPost]
        public IActionResult DeletePerson(int id, Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
                _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
