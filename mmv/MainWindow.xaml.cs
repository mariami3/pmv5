using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set
            {
                contacts = value;
                OnPropertyChanged();
            }
        }

        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged();
            }
        }

        private ViewModelBase currentPage;
        public ViewModelBase CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowContactListPageCommand { get; }
        public ICommand ShowContactDetailsPageCommand { get; }

        public MainViewModel()
        {
            ShowContactListPageCommand = new RelayCommand(ShowContactListPage);
            ShowContactDetailsPageCommand = new RelayCommand(ShowContactDetailsPage);

            ContactListViewModel contactListViewModel = new ContactListViewModel();
            contactListViewModel.LoadContacts();
            ContactDetailsViewModel contactDetailsViewModel = new ContactDetailsViewModel();

            CurrentPage = contactListViewModel;
        }

        private void ShowContactListPage(object obj)
        {
            CurrentPage = new ContactListViewModel();
        }

        private void ShowContactDetailsPage(object obj)
        {
            CurrentPage = new ContactDetailsViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
