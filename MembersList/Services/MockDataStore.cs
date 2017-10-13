using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembersList
{
    public class MockDataStore : IDataStore<Person>
    {
        List<Person> persons;

        public MockDataStore()
        {
            persons = new List<Person>();
            var mockpersons = new List<Person>
            {
                new Person { Id = Guid.NewGuid().ToString("N"), LastName = "Wayne", FirstName="Bruce" },
                new Person { Id = Guid.NewGuid().ToString("N"), LastName = "Kent", FirstName="Clark" },
                new Person { Id = Guid.NewGuid().ToString("N"), LastName = "Stark", FirstName="Tony" },
                new Person { Id = Guid.NewGuid().ToString("N"), LastName = "Skywalker", FirstName="Anakin" },
            };

            foreach (var person in mockpersons)
            {
                persons.Add(person);
            }
        }

        public async Task<bool> AddPersonAsync(Person person)
        {
            persons.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var _person = persons.Where((Person arg) => arg.Id == person.Id).FirstOrDefault();
            persons.Remove(_person);
            persons.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePersonAsync(string id)
        {
            var _person = persons.Where((Person arg) => arg.Id == id).FirstOrDefault();
            persons.Remove(_person);

            return await Task.FromResult(true);
        }

        public async Task<Person> GetPersonAsync(string id)
        {
            return await Task.FromResult(persons.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(persons);
        }
    }
}
