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

        public enum Property
        {
            Type, Subtype, Stereotype, ClientId, SupplierId, DiagramId
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public Relationship(_EventProperties info)
        {
            _stereotype = info.Get(Property.Stereotype).Value;
            _clientid = info.Get(Property.ClientId).Value;
            _supplierid = info.Get(Property.SupplierId).Value;
        }

        /// <summary>
        /// Compares the stereotype of the relationship with the given stereotype.
        /// </summary>
        /// <param name="stereotype">The stereotype to be used in the comparison.</param>
        /// <returns>True if the two stereotypes are equal, false otherwise.</returns>
        public bool CheckStereotype(string stereotype)
        {
            return _stereotype.Equals(stereotype);
        }

        /// <summary>
        /// Checks if a relationship between two Decisions is allowed.
        /// </summary>
        /// <returns>True if the relationship is permitted, false otherwise.</returns>
        public bool CheckIfPossible(Repository repository)
        {
            var client = repository.GetElementByID(Convert.ToInt32(_clientid));
            var supplier = repository.GetElementByID(Convert.ToInt32(_supplierid));
            TaggedValue clientState = client.TaggedValues.GetByName("state");
            TaggedValue supplierState = supplier.TaggedValues.GetByName("state");
            return !clientState.Value.Equals("idea") && !supplierState.Value.Equals("idea");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if the client and the supplier are the same, false otherwise.</returns>
        public bool CheckIfDecisionsEqual()
        {            
            return _clientid.Equals(_supplierid);
        }
    }
}
