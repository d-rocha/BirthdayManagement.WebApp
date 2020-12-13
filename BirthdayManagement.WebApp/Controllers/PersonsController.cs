using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BirthdayManagement.WebApp.Models;
using BirthdayManagement.WebApp.Repository;
using BirthdayManagement.WebApp.DatabaseAccess;

namespace BirthdayManagement.WebApp.Controllers
{
    public class PersonsController : Controller
    {
        //Attribute of type PersonsRepository that accesses the database class
        PersonsRepository personRepository;

        //Constructor that receives the PersonsDatabaseAccess variable
        public PersonsController(PersonsDatabaseAccess db)
        {
            personRepository = new PersonsRepository(db);
        }

        // GET: Persons/Register        
        [HttpGet]
        public ActionResult Register()
        {
            //Load the registration page
            return View();
        }

        // POST: Persons/Register
        [HttpPost]
        public ActionResult Register(string name, string lastname, DateTime dob)
        {
            //Instance of a new person
            Person person = new Person();
            person.Id = Guid.NewGuid();
            person.Name = name.ToUpper();
            person.LastName = lastname.ToUpper();
            person.Dob = dob;

            //Record person in the mock database
            personRepository.Create(person);

            return View();
        }

        // GET: Persons/List
        [HttpGet]
        public ActionResult List(string query)
        {
            //Instantiate a list of people and assign the search event
            List<Person> persons = personRepository.ReadByQuery(query);
            List<Person> personOrderDobByAsc = persons.OrderBy(p => p.Dob).ToList();

            //If the list is empty, return page 404
            if (persons.Count == 0)
                return RedirectToAction("Error404");
            
            return View(personOrderDobByAsc);
        }

        // GET: Persons/Detail/id
        [HttpGet]
        public ActionResult Detail(Guid id)
        {   
            //Instantiate a person type object and assign the event to search by id
            Person person = personRepository.ReadById(id);

            return View(person);
        }

        // GET: Persons/Edit/id
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            //Instantiate a person type object and assign the event to search by id
            Person person = personRepository.ReadById(id);

            return View(person);
        }

        // POST: Persons/Edit/id
        [HttpPost]
        public ActionResult Edit(Guid id, string name, string lastname, DateTime dob)
        {
            //Instantiate a person type object and assign the event to search by id
            Person person = personRepository.ReadById(id);

            //Checks whether the database id is the same as the searched person
            if (person.Id == id)
            {
                person.Name = name.ToUpper();
                person.LastName = lastname.ToUpper();
                person.Dob = dob;

                personRepository.Update(person);
            }
            return View(person);
        }

        // GET: Persons/Delete
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            //Instantiate a person type object and assign the event to search by id
            Person person = personRepository.ReadById(id);

            return View(person);
        }

        // POST: Persons/Delete/id
        [HttpPost]
        public ActionResult DeleteById(Guid id)
        {
            //Instantiate a person type object and assign the event to search by id
            Person person = personRepository.ReadById(id);

            //Delete the person in the database
            personRepository.Delete(person);
            
            return RedirectToAction("List");
        }

        //GET: Persons/404
        [HttpGet]
        public ActionResult Error404()
        {
            //Load the Error page
            return View();
        }

        //Get: Index Persons DOB
        [HttpGet]
        public ActionResult Index()
        {
            var personsDob = personRepository.ReadAll().Where(p => p.Dob.Equals(DateTime.Today));

            return View(personsDob);
        }
    }
}
