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

        public static EADiagramObject Wrap(EventProperties properties)
        {
            var objectId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ObjectId).Value, -1);
            EADiagramObject diagramObject = null;
            if (objectId > 0)
            {
                diagramObject = EARepository.Instance.GetElementByID(objectId);
            }
            return diagramObject;
        }

        public int ElementID
        {
            get { return _native.ElementID; }
        }
    }
}
