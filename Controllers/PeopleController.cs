using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebAPIdemo.DataStore;
using WebAPIdemo.Controllers.ViewModels;

namespace WebAPIdemo.Controllers
{
    [Route("api/people")]
    public class PeopleController : Controller
    {
        private static readonly InMemoryContext Db = new InMemoryContext();
        
        static PeopleController() {
            Db.Add(new Person("Dave"));
            Db.Add(new Person("Tariq"));
            Db.Add(new Person("Rikki"));
        }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return Db.Set<Person>().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return Db.Find<Person>(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Person person)
        {
            Db.Add(person);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person person)
        {
            var p = Db.Find<Person>(id);
            Db.Update(p);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
