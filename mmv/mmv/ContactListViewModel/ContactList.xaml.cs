using System.Collections.ObjectModel;
using System.Windows.Input;

namespace mmv

{
    public class ContactList : ViewModelBase
    {
        private ObservableCollection<Contact> contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set
            {
                contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        public ICommand EditContactCommand { get; }

        public ContactList()
        {
            EditContactCommand = new RelayCommand(EditContact);
        }

        public void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>
            {
                new Contact { Name = "John Doe", Phone = "123-456-7890", Email = "john.doe@example.com" },
                new Contact { Name = "Jane Smith", Phone = "987-654-3210", Email = "jane.smith@example.com" }
            };
        }

    }
}
