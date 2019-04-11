using System;
using System.Data.Entity.Migrations;
using System.Linq;
using AddressBookWithCodeFirst.Models.DB.Context;
using AddressBookWithCodeFirst.Models.DB.Entities;
using AddressBookWithCodeFirst.Models.ViewModels;

namespace AddressBookWithCodeFirst.Models.Manager
{
    public class UpdateContact
    {
        protected readonly AddressBookContext _context;
        public UpdateContact()
        {
            _context = new AddressBookContext();
        }
        public string SaveEditContact(EditModalView viewModel)
        {
            string contactCheck = "";

            ContactDetail cd = _context.ContactDetails.Where(x => x.Id == viewModel.ContactID).Distinct().FirstOrDefault();
            if (cd != null)
            {

                cd = new ContactDetail
                {
                    Id = viewModel.ContactID,
                    ContactName = viewModel.ContactName,
                    ContactSurname = viewModel.ContactSurname,
                    ContactEmail = viewModel.ContactEmail,
                    DateCreated = DateTime.Now
                };

                _context.ContactDetails.AddOrUpdate(cd);
                _context.SaveChanges();
            }
            else
            {
                contactCheck = "There is no such !";

            }

            return contactCheck;

        }
    }
}