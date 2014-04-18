using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EAVolatileConnector : IEAVolatileConnector
    {
        private EAVolatileConnector()
        {
        }

        public string Type { get; private set; }
        public string Subtype { get; private set; }
        public string Stereotype { get; private set; }
        public IEAElement Supplier { get; private set; }
        public IEAElement Client { get; private set; }
        public IEADiagram Diagram { get; private set; }

        public static IEAVolatileConnector Wrap(EventProperties properties)
        {
            var volatileConnector = new EAVolatileConnector
                {
                    Type = properties.Get(EAEventPropertyKeys.Type).Value,
                    Subtype = properties.Get(EAEventPropertyKeys.Subtype).Value,
                    Stereotype = properties.Get(EAEventPropertyKeys.Stereotype).Value
                };

            var supplierId = EAUtilities.ParseToInt32(properties.Get(EAEventPropertyKeys.SupplierId).Value, -1);
            if (supplierId > 0)
            {
                volatileConnector.Supplier = EARepository.Instance.GetElementByID(supplierId);
            }
            var clientId = EAUtilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ClientId).Value, -1);
            if (clientId > 0)
            {
                volatileConnector.Client = EARepository.Instance.GetElementByID(clientId);
            }
            var diagramId = EAUtilities.ParseToInt32(properties.Get(EAEventPropertyKeys.DiagramId).Value, -1);
            if (diagramId > 0)
            {
                volatileConnector.Diagram = EARepository.Instance.GetDiagramByID(diagramId);
            }

            return volatileConnector;
        }
    }
}