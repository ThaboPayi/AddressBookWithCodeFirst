using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using AddressBookWithCodeFirst.Models.DB.Entities;

namespace AddressBookWithCodeFirst.Models.DB.Context
{
    public class AddressBookContext : DbContext
    {
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }

        public AddressBookContext() : this("AddressBookConnection")
        {
            Database.SetInitializer<AddressBookContext>(null);
        }

        public AddressBookContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer<AddressBookContext>(null);
        }
        public override int SaveChanges()
        {
            using (var scope = Database.BeginTransaction())
            {
                int result = base.SaveChanges();
                scope.Commit();
                return result;
            }
        }

        public override async Task<int> SaveChangesAsync()
        {
            using (var scope = Database.BeginTransaction())
            {
                try
                {
                    int result = await base.SaveChangesAsync();
                    scope.Commit();
                    return result;
                }
                catch (DbEntityValidationException dbeve)
                {
                    var message = dbeve;
                    throw;
                }
                catch (Exception ex)
                {
                    var meesage = ex;
                    throw;
                }
            }
        }

    }
}