using System;
using EA;
using System.Windows.Forms;

namespace DecisionViewpoints
{
    /// <summary>
    /// This class is responsible for handling all the EA events delegated
    /// from MainApplication which is the entry point.
    /// </summary>
    public class EventHandler
    {
        // These values need to be consistent with the ones defined in the DecisionVS MDG file.
        private const string RelStereotype = "Relationship";
        private const string DiagramMetaType = "DecisionVS::RelationshipView";
        private const string ToolboxName = "DecisionVS";

        private const string Con = "connected";

        /// <summary>
        /// Called Before EA starts to check Add-In Exists. Nothing is done here.
        /// This operation needs to exists for the addin to work.
        /// </summary>
        /// <returns>Returns a constant string 'connected'</returns>
        public string Connect()
        {
            return Con;
        }

        /// <summary>
        /// Called before a new element is created. It can be used to deny the creation
        /// of the new element.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the element to be created.</param>
        /// <returns>Returns true to permit the creation of the element, false to deny.</returns>
        public bool OnPreNewElement(Repository repository, EventProperties info)
        {
            return true;
        }

        /// <summary>
        /// Called before a new connector is created. It can be used to deny the creation
        /// of the new connector.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the connector to be created.</param>
        /// <returns>Returns true to permit the creation of the connector, false to deny.</returns>
        public bool OnPreNewConnector(Repository repository, EventProperties info)
        {
            var rel = new Relationship(repository, info);
            if (!rel.CheckStereotype(RelStereotype)) return true;
            if (rel.CheckIfPossible()) return true;
            MessageBox.Show("Decision has state Idea. Relationship is not permitted.",
                "Invalid Relationship");
            return false;
        }

        /// <summary>
        /// Called after a diagram has been opended for the first time.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="diagramId">The ID of the diagram that has been opened.</param>
        public void OnPostOpenDiagram(Repository repository, int diagramId)
        {
            var diagram = repository.GetDiagramByID(diagramId);
            if (diagram.MetaType.Equals(DiagramMetaType))
            {
                repository.ActivateToolbox(ToolboxName, 0);
            }
        }

        /// <summary>
        /// EA calls this operation when it exists. It is used to
        /// do some cleanup work.
        /// </summary>
        public void Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
