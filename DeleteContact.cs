using System;
using System.Linq;
using AddressBookWithCodeFirst.Models.DB.Context;
using AddressBookWithCodeFirst.Models.DB.Entities;

namespace AddressBookWithCodeFirst.Models.Manager
{
    public class DeleteContact
    {
        protected readonly AddressBookContext _context;
        public DeleteContact()
        {
            _context = new AddressBookContext();
        }
        public string DeleteContactDetails(Guid contactId)
        {
            string contactCheck = "";

            ContactDetail cd = _context.ContactDetails.Where(x => x.Id == contactId).Distinct().FirstOrDefault();
            if (cd != null)
            {
                _context.ContactDetails.Remove(cd);
                _context.SaveChanges();
                contactCheck = "Contact Deleted !";
            }
            else
            {
                contactCheck = "There is no such !";
            }

            return contactCheck;
        }
    }
}