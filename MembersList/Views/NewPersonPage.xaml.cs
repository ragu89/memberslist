using System;

using Xamarin.Forms;

namespace MembersList
{
    public partial class NewPersonPage : ContentPage
    {
        public Person Person { get; set; }

        public NewPersonPage()
        {
            InitializeComponent();

            Person = new Person
            {
                LastName = "Last Name",
                FirstName = "First Name"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPerson", Person);
            await Navigation.PopToRootAsync();
        }
    }
}
