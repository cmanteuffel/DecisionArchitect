using EA;

namespace DecisionViewpoints.Model
{
    public class EAConnectorWrapper : IEAWrapper
    {
        private readonly int _clientId;
        private readonly Connector _connector;        
        private readonly Repository _repository;
        private readonly string _stereotype;
        private readonly string _subtype;
        private readonly int _supplierId;
        private readonly string _type;

        private EAConnectorWrapper(Repository repository, int clientId, int supplierId, string stereotype, string type,
                                   string subtype,Connector connector = null)
        {
            _repository = repository;
            _clientId = clientId;
            _stereotype = stereotype;
            _subtype = subtype;
            _supplierId = supplierId;
            _type = type;
            _connector = connector;
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



        public int SupplierId
        {
            get { return _supplierId; }
        }

        public Connector Connector
        {
            get { return _connector; }
        }

        public Repository Repository
        {
            get { return _repository; }
        }

        public static EAConnectorWrapper Wrap(Repository repository, EventProperties properties)
        {
            dynamic type = properties.Get(EAEventPropertyKeys.Type).Value;
            dynamic subtype = properties.Get(EAEventPropertyKeys.Subtype).Value;
            dynamic stereotype = properties.Get(EAEventPropertyKeys.Stereotype).Value;
            dynamic supplierId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.SupplierId).Value, -1);
            dynamic clientId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ClientId).Value, -1);
            return new EAConnectorWrapper(repository, clientId, supplierId, stereotype, type, subtype);
        }

        public static EAConnectorWrapper Wrap(Repository repository, int id)
        {
            Connector connector = repository.GetConnectorByID(id);
            return new EAConnectorWrapper(repository, connector.ClientID, connector.SupplierID, connector.Stereotype,
                                          connector.Type, connector.Subtype, connector);
        }

        public static EAConnectorWrapper Wrap(Repository repository, string guid)
        {
            Connector connector = repository.GetConnectorByGuid(guid);
            return new EAConnectorWrapper(repository, connector.ClientID, connector.SupplierID, connector.Stereotype,
                                          connector.Type, connector.Subtype, connector);
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
            return GetClient().GetStereotypeList() + " " + _stereotype + " " + GetSupplier().GetStereotypeList() + " - " +
                   "\n";
        }
    }
}