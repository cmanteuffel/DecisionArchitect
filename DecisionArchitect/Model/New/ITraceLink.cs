using EAFacade;

namespace DecisionArchitect.Model.New
{
    public interface ITraceLink
    {
        string TracedElementGUID { get; }
        string TracedElementName { get; }
    }

    public class TraceLink : ITraceLink
    {
        public TraceLink(string guid)
        {
            TracedElementGUID = guid;
            TracedElementName = EAMain.Repository.GetElementByGUID(guid).Name;
        }

        public string TracedElementGUID { get; private set; }
        public string TracedElementName { get; private set; }
    }
}