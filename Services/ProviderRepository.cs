using System;
using System.Collections.Generic;
using System.Linq;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Model;

namespace PhyndDemo_v2.Services{

    public class ProviderRepository : IProviderRepository
    {
        private readonly phynd2Context _context;
        public ProviderRepository(phynd2Context context)
        {
            _context = context;
        }
        public void AddProvider(Provider Provider)
        {
            if (Provider == null)
            {
                throw new ArgumentNullException(nameof(Provider));
            }

            _context.Providers.Add(Provider);
        }

        public void DeleteProvider(Provider Provider)
        {
            if (Provider == null)
            {
                throw new ArgumentNullException(nameof(Provider));
            }

            _context.Providers.Remove(Provider);
        }

        public Provider GetProvider(int Id)
        {
            return _context.Providers.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<Provider> GetProviders()
        {
            return _context.Providers.ToList<Provider>();
        }

        public IEnumerable<Provider> GetProviders(Params ProviderParams)
        {
            if(ProviderParams == null){
                throw new ArgumentNullException(nameof(ProviderParams));
            }

            if(string.IsNullOrWhiteSpace(ProviderParams.sortByFirstName) 
                && string.IsNullOrWhiteSpace(ProviderParams.sortByLastName) 
                && string.IsNullOrWhiteSpace(ProviderParams.Search))
            {
                return GetProviders();
            }

            var collection = _context.Providers as IQueryable<Provider>;
            if(!string.IsNullOrWhiteSpace(ProviderParams.sortByFirstName))
            {
                var firstName = ProviderParams.sortByFirstName.Trim();
                collection = collection.Where(a => a.FirstName == firstName);
            }
            if(!string.IsNullOrWhiteSpace(ProviderParams.sortByLastName)){

                var lastName = ProviderParams.sortByLastName.Trim();
                collection = collection.Where(a => a.LastName == lastName);

            }

            if(!string.IsNullOrWhiteSpace(ProviderParams.Search))
            {
                var search = ProviderParams.Search.Trim();
                return collection.Where(a => a.FirstName.Contains(search) || a.MiddleName.Contains(search) ||a.LastName.Contains(search));
            }

            return collection.ToList();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool CheckProvider(string FirstName, string MiddleName,string LastName)
        {
            return _context.Providers.Any(a => a.FirstName == FirstName || a.MiddleName == MiddleName || a.LastName == LastName);
        }
    }
}