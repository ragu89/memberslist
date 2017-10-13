using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MembersList
{
    public partial class PersonsPage : ContentPage
    {
        PersonsViewModel viewModel;

        public PersonsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PersonsViewModel();
        }

        async void OnPersonSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var person = args.SelectedItem as Person;
            if (person == null)
                return;

            await Navigation.PushAsync(new PersonDetailPage(new PersonDetailViewModel(person)));

            // Manually deselect item
            PersonsListView.SelectedItem = null;
        }

        async void AddPerson_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPersonPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Persons.Count == 0)
                viewModel.LoadPersonsCommand.Execute(null);
        }
    }
}
