using System;
using EA;
using System.Windows.Forms;

namespace DecisionViewpoints
{
    /// <summary>
    /// This class is responsible for handling all the EA events delegated
    /// from MainApplication entry point.
    /// </summary>
    public class EventHandler
    {
        private const string Con = "connected";

        public string Connect()
        {
            return Con;
        }

        public bool OnPreNewElement(Repository repository, EventProperties info)
        {
            MessageBox.Show("to be added");
            return true;
        }

        public bool OnPreNewConnector(Repository repository, EventProperties info)
        {
            var rel = new Relationship(repository, info);
            if (!rel.CheckStereotype("Relationship")) return true;
            if (rel.CheckIfPossible()) return true;
            MessageBox.Show("Decision has state Idea. Relationship is not permitted.",
                "Invalid Relationship");
            return false;
        }

        public void Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
