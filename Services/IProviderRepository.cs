using System.Collections.Generic;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Model;

namespace PhyndDemo_v2.Services{

    public interface IProviderRepository{

        IEnumerable<Provider> GetProviders();
        Provider GetProvider(int Id);
        void AddProvider(Provider Provider);
        void DeleteProvider(Provider Provider);
        IEnumerable<Provider> GetProviders(Params ProviderParams);
        bool Save();
    }
}