using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EADiagramObject : IEADiagramObject
    {
        private readonly DiagramObject _native;

        private EADiagramObject(DiagramObject native)
        {
            _native = native;
        }

        public static IEADiagramObject Wrap(DiagramObject native)
        {
            return new EADiagramObject(native);
        }

        
        public int ElementID
        {
            get { return _native.ElementID; }
        }

        public IEADiagram Diagram
        {
            get
            {
                return EARepository.Instance.GetDiagramByID(_native.DiagramID);
            }
        }
    }
}
