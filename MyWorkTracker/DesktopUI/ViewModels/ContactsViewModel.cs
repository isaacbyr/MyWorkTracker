using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopUI.ViewModels
{
    public class ContactsViewModel: Screen
    {
        private readonly IContactEndpoint _contactEndpoint;
        private readonly IEventAggregator _events;

        public int CompanyId { get; set; }

        public ContactsViewModel(IContactEndpoint contactEndpoint, IEventAggregator events)
        {
            _contactEndpoint = contactEndpoint;
            _events = events;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadContacts();
        }

        public async Task LoadContacts()
        {
            var contacts = await _contactEndpoint.GetContacts(CompanyId);
            ContactList = new BindingList<ContactModel>(contacts);
        }

        private BindingList<ContactModel> _contactList;

        public BindingList<ContactModel> ContactList
        {
            get { return _contactList; }
            set 
            { 
                _contactList = value;
                NotifyOfPropertyChange(() => ContactList);
            }
        }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set 
            { 
                _selectedContact = value;
                NotifyOfPropertyChange(() => SelectedContact);
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            { 
                _address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }

        private string _contactFirstName;

        public string ContactFirstName
        {
            get { return _contactFirstName; }
            set 
            { 
                _contactFirstName = value;
                NotifyOfPropertyChange(() => ContactFirstName);
            }
        }

        private string _contactLastName;

        public string ContactLastName
        {
            get { return _contactLastName; }
            set 
            { 
                _contactLastName = value;
                NotifyOfPropertyChange(() => ContactLastName);
            }
        }

        private string _contactEmail;

        public string ContactEmail
        {
            get { return _contactEmail; }
            set
            { 
                _contactEmail = value;
                NotifyOfPropertyChange(() => ContactEmail);
            }
        }

        private string _contactPhoneNumber;

        public string ContactPhoneNumber
        {
            get { return _contactPhoneNumber; }
            set 
            {
                _contactPhoneNumber = value;
                NotifyOfPropertyChange(() => ContactPhoneNumber);
            }
        }

        private string _contactAddress;

        public string ContactAddress
        {
            get { return _contactAddress; }
            set 
            {
                _contactAddress = value;
                NotifyOfPropertyChange(() => ContactAddress);
            }
        }


        public void Contact_View()
        {
            ContactFirstName = SelectedContact.FirstName;
            ContactLastName = SelectedContact.LastName;
            ContactEmail = SelectedContact.Email;
            ContactAddress = SelectedContact.Address;
            ContactPhoneNumber = SelectedContact.PhoneNumber;
        }

        public async Task AddContact()
        {

            if(!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Email) 
                && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Address)) 
            {
                var contact = new ContactModel
                {
                    CompanyId = CompanyId,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    Address = Address
                };

                ContactList.Add(contact);

                await _contactEndpoint.PostContact(contact);

                NotifyOfPropertyChange(() => ContactList);
            }

        }

        public void ReturnHome()
        {
            _events.PublishOnUIThread(new ReturnHomeEvent());
        }
    }
}
