using Microsoft.EntityFrameworkCore;
using BirthdayManagement.WebApp.Models;

namespace BirthdayManagement.WebApp.DatabaseAccess
{
    public class PersonsDatabaseAccess : DbContext
    {
        //Construtor que recebe como parametro a variavel do tipo DbContenxtOption que herda de DbContext
        public PersonsDatabaseAccess(DbContextOptions options) : base(options) { }

        //Propriedade do tipo DbSet de Pessoas que realiza a persistência de pessoas 
        public DbSet<Person> Persons { get; set; } 
    }
}
