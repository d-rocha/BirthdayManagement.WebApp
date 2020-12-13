using System;
using System.Linq;
using System.Collections.Generic;
using BirthdayManagement.WebApp.Models;
using BirthdayManagement.WebApp.DatabaseAccess;

namespace BirthdayManagement.WebApp.Repository
{
    public class PersonsRepository
    {
        //Atributo privado da classe de banco de dados
        private  readonly PersonsDatabaseAccess _personsDatabase;

        //Construtor
        public PersonsRepository(PersonsDatabaseAccess personsDatabase)
        {
            _personsDatabase = personsDatabase;
        }

        /// <summary>
        /// CRUD, implementa o método Create
        /// </summary>
        /// <param name="person"></param>
        public void Create(Person person)
        {
            _personsDatabase.Persons.Add(person);
            _personsDatabase.SaveChanges();
        }

        /// <summary>
        /// CRUD, implementa o método Read
        /// </summary>
        /// <returns>Retorna uma lista de pessoas</returns>
        public List<Person> ReadAll()
        {
            return _personsDatabase.Persons.ToList();
        }

        /// <summary>
        /// CRUD, implementa o método Read, só que por busca
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Retorna uma lista de nome buscados pela query</returns>
        public List<Person> ReadByQuery(string query)
        {
            if (query == null)
            {
                return ReadAll();
            }

            return _personsDatabase.Persons.Where(person => person.Name.Contains(query)).ToList();
        }

        /// <summary>
        /// CRUD, implementa o método Read, só que por busca pela Id
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns>Retorna uma pessoa busca pela id existente na lista</returns>
        public Person ReadById(Guid id)
        {
            return _personsDatabase.Persons.FirstOrDefault(person => person.Id == id);            
        }   

        /// <summary>
        /// CRUD, implementa o método Update
        /// </summary>
        /// <param name="person"></param>
        public void Update(Person person)
        {
            _personsDatabase.Persons.Update(person);
            _personsDatabase.SaveChanges();                
        }

        /// <summary>
        /// CRUD, implementa o método Delete
        /// </summary>
        /// <param name="person"></param>
        public void Delete(Person person)
        {
            _personsDatabase.Persons.Remove(person);
            _personsDatabase.SaveChanges();
        }
    }
}
