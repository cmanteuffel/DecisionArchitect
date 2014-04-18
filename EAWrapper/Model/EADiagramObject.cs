using EA;

namespace EAWrapper.Model
{
    public class EADiagramObject : IEAObject
    {
        private readonly DiagramObject _native;

        private EADiagramObject(DiagramObject native)
        {
            _native = native;
        }

        public static EADiagramObject Wrap(DiagramObject native)
        {
            return new EADiagramObject(native);
        }

        public int ElementID
        {
            get { return _native.ElementID; }
        }
    }
}
