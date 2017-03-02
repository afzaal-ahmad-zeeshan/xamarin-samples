using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers {

    [Route("api/xamarinendpoint")]
    public class XamarinBackendManager : Controller {
        public static List<Person> People { get; set; }

        public XamarinBackendManager() {
            if(People == null) {
                People = new List<Person> {
                    new Person { Id = 1, Name = "Afzaal Ahmad Zeeshan", Dob = new DateTime(1995, 08, 29) },
                    new Person { Id = 2, Name = "Afzaal Ahmad Zeeshan", Dob = new DateTime(1990, 08, 29) },
                    new Person { Id = 3, Name = "Afzaal Ahmad Zeeshan", Dob = new DateTime(1985, 08, 29) },
                    new Person { Id = 4, Name = "Afzaal Ahmad Zeeshan", Dob = new DateTime(2001, 08, 29) },
                    new Person { Id = 5, Name = "Afzaal Ahmad Zeeshan", Dob = new DateTime(2005, 08, 29) }
                };
            }
        }

        [HttpGetAttribute("")]
        public List<Person> GetPeople() {
            return People;
        }

        [HttpPostAttribute]
        public void PostPerson([FromBody] Person person) {
            if(person != null) {
                People.Add(person);
            }
        }

        [HttpPutAttribute("{id}")]
        public void UpdatePerson(int id, [FromBody] Person person) {
            if(person != null) {
                People.RemoveAll(x => x.Id == person.Id);
                People.Add(person);
            }
        }

        [HttpDeleteAttribute("{id}")]
        public void DeletePerson(int id) {
            People.RemoveAll(x => x.Id == id);
        }
    }

    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob {get; set; }
    }
}
