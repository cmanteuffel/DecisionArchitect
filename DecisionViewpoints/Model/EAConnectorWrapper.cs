using System.Globalization;
using System.Windows.Forms;
using EA;

namespace DecisionViewpoints.Model
{
    public  class EAConnectorWrapper
    {
        private readonly int _clientId;
        private readonly int _diagramId;
        private readonly Repository _repository;
        private readonly string _stereotype;
        private readonly string _subtype;
        private readonly int _supplierId;
        private readonly string _type;

        private EAConnectorWrapper(Repository repository, EventProperties properties)
        {
            _repository = repository;
            _type = properties.Get(EAEventPropertyKeys.Type).Value;
            _subtype = properties.Get(EAEventPropertyKeys.Subtype).Value;
            _stereotype = properties.Get(EAEventPropertyKeys.Stereotype).Value;

            _supplierId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.SupplierId).Value, -1);
            _clientId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ClientId).Value, -1);
            _diagramId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.DiagramId).Value, -1);
        }

        public string Subtype
        {
            get { return _subtype; }
        }

        public string Stereotype
        {
            get { return _stereotype; }
        }

        public string Type
        {
            get { return _type; }
        }

        public int ClientId
        {
            get { return _clientId; }
        }

        public int DiagramId
        {
            get { return _diagramId; }
        }

        public int SupplierId
        {
            get { return _supplierId; }
        }

        public static EAConnectorWrapper Wrap(Repository repository, EventProperties properties)
        {
            return new EAConnectorWrapper(repository, properties);
        }

        public static EAConnectorWrapper Wrap(Repository repository, string guid)
        {
            Element element = repository.GetElementByGuid(guid);
            if (element is Connector)
            {
                var eaConnector = (Connector) element;
                MessageBox.Show("Converted element to connector");
            }
            return null;
        }

        public Diagram GetDiagram()
        {
            return _repository.GetDiagramByID(_diagramId);
        }

        public Element GetSupplier()
        {
            return _repository.GetElementByID(_supplierId);
        }

        public Element GetClient()
        {
            return _repository.GetElementByID(_clientId);
        }

        public override string ToString()
        {
            return  GetClient().GetStereotypeList() + " " + _stereotype + " " + GetSupplier().GetStereotypeList() + " - " + "\n";
        }
    }
}