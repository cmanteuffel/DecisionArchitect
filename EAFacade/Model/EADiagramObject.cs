using System.Windows.Forms;
using EA;

namespace EAFacade.Model
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

        public EADiagram Diagram
        {
            get
            {
                return EARepository.Instance.GetDiagramByID(_native.DiagramID);
            }
        }
    }
}
