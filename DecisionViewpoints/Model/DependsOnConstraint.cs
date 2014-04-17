using System.Collections.Generic;
using System.Windows.Forms;

namespace DecisionViewpoints.Model
{
    internal class DependsOnConstraint
    {

        private static readonly HashSet<string> SupplierState = new HashSet<string>()
            {
                Stereotypes.StateTentative,
                Stereotypes.StateDecided,
                Stereotypes.StateApproved,
                Stereotypes.StateChallenged
            };

        public static bool Validate(PreConnector connector)
        {
            if (connector.Stereotype.Equals(Stereotypes.RelationDependsOn))
            {
                if (!SupplierState.Contains(connector.GetSupplier().GetStereotypeList()))
                {
                    MessageBox.Show("Depends on only allowed to point at tentative, decideded, approved, challenged");
                    return false;
                } 
            }
            return true;
        }
    }

    internal class CausedByConstraint
    {

        private static readonly HashSet<string> SupplierState = new HashSet<string>()
            {
                Stereotypes.StateDiscarded
            };

        public static bool Validate(PreConnector connector)
        {
            if (connector.Stereotype.Equals(Stereotypes.RelationCausedBy))
            {

                if (SupplierState.Contains(connector.GetSupplier().GetStereotypeList()))
                {
                    MessageBox.Show("Caused by is not allowed to point at discarded");
                    return false;
                }
            }
            return true;
        }
    }
}