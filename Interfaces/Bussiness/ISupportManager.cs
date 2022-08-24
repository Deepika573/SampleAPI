using SampleAPIs.Entities;
using SampleAPIs.Models;

namespace SampleAPIs.Interfaces.Bussiness
{
    public interface ISupportManager
    {
        public List<FullSupport> GetFullSup(int id);
        bool Add(Support entity);
        IQueryable<Support> GetSups();
        Support GetSup(int id);
        bool CreateSup(Support support);
        bool UpdateSup(Support support);
        bool DeleteSup(Support support);
        bool Save();
        public List<Support> GetSupportByI(int id);
        public List<Support> SortSupportByCreatedD();
        public List<Support> SortSupportByClosedD();
    }
}
