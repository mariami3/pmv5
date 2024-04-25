using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace mmv

{
    public class ContactDetailsViewModel : ViewModelBase
    {
        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public ICommand SaveContactCommand { get; }

        public ContactDetailsViewModel()
        {
            SaveContactCommand = new RelayCommand(SaveContact);
        }

        private void SaveContact(object obj)
        {
        
        }
    }
}

