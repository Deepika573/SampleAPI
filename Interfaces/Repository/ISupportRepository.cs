using EF.Core.Repository.Interface.Repository;
using SampleAPIs.Entities;
using SampleAPIs.Models;

namespace SampleAPIs.Interfaces.Repository
{
    public interface ISupportRepository : ICommonRepository<Support>
    {
        IQueryable<Support> GetSupports();
        Support GetSupport(int id);

        public List<FullSupport> GetFullSupport(int id);
        bool CreateSupport(Support support);
        bool UpdateSupport(Support support);
        bool DeleteSupport(Support support);
        bool Save();
        public List<Support> GetSupportById(int id);
        public List<Support> SortSupportByCreatedDate();
        public List<Support> SortSupportByClosedDate();
    }
}
