using System;
using EA;

namespace TSDAD
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
        /// Called Before EA starts to check Add-In Exists
        /// Nothing is done here.
        /// This operation needs to exists for the addin to work
        /// </summary>
        /// <param name="repository">the EA repository</param>
        /// <returns>connected</returns>
        public String EA_Connect(Repository repository)
        {
            return _eventHandler.Connect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository">the EA repository</param>
        /// <param name="info">contains properties of the element to be created</param>
        /// <returns>true to permit the creation of the element, false to deny</returns>
        public bool EA_OnPreNewElement(Repository repository, EventProperties info)
        {
            return _eventHandler.OnPreNewElement(repository, info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="info"></param>
        /// <returns>true to permit the creation of the element, false to deny</returns>
        public bool EA_OnPreNewConnector(Repository repository, EventProperties info)
        {
            return _eventHandler.OnPreNewConnector(repository, info);
        }

        /// <summary>
        /// EA calls this operation when it exists. It is used to
        /// do some cleanup work.
        /// </summary>
        public void EA_Disconnect() 
        { 
            _eventHandler.Disconnect();
        }
    }
}
