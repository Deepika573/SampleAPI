using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Bussiness;
using SampleAPIs.Interfaces.Repository;
using SampleAPIs.Models;

namespace SampleAPIs.Bussiness
{
    public class SupportManager : ISupportManager
    {
        private readonly ISupportRepository _supportRepository;
        public SupportManager(ISupportRepository supportRepository)
        {
            _supportRepository = supportRepository;

        }
        public bool Add(Support support)
        {
            return _supportRepository.Add(support);
        }

        public List<Support> GetSupportByI(int id)
        {
            return _supportRepository.GetSupportById(id);
        }

        public bool CreateSup(Support support)
        {
            return _supportRepository.CreateSupport(support);
        }

        public bool DeleteSup(Support support)
        {
            return _supportRepository.DeleteSupport(support);
        }

        public Support GetSup(int id)
        {
            return _supportRepository.GetSupport(id);
        }

        public IQueryable<Support> GetSups()
        {
            return _supportRepository.GetSupports();
        }

        public bool Save()
        {
            return _supportRepository.Save();
        }

        public bool UpdateSup(Support support)
        {
            return _supportRepository.UpdateSupport(support);
        }

        public List<FullSupport> GetFullSup(int id)
        {
            return _supportRepository.GetFullSupport(id);
        }
        public List<Support> SortSupportByCreatedD()
        {
            return _supportRepository.SortSupportByCreatedDate();
        }
        public List<Support> SortSupportByClosedD()
        {
            return _supportRepository.SortSupportByClosedDate();
        }
    }
}
