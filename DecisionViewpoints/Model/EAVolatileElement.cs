using System.Windows.Forms;
using EA;

namespace DecisionViewpoints.Model
{
    public class EAVolatileElement : IEAObject
    {
        private EAVolatileElement()
        {
        }

        public EADiagram Diagram { get; private set; }
        public string Stereotype { get; private set; }
        public string Type { get; private set; }
        public EAElement ParentElement { get; private set; }

        public static EAVolatileElement Wrap(EventProperties info)
        {
            var volatileElement = new EAVolatileElement();
            volatileElement.Type = info.Get(EAEventPropertyKeys.Type).Value;
            volatileElement.Stereotype = info.Get(EAEventPropertyKeys.Stereotype).Value;

            dynamic parentElementID = Utilities.ParseToInt32(info.Get(EAEventPropertyKeys.ParentId).Value, -1);
            if (parentElementID > 0)
            {
                volatileElement.ParentElement = EARepository.Instance.GetElementByID(parentElementID);
            }

            dynamic diagramID = Utilities.ParseToInt32(info.Get(EAEventPropertyKeys.DiagramId).Value, -1);
            if (diagramID != -1)
            {
                volatileElement.Diagram = EARepository.Instance.GetDiagramByID(diagramID);
            }

            return volatileElement;
        }
    }
}