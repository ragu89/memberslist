using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

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
                Persons.Add(_person);
                await DataStore.AddPersonAsync(_person);
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
                foreach (var person in persons)
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
