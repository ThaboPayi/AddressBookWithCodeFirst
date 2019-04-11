using System.Collections.Generic;
using System.Linq;
using AddressBookWithCodeFirst.Models.DB.Context;
using AddressBookWithCodeFirst.Models.DB.Entities;

namespace AddressBookWithCodeFirst.Models.Manager
{
    public class SearchContact
    {
        protected readonly AddressBookContext _context;
        public SearchContact()
        {
            _context = new AddressBookContext();
        }
        public List<ContactDetail> SearchContactDetails(string searchValue)
        {
            var allContacts = _context.ContactDetails.Where(m => m.ContactName.ToUpper().Contains(searchValue.ToUpper()) || m.ContactEmail.ToUpper().Contains(searchValue.ToUpper())).OrderBy(x => x.ContactName).ToList();
            return allContacts;
        }
    }
}