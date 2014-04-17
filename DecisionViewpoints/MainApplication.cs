using System;
using EA;

namespace DecisionViewpoints
{
    /// <summary>
    /// This is the main entry point of the add-in.
    /// All the events received in this class are delegated.
    /// </summary>
    public class MainApplication
    {
        private readonly EventHandler _eventHandler;

        /// <summary>
        /// The default constructor. An instance of EventHandler is created.
        /// </summary>
        public MainApplication()
        {
            _eventHandler = new EventHandler();
        }

        /// <summary>
        /// Handled by the EventHandler.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <returns>Returns a constant string 'connected'</returns>
        public String EA_Connect(Repository repository)
        {
            return _eventHandler.Connect();
        }

        /// <summary>
        /// Handled by the EventHandler.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the element to be created.</param>
        /// <returns>Returns true to permit the creation of the element, false to deny.</returns>
        public bool EA_OnPreNewElement(Repository repository, EventProperties info)
        {
            return _eventHandler.OnPreNewElement(repository, info);
        }

        /// <summary>
        /// Handled by the EventHandler.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="info">Contains properties of the connector to be created.</param>
        /// <returns>Returns true to permit the creation of the connector, false to deny.</returns>
        public bool EA_OnPreNewConnector(Repository repository, EventProperties info)
        {
            return _eventHandler.OnPreNewConnector(repository, info);
        }

        /// <summary>
        /// Handled by the EventHandler.
        /// </summary>
        /// <param name="repository">The EA repository.</param>
        /// <param name="diagramId">The ID of the diagram that has been opened.</param>
        public void EA_OnPostOpenDiagram(Repository repository, int diagramId)
        {
            _eventHandler.OnPostOpenDiagram(repository, diagramId);
        }

        /// <summary>
        /// Handled by the EventHandler.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="guid"></param>
        /// <param name="ot"></param>
        public void EA_OnNotifyContextItemModified(Repository repository, string guid, ObjectType ot)
        {
            _eventHandler.OnNotifyContextItemModified(repository, guid, ot);
        }

        /// <summary>
        /// Handled by the EventHandler.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="guid"></param>
        /// <param name="ot"></param>
        public void EA_OnContextItemChanged(Repository repository, string guid, ObjectType ot)
        {
            _eventHandler.OnContextItemChanged(repository, guid, ot);
        }

        /// <summary>
        /// Handled by the EventHandler.
        /// </summary>
        public void EA_Disconnect() 
        { 
            _eventHandler.Disconnect();
        }
    }
}
