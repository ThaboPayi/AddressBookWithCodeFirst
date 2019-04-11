using System;
using System.Data.Entity.Migrations;
using System.Linq;
using AddressBookWithCodeFirst.Models.DB.Context;
using AddressBookWithCodeFirst.Models.DB.Entities;

namespace AddressBookWithCodeFirst.Models.Manager
{
    public class CreateContact
    {
        protected readonly AddressBookContext _context;
        public CreateContact()
        {
            _context = new AddressBookContext();
        }
        public string AddContact(string contactName, string contactSurname, string contactEmail)
        {
            string contactCheck = "";
            ContactDetail cd = _context.ContactDetails.Where(x => x.ContactName == contactSurname || x.ContactEmail == contactEmail).Distinct().FirstOrDefault();
            if (cd != null)
            {
                contactCheck = cd.ContactName.ToString() + "Already exists !";
            }
            else
            {
                cd = new ContactDetail
                {
                    Id = Guid.NewGuid(),
                    ContactName = contactName,
                    ContactSurname = contactSurname,
                    ContactEmail = contactEmail,
                    DateCreated = DateTime.Now
                };

                _context.ContactDetails.AddOrUpdate(cd);
                _context.SaveChanges();

                contactCheck = cd.ContactName.ToString() + "Added Successfully";
            }

            return contactCheck;
        }
    }
}