using System.Collections.Generic;
using System.Linq;
using AddressBookWithCodeFirst.Models.DB.Context;
using AddressBookWithCodeFirst.Models.DB.Entities;

namespace AddressBookWithCodeFirst.Models.Manager
{
    public class GetContacts
    {
        protected readonly AddressBookContext _context;
        public GetContacts()
        {
            _context = new AddressBookContext();
        }
        public List<ContactDetail> PullContacts()
        {
            var allContacts = _context.ContactDetails.Where(m => m.ContactName != null || m.ContactEmail != null).Distinct().OrderBy(x => x.ContactName).ToList();
            return allContacts;
        }
    }
}