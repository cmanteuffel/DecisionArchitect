using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model.New
{
    public interface IConcern
    {
        string Name { get; }
        string ConcernGUID { get; }
    }


    public class Concern : IConcern
    {
        public Concern(string concernGUID)
        {
            IEAElement element = EAMain.Repository.GetElementByGUID(concernGUID);
            Name = element.Name;
            ConcernGUID = concernGUID;
        }

        public string Name { get; private set; }
        public string ConcernGUID { get; private set; }
    }
}