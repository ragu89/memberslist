using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using System.Collections.Generic;

namespace MembersList
{
    public class PersonsViewModel : BaseViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }
        public Command LoadPersonsCommand { get; set; }

        public PersonsViewModel()
        {
            Title = "Browse";
            Persons = new ObservableCollection<Person>();
            LoadPersonsCommand = new Command(async () => await ExecuteLoadPersonsCommand());

            MessagingCenter.Subscribe<NewPersonPage, Person>(this, "AddPerson", async (obj, person) =>
            {
                var _person = person as Person;

                var existingPerson = await DataStore.GetPersonAsync(_person?.Id);

                if(existingPerson == null)
                {
                    Persons.Add(_person);
                    await DataStore.AddPersonAsync(_person);
                }
                else
                {
                    Persons.Remove(_person);
                    Persons.Add(_person.CloneOf()); // To force the UI to reload the property

                    await DataStore.UpdatePersonAsync(_person);
                }

                await ExecuteLoadPersonsCommand(); // Necessary to apply the OrderBy on the list

            });
        }

        async Task ExecuteLoadPersonsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Persons.Clear();

                var persons = await DataStore.GetPersonsAsync(true);
                foreach (var person in persons.ToList().OrderBy(p => p.LastName))
                {
                    Persons.Add(person);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
