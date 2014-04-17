using System;
using EA;

namespace TSDAD
{
    public class Main
    {
        /// <summary>
        /// Called Before EA starts to check Add-In Exists
        /// Nothing is done here.
        /// This operation needs to exists for the addin to work
        /// </summary>
        /// <param name="repository">the EA repository</param>
        /// <returns>connected</returns>
        public String EA_Connect(Repository repository)
        {
            //No special processing required.
            return "connected";
        }

        /// <summary>
        /// EA calls this operation when it exists. It is used to
        /// do some cleanup work.
        /// </summary>
        public void EA_Disconnect() 
        { 
            GC.Collect(); 
            GC.WaitForPendingFinalizers(); 
        }
    }
}
