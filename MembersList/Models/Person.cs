using System;

namespace MembersList
{
    public class Person
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Person CloneOf()
        {
            return new Person()
            {
                Id = Id,
                LastName = LastName,
                FirstName = FirstName
            };
        }
    }
}
