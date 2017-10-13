using System;

using Xamarin.Forms;

namespace MembersList
{
    public partial class NewPersonPage : ContentPage
    {
        public Person Person { get; set; }

        public NewPersonPage() : this(new Person() { Id = System.Guid.NewGuid().ToString("N"), LastName = "Last Name", FirstName = "First Name" })
        { }

        public NewPersonPage(Person person)
        {
            InitializeComponent();
            Person = person;
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPerson", Person);
            await Navigation.PopToRootAsync();
        }
    }
}
