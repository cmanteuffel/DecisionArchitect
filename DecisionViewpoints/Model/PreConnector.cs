using System;
using EA;

namespace DecisionViewpoints.Model
{
    internal class PreConnector
    {
        private readonly int _clientId;
        private readonly int _diagramId;
        private readonly Repository _repository;
        private readonly string _stereotype;
        private readonly string _subtype;
        private readonly int _supplierId;
        private readonly string _type;

        private PreConnector(Repository repository, EventProperties properties)
        {
            _repository = repository;
            _type = properties.Get(EventPropertyKeys.Type).Value;
            _subtype = properties.Get(EventPropertyKeys.Subtype).Value;
            _stereotype = properties.Get(EventPropertyKeys.Stereotype).Value;

            _supplierId = Utilities.ParseToInt32(properties.Get(EventPropertyKeys.SupplierId).Value, -1);
            _clientId = Utilities.ParseToInt32(properties.Get(EventPropertyKeys.ClientId).Value, -1);
            _diagramId = Utilities.ParseToInt32(properties.Get(EventPropertyKeys.DiagramId).Value, -1);
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

        public static PreConnector Wrap(Repository repository, EventProperties properties)
        {
            return new PreConnector(repository, properties);
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
            return "Connector " + _stereotype + "(" + _type + ")\n" + _supplierId + " - " + _clientId + "\n";
        }
    }
}