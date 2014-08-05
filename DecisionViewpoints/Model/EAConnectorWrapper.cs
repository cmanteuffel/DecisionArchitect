using System;
using EA;

namespace DecisionViewpoints.Model
{
    [Obsolete("Needed to be split up in EAConnector and VolatileConnector")]
    public class EAConnectorWrapper : IEAObject
    {
        private readonly int _clientId;  
        private readonly string _stereotype;
        private readonly string _subtype;
        private readonly int _supplierId;
        private readonly string _type;

        private EAConnectorWrapper(int clientId, int supplierId, string stereotype, string type,
                                   string subtype)
        {
            _clientId = clientId;
            _stereotype = stereotype;
            _subtype = subtype;
            _supplierId = supplierId;
            _type = type;
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

        public static EAConnectorWrapper Wrap(Connector native)
        {
            return Wrap(native.ConnectorID);
        }

        public static EAConnectorWrapper Wrap(EventProperties properties)
        {
            dynamic type = properties.Get(EAEventPropertyKeys.Type).Value;
            dynamic subtype = properties.Get(EAEventPropertyKeys.Subtype).Value;
            dynamic stereotype = properties.Get(EAEventPropertyKeys.Stereotype).Value;
            dynamic supplierId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.SupplierId).Value, -1);
            dynamic clientId = Utilities.ParseToInt32(properties.Get(EAEventPropertyKeys.ClientId).Value, -1);
            return new EAConnectorWrapper(clientId, supplierId, stereotype, type, subtype);
        }

        public static EAConnectorWrapper Wrap(int id)
        {
            EARepository repository = EARepository.Instance;
            return repository.GetConnectorByID(id);
        }

        public static EAConnectorWrapper Wrap(string guid)
        {
            EARepository repository = EARepository.Instance;
            return repository.GetConnectorByGUID(guid);
        }

        public EAElement GetSupplier()
        {
            EARepository repository = EARepository.Instance;
            return repository.GetElementByID(_supplierId);
        }

        public EAElement GetClient()
        {
            EARepository repository = EARepository.Instance;
            return repository.GetElementByID(_clientId);
        }

        public override string ToString()
        {
            return GetClient().Stereotype + " " + _stereotype + " " + GetSupplier().Stereotype + " - " +
                   "\n";
        }


    }
}