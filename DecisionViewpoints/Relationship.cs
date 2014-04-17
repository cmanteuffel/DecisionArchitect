using System;
using EA;

namespace DecisionViewpoints
{
    /// <summary>
    /// 
    /// </summary>
    public class Relationship
    {
        private readonly string _stereotype;
        private readonly string _clientid;
        private readonly string _supplierid;
        private readonly Repository _repository;

        public enum Property
        {
            Type, Subtype, Stereotype, ClientId, SupplierId, DiagramId
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info"></param>
        public Relationship(Repository repository, _EventProperties info)
        {
            _repository = repository;
            _stereotype = info.Get(Property.Stereotype).Value;
            _clientid = info.Get(Property.ClientId).Value;
            _supplierid = info.Get(Property.SupplierId).Value;
        }

        /// <summary>
        /// Compares the stereotype of the relationship with the given stereotype.
        /// </summary>
        /// <param name="stereotype">The stereotype to be used in the comparison.</param>
        /// <returns>True if the two stereotypes are equal, else false.</returns>
        public bool CheckStereotype(string stereotype)
        {
            return _stereotype.Equals(stereotype);
        }

        /// <summary>
        /// Checks if a relationship between two Decisions is allowed.
        /// </summary>
        /// <returns>True if the relationship is permitted, else false.</returns>
        public bool CheckIfPossible()
        {
            var client = _repository.GetElementByID(Convert.ToInt32(_clientid));
            var supplier = _repository.GetElementByID(Convert.ToInt32(_supplierid));
            TaggedValue clientState = client.TaggedValues.GetByName("state");
            TaggedValue supplierState = supplier.TaggedValues.GetByName("state");
            return !clientState.Value.Equals("idea") && !supplierState.Value.Equals("idea");
        }

        private string s = Enum.GetName(typeof (Property), Property.ClientId);
    }
}
