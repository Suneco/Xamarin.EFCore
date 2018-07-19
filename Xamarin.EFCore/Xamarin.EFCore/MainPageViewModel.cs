using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.EFCore.Entities;
using Xamarin.Forms;

namespace Xamarin.EFCore
{
    public sealed class MainPageViewModel : INotifyPropertyChanged
    {
        private Person[] _persons;
        public Person[] Persons
        {
            get => _persons;
            set
            {
                _persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private ICommand _addPersonCommand;
        public ICommand AddPersonCommand
        {
            get => _addPersonCommand;
            set
            {
                _addPersonCommand = value;
                OnPropertyChanged(nameof(AddPersonCommand));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            AddPersonCommand = new Command(AddPerson);

            LoadPersons();
        }

        private void AddPerson()
        {
            using (var ctx = new DatabaseContext(App.DatabasePath))
            {
                var person = new Person()
                {
                    FirstName = FirstName,
                    LastName = LastName
                };

                ctx.Persons.Add(person);
                ctx.SaveChanges();
            }

            LoadPersons();
        }

        private void LoadPersons()
        {
            using (var ctx = new DatabaseContext(App.DatabasePath))
            {
                Persons = ctx.Persons.ToArray();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
