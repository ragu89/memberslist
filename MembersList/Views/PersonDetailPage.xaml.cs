using System;

using Xamarin.Forms;

namespace MembersList
{
    public partial class PersonDetailPage : ContentPage
    {
        PersonDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public PersonDetailPage()
        {
            InitializeComponent();

            var person = new Person
            {
                LastName = "Last Name",
                FirstName = "First Name"
            };

            viewModel = new PersonDetailViewModel(person);
            BindingContext = viewModel;
        }

        public PersonDetailPage(PersonDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
