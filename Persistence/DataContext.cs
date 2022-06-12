using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

//this is for the orm, which gives a layer of abstraction between the code and the datastore
//this way you wont have to worry about the database you choose
namespace Persistence
{
    public class DataContext : DbContext
    {
        //constructor
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; } //represents a table in our db
    }
}