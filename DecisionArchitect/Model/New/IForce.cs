using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model.New
{
    public interface IForce
    {
        string Name { get; }
        string ForceGUID { get; }
    }

    public class Force : IForce
    {
        public Force(string forceGUID)
        {
            IEAElement element = EAMain.Repository.GetElementByGUID(forceGUID);
            Name = element.Name;
            ForceGUID = forceGUID;
        }

        public string Name { get; private set; }
        public string ForceGUID { get; private set; }
    }
}