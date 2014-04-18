using System.Windows.Forms;
using EA;

namespace EAFacade.Model
{
    public class EAConnector : IModelItem
    {
        private readonly Connector _native;

        private EAConnector(Connector native)
        {
            _native = native;
        }

        public string GUID
        {
            get { return _native.ConnectorGUID; }
        }

        public int ID
        {
            get { return _native.ConnectorID; }
        }

        
        
        public NativeType NativeType
        {
            get { return NativeType.Connector; }
        }

        public string Type
        {
            get { return _native.Type; }
            set { _native.Type = value; }

        }

        public string Name
        {
            
            get { return _native.Name; }
            set { _native.Name = value; }
        }

        public string Stereotype
        {
            get { return _native.Stereotype; }
            set { _native.Stereotype = value; }
        }

        public int SupplierId
        {
            get { return _native.SupplierID; }
        }

        public int ClientId
        {
            get { return _native.ClientID; }
        }

        public string Notes
        {
            get { return _native.Notes; }
            set { _native.Notes = value; }
        }

        public string MetaType
        {
            get { return _native.MetaType; }
            set { _native.MetaType = value; }
        }

        //[Obsolete("Do not use outside of model namespace or main app")]
        internal static EAConnector Wrap(Connector native)
        {
            return new EAConnector(native);
        }

        public EAElement GetSupplier()
        {
            return EARepository.Instance.GetElementByID(_native.SupplierID);
        }

        public EAElement GetClient()
        {
            return EARepository.Instance.GetElementByID(_native.ClientID);
        }

        public EADiagram GetDiagram()
        {
            EADiagram diagram = null;
            if (_native.DiagramID > 0)
                diagram = EARepository.Instance.GetDiagramByID(_native.DiagramID);
            return diagram;
        }

        public bool IsRelationship()
        {
            return DVStereotypes.RelationMetaType.Equals(MetaType);
        }

        public bool IsAction()
        {
            return DVStereotypes.ActionMetaType.Equals(MetaType);
        }
    }
}
