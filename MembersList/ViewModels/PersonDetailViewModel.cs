using System;

namespace MembersList
{
    public class PersonDetailViewModel : BaseViewModel
    {
        public Person Person { get; set; }
        public PersonDetailViewModel(Person person = null)
        {
            Title = person?.LastName;
            Person = person;
        }
    }
}
